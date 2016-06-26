using UnityEngine;

/// <summary>
/// A PauseMenuGUI represents a Game User Interface visible on the pause menu.
/// </summary>
public class PauseMenuGUI : MonoBehaviour {

    /// <summary>
    /// Method called when the resume button is pressed.
    /// </summary>
    public void ResumeButtonPressed()
    {
        Toolbox.GameController.ContinueGame();
    }
	
}
