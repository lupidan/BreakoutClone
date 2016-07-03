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
using System.Collections.Generic;

namespace Game
{
    [TestFixture]
    public class NormalPaddleTests
    {
        private NormalPaddle paddle;

        [SetUp]
        public void SetUp()
        {
            paddle = new NormalPaddle();
        }

        [TearDown]
        public void TearDown()
        {
            paddle = null;

            
        }

        [Test]
        public void TestCollidedWithNullBallDoesntThrowException()
        {
            Positionable paddlePositionableMock = MockObjectFactory.MakePositionableMock();
            Ball ballMock = null;

            paddle.Positionable = paddlePositionableMock;
            
            paddle.CollidedWith(ballMock);
            Assert.Pass();
        }

        [Test]
        public void TestCollidedWithBallDoesntThrowExceptionIfBallPositionableIsNull()
        {
            Positionable paddlePositionableMock = MockObjectFactory.MakePositionableMock();
            Ball ballMock = MockObjectFactory.MakeBallMock();
            Positionable ballPositionableMock = null;
            Speedable ballSpeedableMock = MockObjectFactory.MakeSpeedableMock();

            paddle.Positionable = paddlePositionableMock;
            ballMock.Positionable.Returns(ballPositionableMock);
            ballMock.Speedable.Returns(ballSpeedableMock);

            paddle.CollidedWith(ballMock);
            Assert.Pass();
        }

        [Test]
        public void TestCollidedWithBallDoesntThrowExceptionIfBallSpeedableIsNotNull()
        {
            Positionable paddlePositionableMock = MockObjectFactory.MakePositionableMock();
            Ball ballMock = MockObjectFactory.MakeBallMock();
            Positionable ballPositionableMock = MockObjectFactory.MakePositionableMock();
            Speedable ballSpeedableMock = null;

            paddle.Positionable = paddlePositionableMock;
            ballMock.Positionable.Returns(ballPositionableMock);
            ballMock.Speedable.Returns(ballSpeedableMock);

            paddle.CollidedWith(ballMock);
            Assert.Pass();
        }

        [Test]
        public void TestCollidedWithBallDoesntThrowExceptionIfPositionableIsNull()
        {
            Positionable paddlePositionableMock = null;
            Ball ballMock = MockObjectFactory.MakeBallMock();
            Positionable ballPositionableMock = MockObjectFactory.MakePositionableMock();
            Speedable ballSpeedableMock = MockObjectFactory.MakeSpeedableMock();

            paddle.Positionable = paddlePositionableMock;
            ballMock.Positionable.Returns(ballPositionableMock);
            ballMock.Speedable.Returns(ballSpeedableMock);

            paddle.CollidedWith(ballMock);
            Assert.Pass();
        }

