
using NUnit.Framework;
using NSubstitute;

namespace Game
{
    [TestFixture]
    public class DeadZoneTests
    {
        private DeadZone deadZone;

        [SetUp]
        public void SetUp()
        {
            deadZone = new DeadZone();
        }

        [TearDown]
        public void TearDown()
        {
            deadZone = null;
        }

        [Test]
        public void TestCollidingWithNullBallDoesntThrowException()
        {
            GameController gameControllerMock = MockObjectFactory.MakeGameControllerMock();
            Ball ballMock = null;

            deadZone.gameController = gameControllerMock;

            deadZone.CollidedWith(ballMock);
            Assert.Pass();
        }

        [Test]
        public void TestCollidingWithBallDoesntThrowExceptionWhenBallEliminableIsNull()
        {
            GameController gameControllerMock = MockObjectFactory.MakeGameControllerMock();
            Ball ballMock = MockObjectFactory.MakeBallMock();
            Eliminable eliminableMock = null;

            deadZone.gameController = gameControllerMock;
            ballMock.Eliminable.Returns(eliminableMock);

            deadZone.CollidedWith(ballMock);
            Assert.Pass();
        }

        [Test]
        public void TestCollidingWithBallDoesntThrowExceptionWhenGameControllerIsNull()
        {
            GameController gameControllerMock = null;
            Ball ballMock = MockObjectFactory.MakeBallMock();
            Eliminable eliminableMock = MockObjectFactory.MakeEliminableMock();

            deadZone.gameController = gameControllerMock;
            ballMock.Eliminable.Returns(eliminableMock);

            deadZone.CollidedWith(ballMock);
            Assert.Pass();
        }

        [Test]
        public void TestCollidedWithBallWillDestroyTheBall()
        {
            GameController gameControllerMock = MockObjectFactory.MakeGameControllerMock();
            Ball ballMock = MockObjectFactory.MakeBallMock();
            Eliminable eliminableMock = MockObjectFactory.MakeEliminableMock();

            deadZone.gameController = gameControllerMock;
            ballMock.Eliminable.Returns(eliminableMock);

            deadZone.CollidedWith(ballMock);
            eliminableMock.Received().Eliminate();
        }

        [Test]
        public void TestCollidedWithBallWillCallGameControllerSubstractOneLife()
        {
            GameController gameControllerMock = MockObjectFactory.MakeGameControllerMock();
            Ball ballMock = MockObjectFactory.MakeBallMock();
            Eliminable eliminableMock = MockObjectFactory.MakeEliminableMock();

            deadZone.gameController = gameControllerMock;
            ballMock.Eliminable.Returns(eliminableMock);

            deadZone.CollidedWith(ballMock);
            gameControllerMock.Received().SubstractLife();
        }
    }
}

