using UnityEngine;
using System.Collections;

public class PlayerInputController : MonoBehaviour {

    public PlayerInput playerInput = new KeyboardPlayerInput(7.0f);

    void Update()
    {
        if (playerInput != null)
        {
            Paddle paddle = Toolbox.GameObjectController.gamePaddle;
            if (paddle != null)
            {
                UpdatePaddlePosition(paddle, playerInput);

                Ball ball = Toolbox.GameObjectController.gameBall;
                if (playerInput.ActionButton && ball != null && !ball.isOnPlay)
                {
                    ball.Launch(paddle.launchSpeed);
                }
            }
            
            if (playerInput.PauseButton)
            {

            }
        }
    }

    private void UpdatePaddlePosition(Paddle paddle, PlayerInput playerInput)
    {
        Vector3 newPosition = paddle.transform.position;
        newPosition.x = playerInput.UpdateHorizontalPosition(paddle.transform.position.x);
        paddle.transform.position = paddle.moveArea.ClampPosition(newPosition);
    }
}
