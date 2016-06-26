using UnityEngine;

/// <summary>
/// A GameTouchGUI contains buttons to execute Launch and Pause the game for touch interfaces.
/// </summary>
public class GameTouchGUI : MonoBehaviour {

    /// <summary>
    /// Method called when the launch button is pressed.
    /// </summary>
    public void LaunchButtonWasPressed()
    {
        Ball ball = Toolbox.GameObjectController.gameBall;
        Paddle paddle = Toolbox.GameObjectController.gamePaddle;
        if (ball != null && paddle != null && !ball.isOnPlay)
        {
            ball.Launch(paddle.launchSpeed);
        }
    }

    /// <summary>
    /// Method called when the pause button is pressed.
    /// </summary>
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
