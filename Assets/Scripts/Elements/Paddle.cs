using UnityEngine;
using System.Collections;
using System;

public class Paddle: MonoBehaviour {

    public float launchSpeed = 10.0f;
    public Rect moveArea = new Rect(-5.0f, -5.0f, 10.0f, 10.0f);

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Ball.Tag)
        {
            Rigidbody2D rigidBody2D = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rigidBody2D != null)
            {
                Vector3 newDirection = collision.gameObject.transform.position - gameObject.transform.position;
                newDirection.z = 0.0f;
                rigidBody2D.velocity = newDirection.normalized * launchSpeed;
            }
        }
    }

}
