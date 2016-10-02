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
using System.Collections.Generic;

namespace Game
{
	/// <summary>
	/// The default implementation of an entity factory
	/// </summary>
    public class DefaultEntityFactory : MonoBehaviour, EntityFactory
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

        private GameObjectPoolManager poolManager = new GameObjectPoolManager();
        #endregion

        #region EntityFactory implementation
        public Paddle CreatePaddle(Vector3 position)
        {
            GameObject gameObject = poolManager.SpawnGameObject(paddlePrefab);
            gameObject.transform.position = position;
            return gameObject.GetComponent<NormalPaddleComponent>().paddle;
        }

        public Ball CreateBall(Vector3 position)
        {
            GameObject gameObject = poolManager.SpawnGameObject(ballPrefab);
            gameObject.transform.position = position;
            return gameObject.GetComponent<NormalBallComponent>().ball;
        }

        public BlockInfo BlockInfoForCharID(char charID)
        {
            BlockInfo blockInfo = new BlockInfo();
            blockInfoDictionary.TryGetValue(charID, out blockInfo);
            return blockInfo;
        }

        public Block CreateBlock(BlockInfo blockInfo, Vector3 position)
        {
            GameObject gameObject = poolManager.SpawnGameObject(greyBlockPrefab);
            gameObject.transform.position = position;
            return gameObject.GetComponent<NormalBlockComponent>().block;
        }

        public void EliminateGameObject(GameObject gameObject)
        {
            poolManager.RecycleGameObject(gameObject);
        }
        #endregion

    }
}

