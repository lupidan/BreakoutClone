using UnityEngine;

/// <summary>
/// A GameOverGUI represents a Game User Interface visible when the game did finish.
/// </summary>
public class GameOverGUI : MonoBehaviour {

    /// <summary>
    /// Method called when the restart button was pressed.
    /// </summary>
	public void RestartButtonPressed()
    {
        Toolbox.GameController.StartGame();
    }

    /// <summary>
    /// Method called when the exit button was pressed.
    /// </summary>
    public void ExitButtonPressed()
    {

    }

}
