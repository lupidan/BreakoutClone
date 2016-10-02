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

using UnityEngine;

namespace Game
{
    /// <summary>
    /// A Rigidbody2DSpeeder is a dedicated Speedable object for Unity Rigidbody2D instances. 
    /// </summary>
    public class Rigidbody2DSpeeder : Speedable
    {
        private Rigidbody2D rigidbody2D = null;

        /// <summary>
        /// Convenience method to create a Rigidbody2DSpeeder instance for a Unity GameObject.
        /// </summary>
        /// <param name="gameObject">The GameObject to create the Rigidbody2DSpeeder for.</param>
        public Rigidbody2DSpeeder(GameObject gameObject) : this(gameObject.GetComponent<Rigidbody2D>()) { }

        /// <summary>
        /// Creates a Rigidbody2DSpeeder for a Unity Rigidbody2D.
        /// </summary>
        /// <param name="rigidBody2D">The Rigidbody2D to use by the created Rigidbody2DSpeeder.</param>
        public Rigidbody2DSpeeder(Rigidbody2D rigidBody2D)
        {
            this.rigidbody2D = rigidBody2D;
        }

        #region Speedable implementation
        public Vector2 Velocity {
            get
            {
                return rigidbody2D.velocity;
            }
            set
            {
                rigidbody2D.velocity = value;
            }
        }
        #endregion
    }
}
