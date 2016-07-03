///
/// The MIT License(MIT)
/// 
/// Copyright(c) 2016 Daniel Lupiañez Casares
/// 
/// Permission is hereby granted, free of charge, to any person obtaining a copy
/// of this software and associated documentation files (the "Software"), to deal
/// in the Software without restriction, including without limitation the rights
/// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the Software is
/// furnished to do so, subject to the following conditions:
/// 
/// The above copyright notice and this permission notice shall be included in all
/// copies or substantial portions of the Software.
/// 
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
/// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
/// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
/// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
/// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
/// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
/// SOFTWARE.
///

using NUnit.Framework;
using NSubstitute;
using UnityEngine;

namespace Game
{
    [TestFixture]
    public class NormalBallTests
    {
        private NormalBall ball;
        

        [SetUp]
        public void SetUp()
        {
            ball = new NormalBall();
        }

        [TearDown]
        public void TearDown()
        {
            ball = null;
        }

        #region Test Initial values
        [Test]
        public void TestIsOnPlayIsInitiallyFalse()
        {
            Assert.IsFalse(ball.IsOnPlay);
        }
        #endregion

        #region Reset calls
        [Test]
        public void TestResetDoesNotThrowExceptionIfSpeedableIsNull()
        {
            ball.Speedable = null;
            ball.Reset();
            Assert.Pass();
        }
        #endregion

