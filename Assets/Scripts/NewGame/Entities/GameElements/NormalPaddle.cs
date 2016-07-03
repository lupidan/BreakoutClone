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
    [System.Serializable]
    public class NormalPaddle : Paddle
    {

        #region Paddle implementation
        public Positionable Positionable { get; set; }
        public Eliminable Eliminable { get; set; }
        public float BounceSpeed { get; set; }
        public float BounceCorrectFactor { get; set; }
        public Rect MoveArea { get; set; }

        public void CollidedWith(Ball ball)
        {
            if (Positionable != null &&
                ball != null && ball.Positionable != null && ball.Speedable != null)
            {
                float bounceCorrectFactor = BounceCorrectFactor;
                if (bounceCorrectFactor < 0.0f)
                {
                    bounceCorrectFactor = 0.0f;
                }

                float bounceSpeed = BounceSpeed;
                if (bounceSpeed < 0.0f)
                {
                    bounceSpeed = 0.0f;
                }

                Vector3 bounceDirection = ball.Positionable.Position - Positionable.Position;
                bounceDirection.x = bounceDirection.x * bounceCorrectFactor;
                bounceDirection.z = 0.0f;
                ball.Speedable.Velocity = bounceDirection.normalized * bounceSpeed;
            }
        }

        public void UpdatePosition(float deltaTime)
        {
            //Do stuff here
        }
        #endregion
    }
}

