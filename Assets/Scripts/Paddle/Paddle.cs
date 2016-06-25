using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public float horizontalSpeed = 1.0f;
    public PlayerInput playerInput = new KeyboardPlayerInput(7.0f);
    private Rigidbody2D rigidbody2D = null;
    

	void Awake () {
        this.rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
	    if (playerInput != null)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = playerInput.UpdateHorizontalPosition(transform.position.x);
            transform.position = newPosition;
        }
	}
}
