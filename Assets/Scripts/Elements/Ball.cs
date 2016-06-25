using System;
using UnityEngine;

public delegate void BallEvent(Ball ball);

public class Ball : MonoBehaviour, PoolableComponent {

    public static string Tag = "Ball";

    private Rigidbody2D rigidBody2D = null;

    public bool isOnPlay { get; private set; }
    public event BallEvent OnBallDestroyed;

    public void Launch(float speed)
    {
        transform.parent = null;
        Vector3 direction = new Vector3(1.0f, 1.0f, 0.0f);
        rigidBody2D.velocity = direction.normalized * speed;
        isOnPlay = true;
    }

    void Awake()
    {
        this.rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Block.Tag)
        {
            Block block = collision.gameObject.GetComponent<Block>();
            Toolbox.GameObjectController.DestroyBlock(block);
        }
    }

    public void OnSpawn()
    {
        OnBallDestroyed = null;
        isOnPlay = false;
    }

    public void OnDespawn()
    {
        if (OnBallDestroyed != null)
        {
            OnBallDestroyed(this);
            OnBallDestroyed = null;
        }
    }
}
