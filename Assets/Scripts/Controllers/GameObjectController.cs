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

/// <summary>
/// A GameObjectController is responsible of creating, managing and destroying all the game objects for each level.
/// It uses an GameObjectPoolManager to reuse created GameObject instances.
/// </summary>
public class GameObjectController: MonoBehaviour
{

    /// <summary>
    /// A Block info defines a type of block to be placed on the game field.
    /// </summary>
    [System.Serializable]
    public class BlockInfo
    {
        /// <summary>
        /// A Char that identifies the type of block.
        /// </summary>
        public char charID = ' ';

        /// <summary>
        /// The color to apply to the block.
        /// </summary>
        public Color color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

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

    /// <summary>
    /// The Ball currently present in the game.
    /// </summary>
    public Ball gameBall { get; private set; }

    /// <summary>
    /// The paddle currently present in the game.
    /// </summary>
    public Paddle gamePaddle { get; private set; }

    /// <summary>
    /// The parent game object for all the blocks.
    /// </summary>
    public GameObject blockContainer { get; private set; }

    /// <summary>
    /// A list containing all the blocks present in the game.
    /// </summary>
    public List<Block> gameBlocks { get; private set; }

    private Dictionary<char, BlockInfo> blockPrefabDictionary;
    private GameObjectPoolManager poolManager;

    void Awake()
    {
        SetupBlockPrefabMap();
        poolManager = new GameObjectPoolManager();
    }

    /// <summary>
    /// Creates a game with an available level data.
    /// </summary>
    /// <param name="levelData">The level data to create the level.</param>
    public void CreateGame(string levelData)
    {
        Paddle paddle = CreatePaddle(new Vector3(0.0f, -4.5f, 0.0f));

        CreateBall(paddle);

        CreateBlockContainer(new Vector3(0.0f, 3.0f, 0.0f));

        string[] patterns = levelData.Split(new char[] { '\n' });
        gameBlocks = new List<Block>();
        CreateBlockMatrix(patterns);
    }

    /// <summary>
    /// Destroys the game in screen.
    /// </summary>
    public void DestroyGame()
    {
        DestroyAllBlocks();
        DestroyBlockContainer();
        DestroyBall(gameBall);
        DestroyPaddle(gamePaddle);
    }

    /// <summary>
    /// Creates a Ball for the game, and attaches it to a Paddle.
    /// </summary>
    /// <param name="paddle">The Paddle component to attach the Ball to.</param>
    /// <returns>The Ball component of the created GameObject.</returns>
    public Ball CreateBall(Paddle paddle = null)
    {
        if (paddle == null)
        {
            paddle = gamePaddle;
        }
        gameBall = CreateObjectFromPrefab<Ball>(ballPrefab, Vector3.zero);
        gameBall.transform.parent = paddle.transform;
        gameBall.transform.localPosition = new Vector3(0.0f, 1.0f, 0.0f);
        return gameBall;
    }

    /// <summary>
    /// Destroys a specific Ball.
    /// </summary>
    /// <param name="ball">The Ball component of the GameObject we want to destroy.</param>
    public void DestroyBall(Ball ball)
    {
        if (ball != null && gameBall == ball)
        {
            gameBall = null;
            DestroyGameObject(ball.gameObject);
        }
    }

    /// <summary>
    /// Creates a Paddle for the game.
    /// </summary>
    /// <param name="position">The position for the Paddle.</param>
    /// <returns>The Paddle component of the created GameObject.</returns>
    public Paddle CreatePaddle(Vector3 position)
    {
        gamePaddle = CreateObjectFromPrefab<Paddle>(paddlePrefab, position);
        return gamePaddle;
    }

    /// <summary>
    /// Destroys a specific Paddle.
    /// </summary>
    /// <param name="paddle">The Paddle component of the GameObject we want to destroy.</param>
    public void DestroyPaddle(Paddle paddle = null)
    {
        if (paddle == null)
        {
            paddle = gamePaddle;
        }

        if (paddle != null && gamePaddle == paddle)
        {
            gamePaddle = null;
            DestroyGameObject(paddle.gameObject);
        }
    }

    /// <summary>
    /// Creates a block for the game.
    /// </summary>
    /// <param name="blockID">The block id of the type of block we would like to create</param>
    /// <param name="position">The position of the block.</param>
    /// <returns>The Block component of the created Block component.</returns>
    public Block CreateBlock(char blockID, Vector3 position)
    {
        BlockInfo blockInfo = null;
        if (blockPrefabDictionary.TryGetValue(blockID, out blockInfo))
        {
            Block block = CreateObjectFromPrefab<Block>(greyBlockPrefab, position);
            gameBlocks.Add(block);
            block.spriteRenderer.color = blockInfo.color;
            return block;
        }
        return null;
    }

    /// <summary>
    /// Destroys a specific Block.
    /// </summary>
    /// <param name="block">The Block component of the GameObject we would like to destroy.</param>
    public void DestroyBlock(Block block)
    {
        if (block != null && gameBlocks.Contains(block))
        {
            block.transform.parent = null;
            gameBlocks.Remove(block);
            DestroyGameObject(block.gameObject);

            if (gameBlocks.Count == 0)
            {
                Toolbox.GameController.GoToNextLevel();
            }
        }
    }

    private T CreateObjectFromPrefab<T>(GameObject prefab, Vector3 position)
    {
        GameObject gameObject = poolManager.SpawnGameObject(prefab);
        return gameObject.GetComponent<T>();
    }

    private void DestroyGameObject(GameObject gameObject)
    {
        poolManager.RecycleGameObject(gameObject);
    }

    private void SetupBlockPrefabMap()
    {
        blockPrefabDictionary = new Dictionary<char, BlockInfo>();
        for (int i = 0; i < blocksInfo.Length; i++)
        {
            BlockInfo blockInfo = blocksInfo[i];
            blockPrefabDictionary[blockInfo.charID] = blockInfo;
        }
    }

    private void CreateBlockMatrix(string[] rowPatterns)
    {
        float localYPos = -(blockSize.y / 2.0f);
        for (int i=0; i < rowPatterns.Length; i++)
        {
            string rowPattern = rowPatterns[i];
            CreateBlockRow(rowPattern, localYPos);
            localYPos -= blockSize.y;
        }
    }

    private void CreateBlockRow(string rowPattern, float localYPos)
    {
        float localXPos = -((blockSize.x * (rowPattern.Length - 1)) / 2.0f);
        for (int i=0; i < rowPattern.Length; i++)
        {
            char charID = rowPattern[i];
            Block block = CreateBlock(charID, Vector3.zero);
            if (block)
            {
                block.transform.parent = blockContainer.transform;
                block.transform.localPosition = new Vector3(localXPos, localYPos, 0.0f);
            }
            localXPos += blockSize.x;
        }
    }

    private void DestroyAllBlocks()
    {
        if (gameBlocks != null)
        {
            Block[] blocksToDestroy = gameBlocks.ToArray();
            for (int i = 0; i < blocksToDestroy.Length; i++)
            {
                DestroyBlock(blocksToDestroy[i]);
            }
        }
    }

    private void CreateBlockContainer(Vector3 position)
    {
        blockContainer = new GameObject("Blocks");
        blockContainer.transform.position = position;
    }

    private void DestroyBlockContainer()
    {
        if (blockContainer != null)
        {
            GameObject.Destroy(blockContainer);
        }
    }

}
