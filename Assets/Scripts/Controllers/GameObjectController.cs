using UnityEngine;
using System.Collections.Generic;

public class GameObjectController: MonoBehaviour
{

    [System.Serializable]
    public class BlockPrefabEntry
    {
        public char charID;
        public GameObject blockPrefab;
    }

    public GameObject ballPrefab;
    public GameObject paddlePrefab;
    public Vector2 blockSize = new Vector2(0.64f, 0.32f);
    public BlockPrefabEntry[] blockPrefabs;
    private Dictionary<char, GameObject> blockPrefabMap;
    private GameObjectPoolManager poolManager;

    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }
    public GameObject blockContainer { get; private set; }
    public List<Block> blocks { get; private set; }

    void Awake()
    {
        SetupBlockPrefabMap();
        poolManager = new GameObjectPoolManager();
    }

    public void CreateGame()
    {
        CreatePaddle(new Vector3(0.0f, -4.5f, 0.0f));
        CreateBall();
        blockContainer = new GameObject("Blocks");
        blockContainer.transform.position = new Vector3(0.0f, 3.0f, 0.0f);
        blocks = new List<Block>();

        string[] patterns = { "BBBBBBBB", "RRRRRR", "YYYYYYYY", "PPPPPPP" };
        CreateBlockMatrix(patterns);
    }

    public Ball CreateBall()
    {
        ball = CreateObjectFromPrefab<Ball>(ballPrefab, Vector3.zero);
        ball.transform.parent = paddle.transform;
        ball.transform.localPosition = new Vector3(0.0f, 1.0f, 0.0f);
        ball.OnBallDestroyed += BallWasDestroyed;
        return ball;
    }

    public void DestroyBall(Ball ball)
    {
        if (this.ball == ball)
        {
            this.ball = null;
            DestroyGameObject(ball.gameObject);
        }
    }

    public Paddle CreatePaddle(Vector3 position)
    {
        paddle = CreateObjectFromPrefab<Paddle>(paddlePrefab, position);
        return paddle;
    }

    public void DestroyPaddle(Paddle paddle)
    {
        if (this.paddle == paddle)
        {
            this.paddle = null;
            DestroyGameObject(paddle.gameObject);
        }
    }

    public Block CreateBlock(char blockID, Vector3 position)
    {
        GameObject prefab = null;
        if (blockPrefabMap.TryGetValue(blockID, out prefab))
        {
            Block block = CreateObjectFromPrefab<Block>(prefab, position);
            blocks.Add(block);
            return block;
        }
        return null;
    }

    public void DestroyBlock(Block block)
    {
        if (blocks.Contains(block))
        {
            block.transform.parent = null;
            blocks.Remove(block);
            DestroyGameObject(block.gameObject);
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
        blockPrefabMap = new Dictionary<char, GameObject>();
        for (int i = 0; i < blockPrefabs.Length; i++)
        {
            BlockPrefabEntry entry = blockPrefabs[i];
            blockPrefabMap[entry.charID] = entry.blockPrefab;
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

                block.OnBlockDestroyed += BlockWasDestroyed;
            }
            localXPos += blockSize.x;
        }
    }

    private void BlockWasDestroyed(Block block)
    {
        Toolbox.GameController.AddScore(block.addedScore);
    }

    private void BallWasDestroyed(Ball ball)
    {
        Toolbox.GameController.SubstractLife();
        CreateBall();
    }
}
