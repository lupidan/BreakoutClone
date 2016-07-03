
using NUnit.Framework;
using NSubstitute;

namespace Game
{
    /*[TestFixture]
    public class DefaultDeadZoneTests
    {
        private DefaultDeadZone deadZone;

        [SetUp]
        public void SetUp()
        {
            deadZone = new DefaultDeadZone();
        }

        [TearDown]
        public void TearDown()
        {
            deadZone = null;
        }

        [Test]
        public void TestCollidingWithNullBallDoesntThrowException()
        {
            GameController mockController = Substitute.For<GameController>();
            deadZone.gameController = mockController;
            deadZone.CollidedWithBall(null);
            Assert.Pass();
        }

        [Test]
        public void TestCollidingWithBallDoesntThrowExceptionWhenGameControllerIsNull()
        {
            deadZone.gameController = null;
            Ball mockBall = Substitute.For<Ball>();
            deadZone.CollidedWithBall(mockBall);

            Assert.Pass();
        }

        [Test]
        public void TestCollidedWithBallWillDestroyTheBall()
        {
            deadZone.gameController = null;
            Ball mockBall = Substitute.For<Ball>();
            deadZone.CollidedWithBall(mockBall);

            mockBall.Received().Destroy();
        }

        [Test]
        public void TestCollidedWithBallWillSubstractOneLife()
        {
            GameController mockController = Substitute.For<GameController>();
            deadZone.gameController = mockController;
            deadZone.CollidedWithBall(null);

            mockController.Received().SubstractLife();
        }
    }*/
}

