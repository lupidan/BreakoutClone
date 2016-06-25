using UnityEngine;

public class KeyboardPlayerInput : PlayerInput {

    public float HorizontalSpeed = 7.0f;

    public KeyboardPlayerInput(float horizontalSpeed)
    {
        this.HorizontalSpeed = horizontalSpeed;
    }

    public float UpdateHorizontalPosition(float currentHorizontalPosition)
    {
        return currentHorizontalPosition + (HorizontalSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
    }

    public bool ActionButton
    {
        get
        {
            return Input.GetButtonDown("Jump");
        }
    }

}
