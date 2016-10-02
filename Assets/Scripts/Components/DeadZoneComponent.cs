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
    /// A DeadZone component defines a behaviour for a Ball GameObjects destruction area.
    /// It requires one or more Collider2D masks set as triggers to interact with Ball elements.
    /// </summary>
    public class DeadZoneComponent : MonoBehaviour
    {
        /// <summary>
        /// The standard dead zone this object is managing.
        /// </summary>
        public DeadZone deadZone = new DeadZone();

        #region MonoBehaviour
        void Awake()
        {
            deadZone.gameController = Toolbox.Instance.gameController;
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == NormalBallComponent.Tag)
            {
                NormalBallComponent ballComponent = collider.gameObject.GetComponent<NormalBallComponent>();
                deadZone.CollidedWith(ballComponent.ball);
            }
        }
        #endregion

    }
}