        [Test]
        public void TestCollidedWithBall()
        {
            Positionable paddlePositionableMock = MockObjectFactory.MakePositionableMock();
            Ball ballMock = MockObjectFactory.MakeBallMock();
            Positionable ballPositionableMock = MockObjectFactory.MakePositionableMock();
            Speedable ballSpeedableMock = MockObjectFactory.MakeSpeedableMock();

            paddle.Positionable = paddlePositionableMock;
            ballMock.Positionable.Returns(ballPositionableMock);
            ballMock.Speedable.Returns(ballSpeedableMock);

            Vector3[] testCaseOffsets =
            {
                new Vector3(0.0f, 0.0f, 0.0f),
                new Vector3(100.0f, 80.0f, 0.0f),
                new Vector3(-32.0f, 20.0f, 0.0f),
                new Vector3(-15.0f, -41.0f, 0.0f),
                new Vector3(55.0f, -90.0f, 0.0f)
            };
            float[] testCaseBounceFactors = { 2.0f, 1.0f, 0.6f, 0.4f, 0.1f, 0.0f, -0.1f, -0.4f, -0.6f, -1.0f, -2.0f };
            float[] testCaseBounceSpeeds = { 7.0f, 1.0f, 0.0f, -3.0f, -7.0f };

            List<BounceTestCase> testCases = new List<BounceTestCase>();
            for (int offsetIndex = 0; offsetIndex < testCaseOffsets.Length; offsetIndex += 1)
            {
                for (int factorIndex = 0; factorIndex < testCaseBounceFactors.Length; factorIndex += 1)
                {
                    for (int speedIndex = 0; speedIndex < testCaseBounceSpeeds.Length; speedIndex += 1)
                    {
                        Vector3 offset = testCaseOffsets[offsetIndex];

                        float bounceFactor = testCaseBounceFactors[factorIndex];
                        float realBounceFactor = bounceFactor;
                        if (realBounceFactor < 0.0f)
                            realBounceFactor = 0.0f;

                        float bounceSpeed = testCaseBounceSpeeds[speedIndex];
                        float realBounceSpeed = bounceSpeed;
                        if (realBounceSpeed < 0.0f)
                            realBounceSpeed = 0.0f;

                        testCases.Add(new BounceTestCase(offset, offset + new Vector3(0.0f, 0.0f), bounceSpeed, bounceFactor, new Vector2(0.0f * realBounceFactor, 0.0f).normalized * realBounceSpeed));
                        testCases.Add(new BounceTestCase(offset, offset + new Vector3(2.0f, 0.0f), bounceSpeed, bounceFactor, new Vector2(1.0f * realBounceFactor, 0.0f).normalized * realBounceSpeed));
                        testCases.Add(new BounceTestCase(offset, offset + new Vector3(2.0f, 2.0f), bounceSpeed, bounceFactor, new Vector2(1.0f * realBounceFactor, 1.0f).normalized * realBounceSpeed));
                        testCases.Add(new BounceTestCase(offset, offset + new Vector3(0.0f, 2.0f), bounceSpeed, bounceFactor, new Vector2(0.0f * realBounceFactor, 1.0f).normalized * realBounceSpeed));
                        testCases.Add(new BounceTestCase(offset, offset + new Vector3(-2.0f, 2.0f), bounceSpeed, bounceFactor, new Vector2(-1.0f * realBounceFactor, 1.0f).normalized * realBounceSpeed));
                        testCases.Add(new BounceTestCase(offset, offset + new Vector3(-2.0f, 0.0f), bounceSpeed, bounceFactor, new Vector2(-1.0f * realBounceFactor, 0.0f).normalized * realBounceSpeed));
                        testCases.Add(new BounceTestCase(offset, offset + new Vector3(-2.0f, -2.0f), bounceSpeed, bounceFactor, new Vector2(-1.0f * realBounceFactor, -1.0f).normalized * realBounceSpeed));
                        testCases.Add(new BounceTestCase(offset, offset + new Vector3(0.0f, -2.0f), bounceSpeed, bounceFactor, new Vector2(0.0f * realBounceFactor, -1.0f).normalized * realBounceSpeed));
                        testCases.Add(new BounceTestCase(offset, offset + new Vector3(2.0f, -2.0f), bounceSpeed, bounceFactor, new Vector2(1.0f * realBounceFactor, -1.0f).normalized * realBounceSpeed));
                    }
                }
            }

            BounceTestCase[] testCasesArray = testCases.ToArray();
            for (int i=0; i < testCasesArray.Length; i += 1)
            {
                BounceTestCase testCase = testCasesArray[i];
                paddle.BounceCorrectFactor = testCase.bounceCorrectFactor;
                paddle.BounceSpeed = testCase.bounceSpeed;
                paddlePositionableMock.Position.Returns(testCase.paddlePosition);
                ballPositionableMock.Position.Returns(testCase.ballPosition);

                paddle.CollidedWith(ballMock);
                Assert.That(ballSpeedableMock.Velocity, Is.EqualTo(testCase.expectedVelocity), "Bounce test case failed "+testCase);
            }

        }

        public struct BounceTestCase
        {
            public Vector3 paddlePosition;
            public Vector3 ballPosition;
            public float bounceSpeed;
            public float bounceCorrectFactor;
            public Vector2 expectedVelocity;

            public BounceTestCase(Vector3 paddlePosition, Vector3 ballPosition, float bounceSpeed, float bounceCorrectFactor, Vector3 expectedVelocity)
            {
                this.ballPosition = ballPosition;
                this.paddlePosition = paddlePosition;
                this.bounceSpeed = bounceSpeed;
                this.bounceCorrectFactor = bounceCorrectFactor;
                this.expectedVelocity = expectedVelocity;
            }

            override public string ToString()
            {
                return "\npaddlePosition = " + paddlePosition + "\nballPosition = " + ballPosition + "\nbounceSpeed = " + bounceSpeed + "\nbounceCorrectFactor = " + bounceCorrectFactor + "\n";
            }
        }
    }
}