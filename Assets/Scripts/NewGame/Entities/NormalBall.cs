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
    /// A normal ball for the game, no special characteristics.
    /// </summary>
    [System.Serializable]
    public class NormalBall : Ball
    {
        /// <summary>
        /// The game controller to communicate with.
        /// </summary>
        GameController gameController;

        [SerializeField]
        private bool isOnPlay = false;

        #region Ball implementation
        public bool IsOnPlay { get { return isOnPlay; } }
        public Positionable Positionable { get; set; }
        public Eliminable Eliminable { get; set; }
        public Speedable Speedable { get; set; }

        public void Reset()
        {
            isOnPlay = false;
            if (Speedable != null)
            {
                Speedable.Velocity = Vector2.zero;
            }
        }

        public void Launch(float angle, float speed)
        {
            isOnPlay = true;
            if (Speedable != null)
            {
                float radians = angle * Mathf.Deg2Rad;
                Vector3 directionVector = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0.0f).normalized;
                Speedable.Velocity = directionVector * speed;
            }
        }

        public void CollidedWithBlock(Block block)
        {
            if ((block != null) && (gameController != null))
            {
                block.Eliminable.Eliminate();
                gameController.AddPoints(block.Points);
                if (gameController.AreAllBlocksDestroyed)
                {
                    gameController.GoToNextLevel();
                }
            }
        }
        #endregion

    }
}

