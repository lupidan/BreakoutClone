using UnityEngine;

public class KeyboardPlayerInput : PlayerInput {

    public float horizontalSpeed = 7.0f;

    public KeyboardPlayerInput(float horizontalSpeed)
    {
        this.horizontalSpeed = horizontalSpeed;
    }

    public float UpdateHorizontalPosition(float currentHorizontalPosition)
    {
        float horizontalAxisMovement = Input.GetAxisRaw("Horizontal");
        return currentHorizontalPosition + (horizontalSpeed * horizontalAxisMovement * Time.deltaTime);
    }

    public bool ActionButton
    {
        get
        {
            return Input.GetButtonDown("Jump");
        }
    }

}
