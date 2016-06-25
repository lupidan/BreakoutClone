using UnityEngine;
using System.Collections;
using System;

public class Paddle: MonoBehaviour {

    public float launchSpeed = 10.0f;
    public PlayerInput playerInput = new KeyboardPlayerInput(7.0f);
    public Rect moveArea = new Rect(-5.0f, -5.0f, 10.0f, 10.0f);

    void Update()
    {
        if (playerInput != null)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = playerInput.UpdateHorizontalPosition(transform.position.x);
            transform.position = moveArea.ClampPosition(newPosition);

            Ball ball = Toolbox.GameObjectController.ball;
            if (playerInput.ActionButton && ball != null && !ball.isOnPlay)
            {
                ball.Launch(launchSpeed);
            }
        }
    }

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
