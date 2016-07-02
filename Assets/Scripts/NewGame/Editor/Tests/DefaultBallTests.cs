using NUnit.Framework;
using NSubstitute;
using UnityEngine;

namespace Game
{
    [TestFixture]
    public class DefaultBallTests
    {
        private DefaultBall ball;

        [SetUp]
        public void SetUp()
        {
            ball = new DefaultBall();
        }

        [TearDown]
        public void TearDown()
        {
            ball = null;
        }

        [Test]
        public void TestIsOnPlayIsInitiallyFalse()
        {
            Assert.IsFalse(ball.IsOnPlay);
        }

        [Test]
        public void TestResetDoesNotThrowExceptionIfPositionableIsNull()
        {
            ball.Reset();
            Assert.Pass();
        }

        [Test]
        public void TestLaunchDoesNotThrowExceptionIfPositionableIsNull()
        {
            ball.positionable = null;
            ball.Launch(90.0f, 10.0f);
            Assert.Pass();
        }

        [Test]
        public void TestLaunchSetsIsOnPlayToTrue()
        {
            ball.Launch(90.0f, 10.0f);
            Assert.IsTrue(ball.IsOnPlay);
        }

        [Test]
        public void TestLaunchingWith0SpeedMustSetVectorToZero()
        {
            Positionable mockPositionable = Substitute.For<Positionable>();
            ball.positionable = mockPositionable;
            ball.Launch(90.0f, 0.0f);
            Assert.That(mockPositionable.Velocity, Is.EqualTo(Vector2.zero));
        }

        [Test]
        public void TestLaunchWithAngleSetsVelocityVectorInThatDirection()
        {
            Positionable mockPositionable = Substitute.For<Positionable>();
            ball.positionable = mockPositionable;

            float[] angles         = { -35.0f, 0.0f, 22.123f, 90.0f, 124.312f, 180.0f, 234.776f, 270.0f, 333.333f, 360.0f, 390.0f};
            float[] expectedAngles = { 325.0f, 0.0f, 22.123f, 90.0f, 124.312f, 180.0f, 234.776f, 270.0f, 333.333f,   0.0f, 30.0f };
            for (int i = 0; i < angles.Length; i++)
            {
                ball.Launch(angles[i], 10.0f);

                float velocityAngle = AngleForVector(mockPositionable.Velocity);
                Assert.That(velocityAngle, Is.EqualTo(expectedAngles[i]).Within(0.0005));
            }
        }

        [Test]
        public void TestLaunchMustMaintainLaunchSpeedIndependentOnAngle()
        {
            Positionable mockPositionable = Substitute.For<Positionable>();
            ball.positionable = mockPositionable;

            float[] angles = { -35.0f, 0.0f, 22.123f, 90.0f, 124.312f, 180.0f, 234.776f, 270.0f, 333.333f, 360.0f, 390.0f };
            for (int i = 0; i < angles.Length; i++)
            {
                ball.Launch(angles[i], 10.0f);
                Assert.That(mockPositionable.Velocity.magnitude, Is.EqualTo(10.0f).Within(0.0005));
            }
        }

        [Test]
        public void TestLaunchAndThenResetSetsIsOnPlayToFalse()
        {
            ball.Launch(90.0f, 10.0f);
            Assert.IsTrue(ball.IsOnPlay);
            ball.Reset();
            Assert.IsFalse(ball.IsOnPlay);
        }

        [Test]
        public void TestLaunchAndThenResetSetsVelocityToZero()
        {
            Positionable mockPositionable = Substitute.For<Positionable>();
            ball.positionable = mockPositionable;
            ball.Launch(90.0f, 10.0f);
            Assert.That(mockPositionable.Velocity, Is.Not.EqualTo(Vector2.zero));
            ball.Reset();
            Assert.That(mockPositionable.Velocity, Is.EqualTo(Vector2.zero));
        }

        [Test]
        public void TestCollidedWithNullBlockDoesNotThrowException()
        {
            GameController mockController = Substitute.For<GameController>();
            ball.gameController = mockController;
            ball.CollidedWithBlock(null);
            Assert.Pass();
        }

        [Test]
        public void TestCollidedWithBlockDoesNotThrowExceptionIfGameControllerIsNull()
        {
            Block mockBlock = Substitute.For<Block>();
            ball.gameController = null;
            ball.CollidedWithBlock(mockBlock);
            Assert.Pass();
        }

        [Test]
        public void TestCollidedWithBlockCallsAddPointsWithBlockAmountOfPoints()
        {
            GameController mockController = Substitute.For<GameController>();
            ball.gameController = mockController;
            Block mockBlock = Substitute.For<Block>();
            mockBlock.Points.Returns(32);

            ball.CollidedWithBlock(mockBlock);
            mockController.Received().AddPoints(32);
        }

        [Test]
        public void TestCollidedWithBlockDestroysTheBlock()
        {
            GameController mockController = Substitute.For<GameController>();
            ball.gameController = mockController;
            Block mockBlock = Substitute.For<Block>();

            ball.CollidedWithBlock(mockBlock);
            mockBlock.Received().Destroy();
        }

        [Test]
        public void TestCollidedWithBlockWillMoveToTheNextLevelIfNoMoreBlocksAreAvailable()
        {
            GameController mockController = Substitute.For<GameController>();
            mockController.AreAllBlocksDestroyed.Returns(true);
            ball.gameController = mockController;

            Block mockBlock = Substitute.For<Block>();

            ball.CollidedWithBlock(mockBlock);
            mockController.Received().GoToNextLevel();
        }

        [Test]
        public void TestCollidedWithBlockWillNotMoveToTheNextLevelIfThereAreMoreBlocksAvailable()
        {
            GameController mockController = Substitute.For<GameController>();
            mockController.AreAllBlocksDestroyed.Returns(false);
            ball.gameController = mockController;

            Block mockBlock = Substitute.For<Block>();

            ball.CollidedWithBlock(mockBlock);
            mockController.DidNotReceive().GoToNextLevel();
        }

        private float AngleForVector(Vector2 vector)
        {
            float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
            if (angle < 0.0f)
            {
                angle += 360.0f;
            }
            return angle;
        }
    }
}
