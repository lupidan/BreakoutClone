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

using NSubstitute;
using UnityEngine;

namespace Game {
    public class MockObjectFactory
    {
        static public Positionable MakePositionableMock()
        {
            return MakePositionableMock(Vector3.zero);
        }

        static public Positionable MakePositionableMock(Vector3 mockedPosition)
        {
            Positionable mock = Substitute.For<Positionable>();
            mock.Position.Returns(mockedPosition);
            mock.XPosition.Returns(mockedPosition.x);
            mock.YPosition.Returns(mockedPosition.y);
            return mock;
        }

        static public Speedable MakeSpeedableMock()
        {
            return MakeSpeedableMock(Vector2.zero);
        }

        static public Speedable MakeSpeedableMock(Vector2 mockedVelocity)
        {
            Speedable mock = Substitute.For<Speedable>();
            mock.Velocity.Returns(mockedVelocity);
            return mock;
        }

        static public Eliminable MakeEliminableMock()
        {
            return Substitute.For<Eliminable>();
        }

        static public Collisionable<T> MakeCollisionableMock<T>()
        {
            Collisionable<T> mock = Substitute.For<Collisionable<T>>();
            return mock;
        }

        static public GameController MakeGameControllerMock()
        {
            return Substitute.For<GameController>();
        }

        static public Block MakeBlockMock(int points = 0)
        {
            Block block = Substitute.For<Block>();
            block.Points.Returns(points);
            return block;
        }

        static public Ball MakeBallMock()
        {
            Ball ball = Substitute.For<Ball>();
            return ball;
        }
    }
}

