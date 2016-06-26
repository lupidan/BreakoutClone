using UnityEngine;

/// <summary>
/// A MainMenuGUI represents a Game User Interface visible on the main menu.
/// </summary>
public class MainMenuGUI : MonoBehaviour {

    /// <summary>
    /// Method called when the play button was pressed.
    /// </summary>
	public void PlayButtonPressed()
    {
        Toolbox.GameController.StartGame();
    }
}
