using UnityEngine;
using System.Collections.Generic;

public class GameObjectController: MonoBehaviour {

    public GameObject ballPrefab;
    public GameObject paddlePrefab;
    public GameObject blockPrefab;

    public Ball CreateBall(Vector3 position)
    {
        return GameObject.Instantiate(ballPrefab, position, Quaternion.identity) as Ball;
    }

    public Paddle CreatePaddle(Vector3 position)
    {
        return GameObject.Instantiate(paddlePrefab, position, Quaternion.identity) as Paddle;
    }

    public Block CreateBlock(Vector3 position)
    {
        return GameObject.Instantiate(blockPrefab, position, Quaternion.identity) as Block;
    }

}