        #region Launch calls
        [Test]
        public void TestLaunchDoesNotThrowExceptionIfSpeedableIsNull()
        {
            ball.Speedable = null;
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
        public void TestLaunchWith0SpeedMustSetVectorToZero()
        {
            Speedable speedableMock = MockObjectFactory.MakeSpeedableMock();
            ball.Speedable = speedableMock;
            ball.Launch(90.0f, 0.0f);
            Assert.That(speedableMock.Velocity, Is.EqualTo(Vector2.zero));
        }

        [Test]
        public void TestLaunchWithAngleSetsVelocityVectorInThatDirection()
        {
            Speedable speedableMock = MockObjectFactory.MakeSpeedableMock();
            ball.Speedable = speedableMock;

            float[] angles         = { -35.0f, 0.0f, 22.123f, 90.0f, 124.312f, 180.0f, 234.776f, 270.0f, 333.333f, 360.0f, 390.0f};
            float[] expectedAngles = { 325.0f, 0.0f, 22.123f, 90.0f, 124.312f, 180.0f, 234.776f, 270.0f, 333.333f,   0.0f, 30.0f };
            for (int i = 0; i < angles.Length; i++)
            {
                ball.Launch(angles[i], 10.0f);

                float velocityAngle = AngleForVector(speedableMock.Velocity);
                Assert.That(velocityAngle, Is.EqualTo(expectedAngles[i]).Within(0.0005));
            }
        }

        [Test]
        public void TestLaunchMustMaintainLaunchSpeedIndependentOnAngle()
        {
            Speedable speedableMock = MockObjectFactory.MakeSpeedableMock();
            ball.Speedable = speedableMock;

            float[] angles = { -35.0f, 0.0f, 22.123f, 90.0f, 124.312f, 180.0f, 234.776f, 270.0f, 333.333f, 360.0f, 390.0f };
            for (int i = 0; i < angles.Length; i++)
            {
                ball.Launch(angles[i], 10.0f);
                Assert.That(speedableMock.Velocity.magnitude, Is.EqualTo(10.0f).Within(0.0005));
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
            Speedable speedableMock = MockObjectFactory.MakeSpeedableMock();
            ball.Speedable = speedableMock;
            ball.Launch(90.0f, 10.0f);
            Assert.That(speedableMock.Velocity, Is.Not.EqualTo(Vector2.zero));
            ball.Reset();
            Assert.That(speedableMock.Velocity, Is.EqualTo(Vector2.zero));
        }
        #endregion

        #region Collided With (Block) calls
        [Test]
        public void TestCollidedWithNullBlockDoesNotThrowException()
        {
            GameController gameControllerMock = MockObjectFactory.MakeGameControllerMock();
            Block blockMock = null;

            ball.gameController = gameControllerMock;

            ball.CollidedWith(blockMock);
            Assert.Pass();
        }

        [Test]
        public void TestCollidedWithBlockWithNullEliminableDoesNotThrowException()
        {
            GameController gameControllerMock = MockObjectFactory.MakeGameControllerMock();
            Block blockMock = MockObjectFactory.MakeBlockMock();
            Eliminable eliminableMock = null;

            blockMock.Eliminable.Returns(eliminableMock);
            ball.gameController = gameControllerMock;
            
            ball.CollidedWith(blockMock);
            Assert.Pass();
        }

        [Test]
        public void TestCollidedWithBlockDoesNotThrowExceptionIfGameControllerIsNull()
        {
            GameController gameControllerMock = null;
            Block blockMock = MockObjectFactory.MakeBlockMock();
            Eliminable eliminableMock = MockObjectFactory.MakeEliminableMock();

            blockMock.Eliminable.Returns(eliminableMock);
            ball.gameController = gameControllerMock;

            ball.CollidedWith(blockMock);
            Assert.Pass();
        }

        [Test]
        public void TestCollidedWithBlockCallsAddPointsWithBlockAmountOfPoints()
        {
            int[] pointsToSet         = { -10, 0, 32 };
            int[] expectedAddedPoints = { -10, 0, 32 };

            GameController gameControllerMock = MockObjectFactory.MakeGameControllerMock();
            Block blockMock = MockObjectFactory.MakeBlockMock(23);
            Eliminable eliminableMock = MockObjectFactory.MakeEliminableMock();

            blockMock.Eliminable.Returns(eliminableMock);
            ball.gameController = gameControllerMock;

            for (int i=0; i < pointsToSet.Length; i++)
            {
                blockMock.Points.Returns(pointsToSet[i]);
                ball.CollidedWith(blockMock);
                gameControllerMock.Received().AddPoints(expectedAddedPoints[i]);
            }
        }

        [Test]
        public void TestCollidedWithBlockDestroysTheBlock()
        {
            GameController gameControllerMock = MockObjectFactory.MakeGameControllerMock();
            Block blockMock = MockObjectFactory.MakeBlockMock();
            Eliminable eliminableMock = MockObjectFactory.MakeEliminableMock();

            blockMock.Eliminable.Returns(eliminableMock);
            ball.gameController = gameControllerMock;

            ball.CollidedWith(blockMock);
            eliminableMock.Received().Eliminate();
        }

        [Test]
        public void TestCollidedWithBlockWillMoveToTheNextLevelIfNoMoreBlocksAreAvailable()
        {
            GameController gameControllerMock = MockObjectFactory.MakeGameControllerMock();
            Block blockMock = MockObjectFactory.MakeBlockMock();
            Eliminable eliminableMock = MockObjectFactory.MakeEliminableMock();

            blockMock.Eliminable.Returns(eliminableMock);
            gameControllerMock.AreAllBlocksDestroyed.Returns(true);
            ball.gameController = gameControllerMock;

            ball.CollidedWith(blockMock);
            gameControllerMock.Received().GoToNextLevel();
        }

        [Test]
        public void TestCollidedWithBlockWillNotMoveToTheNextLevelIfThereAreMoreBlocksAvailable()
        {
            GameController gameControllerMock = MockObjectFactory.MakeGameControllerMock();
            Block blockMock = MockObjectFactory.MakeBlockMock();
            Eliminable eliminableMock = MockObjectFactory.MakeEliminableMock();

            blockMock.Eliminable.Returns(eliminableMock);
            gameControllerMock.AreAllBlocksDestroyed.Returns(false);
            ball.gameController = gameControllerMock;

            ball.CollidedWith(blockMock);
            gameControllerMock.DidNotReceive().GoToNextLevel();
        }
        #endregion

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
