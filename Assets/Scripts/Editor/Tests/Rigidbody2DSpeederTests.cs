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
using UnityEngine;

namespace Game
{
    public class Rigidbody2DSpeederTests
    {
        [TestFixture]
        public class NullRigidbody2D
        {
            private GameObject gameObject;
            private Rigidbody2DSpeeder speeder;

            [SetUp]
            public void SetUp()
            {
                gameObject = new GameObject();
                speeder = new Rigidbody2DSpeeder(gameObject);
            }

            [TearDown]
            public void TearDown()
            {
                GameObject.DestroyImmediate(gameObject);
                gameObject = null;
                speeder = null;
            }

            #region Null Rigidbody2D exception tests
            [Test]
            [ExpectedException("UnityEngine.MissingComponentException")]
            public void TestVelocityGetterThrowsExceptionIfRigidbody2DIsNull()
            {
                Vector3 velocity = speeder.Velocity;
                Assert.Fail();
            }

            [Test]
            [ExpectedException("UnityEngine.MissingComponentException")]
            public void TestVelocitySetterThrowsExceptionIfRigidbody2DIsNull()
            {
                speeder.Velocity = new Vector2(45.2f, 132.4f);
                Assert.Fail();
            }
            #endregion
        }


        [TestFixture]
        public class NotNullRigidbody2D
        {
            private GameObject gameObject;
            private Rigidbody2D rigidbody2D;
            private Rigidbody2DSpeeder speeder;

            [SetUp]
            public void SetUp()
            {
                gameObject = new GameObject();
                rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
                speeder = new Rigidbody2DSpeeder(gameObject);
            }

            [TearDown]
            public void TearDown()
            {
                GameObject.DestroyImmediate(gameObject);
                rigidbody2D = null;
                gameObject = null;
                speeder = null;
            }

            #region Velocity Tests
            [Test]
            public void TestVelocityGetterReturnsRigidbody2DVelocity()
            {
                rigidbody2D.velocity = new Vector2(22.2f, 44.4f);
                Assert.That(speeder.Velocity, Is.EqualTo(new Vector2(22.2f, 44.4f)));
            }

            [Test]
            public void TestVelocitySetterSetsRigidbody2DVelocity()
            {
                speeder.Velocity = new Vector2(11.2f, 33.4f);
                Assert.That(rigidbody2D.velocity, Is.EqualTo(new Vector2(11.2f, 33.4f)));
            }
            #endregion
        }

    }
}