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

        #region CollideWith Ball Tests
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
        #endregion

    }
}

