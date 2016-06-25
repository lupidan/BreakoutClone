using UnityEngine;

public class KeyboardPlayerInput : PlayerInput {

    public float HorizontalSpeed = 7.0f;

    public KeyboardPlayerInput(float horizontalSpeed)
    {
        this.HorizontalSpeed = horizontalSpeed;
    }

    public float UpdateHorizontalPosition(float currentHorizontalPosition)
    {
        float horizontalAxisMovement = Input.GetAxis("Horizontal");
        return currentHorizontalPosition + (HorizontalSpeed * horizontalAxisMovement * Time.deltaTime);
    }

    public bool ActionButton
    {
        get
        {
            return Input.GetButtonDown("Jump");
        }
    }

}
