using UnityEngine;
using System.Collections.Generic;

namespace Game
{
    public class DefaultEntityFactory : EntityFactory
    {

        #region Properties
        /// <summary>
        /// Ball prefab to instantiate when creating a Ball.
        /// </summary>
        public GameObject ballPrefab;

        /// <summary>
        /// Paddle prefab to instantiate when creating a Paddle.
        /// </summary>
        public GameObject paddlePrefab;

        /// <summary>
        /// Grey block prefab to instantiate when creating a block.
        /// </summary>
        public GameObject greyBlockPrefab;

        /// <summary>
        /// The expected size for all the blocks.
        /// </summary>
        public Vector2 blockSize = new Vector2(0.64f, 0.32f);

        /// <summary>
        /// An array of BlockInfo instances, defining the types of blocks we can instantiate.
        /// </summary>
        public BlockInfo[] blocksInfo;

        private Dictionary<char, BlockInfo> blockInfoDictionary = new Dictionary<char, BlockInfo>();

        public GameEntity gameEntity;
        #endregion

        #region EntityFactory implementation
        public Paddle CreatePaddle(Vector3 position)
        {
            return gameEntity.CreateGameObjectFromPrefab<Paddle>(paddlePrefab, position);
        }

        public Ball CreateBall(Vector3 position)
        {
            return gameEntity.CreateGameObjectFromPrefab<Ball>(paddlePrefab, position);
        }

        public BlockInfo BlockInfoForCharID(char charID)
        {
            BlockInfo blockInfo = new BlockInfo();
            blockInfoDictionary.TryGetValue(charID, out blockInfo);
            return blockInfo;
        }

        public Block CreateBlock(BlockInfo blockInfo, Vector3 position)
        {
            return gameEntity.CreateGameObjectFromPrefab<Block>(paddlePrefab, position);
        }
        #endregion

    }
}

