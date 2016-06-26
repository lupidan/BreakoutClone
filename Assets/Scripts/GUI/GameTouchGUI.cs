using UnityEngine;

public class GameTouchGUI : MonoBehaviour {

    public void LaunchButtonWasPressed()
    {
        Ball ball = Toolbox.GameObjectController.gameBall;
        Paddle paddle = Toolbox.GameObjectController.gamePaddle;
        if (ball != null && paddle != null && !ball.isOnPlay)
        {
            ball.Launch(paddle.launchSpeed);
        }
    }

    public void PauseButtonWasPressed()
    {
        GameController gameController = Toolbox.GameController;
        if (gameController.IsPaused)
        {
            gameController.ContinueGame();
        }
        else
        {
            gameController.PauseGame();
        }
    }
}
