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
    /// A GameObjectPositioner is a dedicated Positionable instance for Unity GameObjects
    /// </summary>
    public class GameObjectPositioner : Positionable
    {
        private GameObject gameObject = null;

        /// <summary>
        /// Creates a GameObjectPositioner for a specific GameObject.
        /// </summary>
        /// <param name="gameObject">The GameObject to use by the created GameObjectPositioner.</param>
        public GameObjectPositioner(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        #region Positionable implementation
        public Vector3 Position {
            get
            {
                return gameObject.transform.position;
            }
            set
            { gameObject.transform.position = value;
            }
        }

        public float XPosition
        {
            get
            {
                return gameObject.transform.position.x;
            }
            set
            {
                Vector3 newPosition = gameObject.transform.position;
                newPosition.x = value;
                gameObject.transform.position = newPosition;
            }
        }

        public float YPosition
        {
            get
            {
                return gameObject.transform.position.y;
            }
            set
            {
                Vector3 newPosition = gameObject.transform.position;
                newPosition.y = value;
                gameObject.transform.position = newPosition;
            }
        }
        #endregion
        
    }
}
