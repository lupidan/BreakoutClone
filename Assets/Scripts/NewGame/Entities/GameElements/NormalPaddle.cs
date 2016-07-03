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
        [SerializeField]
        private float bounceSpeed = 7.0f;
        [SerializeField]
        private Rect moveArea = new Rect(-5.0f, -5.0f, 10.0f, 10.0f);
        [SerializeField]
        private float bounceCorrectFactor = 0.4f;

        #region Paddle implementation
        public Positionable Positionable { get; set; }
        public Eliminable Eliminable { get; set; }
        public float BounceSpeed { get { return bounceSpeed; } }
        public float BounceCorrectFactor { get { return bounceCorrectFactor; } }
        public Rect MoveArea { get { return moveArea; } }

        public void CollidedWith(Ball ball)
        {
            //TODO: Calcular angulo y lanzar
            ball.Launch(45.0f, BounceSpeed);
        }

        
        //TODO: Movign
        #endregion
    }
}

