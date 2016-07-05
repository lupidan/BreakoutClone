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
        private PlayerInput playerInput;
        private Positionable positionable;
        private Eliminable eliminable;

        [SerializeField]
        private float paddleSpeed = 7.0f;

        [SerializeField]
        private float bounceSpeed = 10.0f;

        [SerializeField]
        private float bounceCorrectFactor = 0.4f;

        [SerializeField]
        private Rect moveArea = new Rect(-5.0f, -5.0f, 10.0f, 10.0f);

        #region Paddle implementation
        public PlayerInput PlayerInput      { get { return playerInput; }           set { playerInput = value; } }
        public Positionable Positionable    { get { return positionable; }          set { positionable = value; } }
        public Eliminable Eliminable        { get { return eliminable; }            set { eliminable = value; } }
        public float PaddleSpeed            { get { return paddleSpeed; }           set { paddleSpeed = value; } }
        public float BounceSpeed            { get { return bounceSpeed; }           set { bounceSpeed = value; } }
        public float BounceCorrectFactor    { get { return bounceCorrectFactor; }   set { bounceCorrectFactor = value; } }
        public Rect MoveArea                { get { return moveArea; }              set { moveArea = value; } }

        public void CollidedWith(Ball ball)
        {
            if (positionable != null &&
                ball != null && ball.Positionable != null && ball.Speedable != null)
            {
                float correctFactor = bounceCorrectFactor;
                if (correctFactor < 0.0f)
                {
                    correctFactor = 0.0f;
                }

                float bounceSpeed = BounceSpeed;
                if (bounceSpeed < 0.0f)
                {
                    bounceSpeed = 0.0f;
                }

                Vector3 bounceDirection = ball.Positionable.Position - positionable.Position;
                bounceDirection.x = bounceDirection.x * correctFactor;
                bounceDirection.z = 0.0f;
                ball.Speedable.Velocity = bounceDirection.normalized * bounceSpeed;
            }
        }

        public void UpdatePosition(float deltaTime)
        {
            if (playerInput.HasValidInput)
            {
                float xAxis = playerInput.XAxis;
                Vector3 position = positionable.Position;
                position.x += xAxis * paddleSpeed * deltaTime;
                position = moveArea.ClampPosition(position);
                positionable.Position = position;
            }
            
        }
        #endregion
    }
}

