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
    [TestFixture]
    public class GameObjectPositionerTests
    {
        private GameObject gameObject;
        private GameObjectPositioner positioner;

        [SetUp]
        public void SetUp()
        {
            gameObject = new GameObject();
            positioner = new GameObjectPositioner(gameObject);
        }

        [TearDown]
        public void TearDown()
        {
            GameObject.DestroyImmediate(gameObject);
            gameObject = null;
            positioner = null;
        }

        #region Position Tests
        [Test]
        public void TestPositionSetterChangesGameObjectTransformPosition()
        {
            positioner.Position = new Vector3(20.0f, 30.0f, 10.0f);
            Assert.That(gameObject.transform.position, Is.EqualTo(new Vector3(20.0f, 30.0f, 10.0f)));
        }

        [Test]
        public void TestPositionGetterReturnsGameObjectTransformPosition()
        {
            gameObject.transform.position = new Vector3(99.0f, 66.0f, 33.0f); ;
            Assert.That(positioner.Position, Is.EqualTo(new Vector3(99.0f, 66.0f, 33.0f)));
        }
        #endregion

        #region XPosition Tests
        [Test]
        public void TestXPositionSetterOnlyChangesGameObjectTransformXPosition()
        {
            gameObject.transform.position = Vector3.zero;
            positioner.XPosition = 33.0f;
            Assert.That(gameObject.transform.position.x, Is.EqualTo(33.0f));
            Assert.That(gameObject.transform.position.y, Is.EqualTo(0.0f));
            Assert.That(gameObject.transform.position.z, Is.EqualTo(0.0f));
        }

        [Test]
        public void TestXPositionGetterReturnsGameObjectTransformXPosition()
        {
            gameObject.transform.position = new Vector3(99.0f, 66.0f, 33.0f); ;
            Assert.That(positioner.XPosition, Is.EqualTo(99.0f));
        }
        #endregion

        #region YPosition Tests
        [Test]
        public void TestYPositionSetterOnlyChangesGameObjectTransformYPosition()
        {
            gameObject.transform.position = Vector3.zero;
            positioner.YPosition = 24.5f;
            Assert.That(gameObject.transform.position.x, Is.EqualTo(0.0f));
            Assert.That(gameObject.transform.position.y, Is.EqualTo(24.5f));
            Assert.That(gameObject.transform.position.z, Is.EqualTo(0.0f));
        }

        [Test]
        public void TestYPositionGetterReturnsGameObjectTransformYPosition()
        {
            gameObject.transform.position = new Vector3(99.0f, 66.0f, 33.0f);
            Assert.That(positioner.YPosition, Is.EqualTo(66.0f));
        }
        #endregion

        #region ZPosition Tests
        [Test]
        public void TestZPositionSetterOnlyChangesGameObjectTransformZPosition()
        {
            gameObject.transform.position = Vector3.zero;
            positioner.ZPosition = 47.2f;
            Assert.That(gameObject.transform.position.x, Is.EqualTo(0.0f));
            Assert.That(gameObject.transform.position.y, Is.EqualTo(0.0f));
            Assert.That(gameObject.transform.position.z, Is.EqualTo(47.2f));
        }

        [Test]
        public void TestZPositionGetterReturnsGameObjectTransformZPosition()
        {
            gameObject.transform.position = new Vector3(99.0f, 66.0f, 33.0f);
            Assert.That(positioner.ZPosition, Is.EqualTo(33.0f));
        }
        #endregion

    }
}