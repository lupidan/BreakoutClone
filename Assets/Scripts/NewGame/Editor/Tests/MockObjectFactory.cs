using NUnit.Framework;
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

