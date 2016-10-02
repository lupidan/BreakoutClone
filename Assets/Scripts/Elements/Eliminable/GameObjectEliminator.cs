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
    /// A GameObjectEliminator instance implements the Eliminable protocol to destroy a GameObject.
    /// </summary>
    public class GameObjectEliminator : Eliminable
    {
        private GameObject gameObject;

        /// <summary>
        /// Creates a GameObjectEliminator for a specific unity GameObject
        /// </summary>
        /// <param name="gameObject"></param>
        public GameObjectEliminator(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        #region Eliminable implementation
        public void Eliminate()
        {
            EntityFactory entityFactory = Toolbox.Instance.entityFactory;
            if (entityFactory != null && gameObject != null)
            {
                entityFactory.EliminateGameObject(gameObject);
            }
        }
        #endregion
    }
}

