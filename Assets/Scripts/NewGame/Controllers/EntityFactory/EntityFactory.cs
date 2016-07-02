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
    }
}

