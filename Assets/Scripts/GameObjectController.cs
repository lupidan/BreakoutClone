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
    public BlockPrefabEntry[] blockPrefabs;
    private Dictionary<char, GameObject> blockPrefabMap;


    public BallComponent ball { get; private set; }
    public PaddleComponent paddle { get; private set; }
    public GameObject blockContainer { get; private set; }
    public List<BlockComponent> blocks { get; private set; }

    private Vector2 blockSize = Vector2.zero;

    void Awake()
    {
        SetupBlockPrefabMap();
    }

    public void CreateGame()
    {
        ball = CreateBall(new Vector3(0.0f, 0.0f, 0.0f));
        paddle = CreatePaddle(new Vector3(0.0f, -4.5f, 0.0f));

        blockContainer = new GameObject("Blocks");
        blocks = new List<BlockComponent>();
        float xPos = 0.0f;
        float width = 0.0f;
        float yPos = 0.0f;
        for (int i=0; i < 10; i++)
        {
            float rowWidth = 0.0f;
            float rowHeight = 0.0f;
            for (int j=0; j < 10; j++)
            {
                Vector3 position = new Vector3(xPos, yPos, 0.0f);
                BlockComponent block = CreateBlock('P', Vector3.zero);
                block.transform.parent = blockContainer.transform;
                block.transform.localPosition = new Vector3(xPos, yPos, 0.0f);
                blocks.Add(block);

                SpriteRenderer renderer = block.GetComponent<SpriteRenderer>();
                xPos += renderer.bounds.size.x;

                rowWidth += renderer.bounds.size.x;
                rowHeight = renderer.bounds.size.y;
            }
            width = Mathf.Max(width, rowWidth);
            yPos += rowHeight;
            xPos = 0.0f;
        }

        blockContainer.transform.position = new Vector3(-width / 2.0f, 0.0f, 0.0f);
    }

    public BallComponent CreateBall(Vector3 position)
    {
        return CreateObjectFromPrefab<BallComponent>(ballPrefab, position);
    }

    public PaddleComponent CreatePaddle(Vector3 position)
    {
        return CreateObjectFromPrefab<PaddleComponent>(paddlePrefab, position);
    }

    public BlockComponent CreateBlock(char blockID, Vector3 position)
    {
        GameObject prefab = null;
        if (blockPrefabMap.TryGetValue(blockID, out prefab))
        {
            return CreateObjectFromPrefab<BlockComponent>(prefab, position);
        }
        return null;
    }

    public T CreateObjectFromPrefab<T>(GameObject prefab, Vector3 position)
    {
        GameObject gameObject = GameObject.Instantiate(prefab, position, Quaternion.identity) as GameObject;
        return gameObject.GetComponent<T>();
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
}
