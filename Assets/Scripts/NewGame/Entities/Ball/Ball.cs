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

namespace Game
{
    /// <summary>
    /// A Ball represents a ball object in the game. It contains methods to be launched and reset, as well as providing methods for collision with other elements.
    /// </summary>
    public interface Ball
    {
        /// <summary>
        /// The game controller to communicate with.
        /// </summary>
        GameController GameController { get; }

        /// <summary>
        /// The object able to position the ball on the game scene.
        /// </summary>
        Positionable Positionable { get; }

        /// <summary>
        /// The object able to eliminate the ball from the game scene.
        /// </summary>
        Eliminable Eliminable { get; }

        /// <summary>
        /// The object able to apply speed to the ball in the game scene.
        /// </summary>
        Speedable Speedable { get; }

        /// <summary>
        /// Whether the ball is being played or not.
        /// </summary>
        bool IsOnPlay { get; }

        /// <summary>
        /// Resets the ball status.
        /// </summary>
        void Reset();

        /// <summary>
        /// Launches the ball in a specific angle at a specific speed from it current position.
        /// </summary>
        /// <param name="angle">The angle to launch the ball.</param>
        /// <param name="speed">The speed to launch the ball.</param>
        void Launch(float angle, float speed);

        /// <summary>
        /// Method called when the ball collides with a block.
        /// </summary>
        /// <param name="block">The block that collided with the ball.</param>
        void CollidedWithBlock(Block block);

    }
}

