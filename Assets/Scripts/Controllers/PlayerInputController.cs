using UnityEngine;


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
                if (playerInput.ActionButtonPressed && ball != null && !ball.isOnPlay)
                {
                    ball.Launch(paddle.launchSpeed);
                }
            }
            
            if (playerInput.PauseButtonPressed)
            {
                Toolbox.GameController.PauseGame();
            }
        }
    }

    private void UpdatePaddlePosition(Paddle paddle, PlayerInput playerInput)
    {
        Vector3 newPosition = paddle.transform.position;
        newPosition.x = playerInput.UpdateXPosition(paddle.transform.position.x);
        paddle.transform.position = paddle.moveArea.ClampPosition(newPosition);
    }
}
