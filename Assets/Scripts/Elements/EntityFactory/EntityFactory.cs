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
    /// A Block info defines a type of block to be placed on the game field.
    /// </summary>
    [System.Serializable]
    public struct BlockInfo
    {
        /// <summary>
        /// A Char that identifies the type of block.
        /// </summary>
        public char charID;

        /// <summary>
        /// The color to apply to the block.
        /// </summary>
        public Color color;

    }

    /// <summary>
    /// An Entity factory describes an instance able to create all types of instances for the game.
    /// It provides methods to create paddles, balls and blocks.
    /// </summary>
    public interface EntityFactory
    {
        /// <summary>
        /// Creates a Paddle for the game.
        /// </summary>
        /// <param name="position">The position for the Paddle.</param>
        /// <returns>The Paddle component of the created GameObject.</returns>
        Paddle CreatePaddle(Vector3 position);

        /// <summary>
        /// Creates a Ball for the game, and attaches it to a Paddle.
        /// </summary>
        /// <param name="position">The position for the ball.</param>
        /// <returns>The Ball component of the created GameObject.</returns>
        Ball CreateBall(Vector3 position);

        /// <summary>
        /// Returns a block info for a specific char ID.
        /// </summary>
        /// <param name="charID">The char ID to identify the type of block</param>
        /// <returns>A BlockInfo instance.</returns>
        BlockInfo BlockInfoForCharID(char charID);

        /// <summary>
        /// Creates a block for the game.
        /// </summary>
        /// <param name="blockID">The block id of the type of block we would like to create</param>
        /// <param name="position">The position of the block.</param>
        /// <returns>The Block component of the created Block component.</returns>
        Block CreateBlock(BlockInfo blockInfo, Vector3 position);

        /// <summary>
        /// Eliminates a specific game object on screen.
        /// </summary>
        /// <param name="gameObject">The game object to eliminate.</param>
        void EliminateGameObject(GameObject gameObject);
    }
}

