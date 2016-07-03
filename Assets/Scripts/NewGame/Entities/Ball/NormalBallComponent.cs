﻿///
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

using UnityEngine;

namespace Game
{
    /// <summary>
    /// A Normal Ball component represents a Unity GameObject that manages a normal ball instance.
    /// </summary>
    public class NormalBallComponent : MonoBehaviour
    {
        /// <summary>
        /// The GameObject tag that all Ball elements should have.
        /// </summary>
        public static string Tag = "Ball";

        /// <summary>
        /// The ball instance being handled by this component.
        /// </summary>
        public NormalBall ball = new NormalBall();

        #region Monobehaviour
        void Awake()
        {
            ball.Positionable = new GameObjectPositioner(this.gameObject);
            ball.Speedable = new Rigidbody2DSpeeder(this.gameObject);
            ball.Eliminable = new GameObjectEliminator(this.gameObject);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == NormalBlockComponent.Tag)
            {
                NormalBlockComponent blockComponent = collision.gameObject.GetComponent<NormalBlockComponent>();
                ball.CollidedWithBlock(blockComponent.block);
            }
        }
        #endregion

        #region PoolableObject implementation
        public void OnSpawn()
        {
            ball.Reset();
        }

        public void OnDespawn()
        {
            
        }
        #endregion
    }
}

