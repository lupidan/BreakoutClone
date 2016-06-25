using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public static string Tag = "Ball";

    private Rigidbody2D rigidBody2D = null;


    void Awake()
    {
        this.rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rigidBody2D.velocity = new Vector2(5.0f, 5.0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == BlockComponent.Tag)
        {
            DestroyObject(collision.gameObject);
        }
    }
}
