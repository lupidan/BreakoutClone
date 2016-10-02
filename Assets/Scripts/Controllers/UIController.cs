///
/// The MIT License(MIT)
/// 
/// Copyright(c) 2016 Daniel Lupiañez Casares
/// 
/// Permission is hereby granted, free of charge, to any person obtaining a copy
/// of this software and associated documentation files (the "Software"), to deal
/// in the Software without restriction, including without limitation the rights
/// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the Software is
/// furnished to do so, subject to the following conditions:
/// 
/// The above copyright notice and this permission notice shall be included in all
/// copies or substantial portions of the Software.
/// 
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
/// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
/// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
/// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
/// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
/// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
/// SOFTWARE.
///

using UnityEngine;

/// <summary>
/// A UIController listens to a GameController and updates the menu components visibility.
/// </summary>
public class UIController : MonoBehaviour {

    /// <summary>
    /// GameObject containing the main menu.
    /// </summary>
    public GameObject mainMenuGUI;

    /// <summary>
    /// GameObject containing the game HUD
    /// </summary>
    public GameObject gameHUD;

    /// <summary>
    /// GameObject containing the in-game touch menu.
    /// </summary>
    public GameObject gameTouchGUI;

    /// <summary>
    /// GameObject containing the game over menu.
    /// </summary>
    public GameObject gameOverGUI;

    /// <summary>
    /// GameObject containing the pause menu.
    /// </summary>
    public GameObject pauseMenuGUI;

    void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            Destroy(gameTouchGUI);
            gameTouchGUI = null;
        }

//        Toolbox.GameController.OnStatusChanged += GameStatusChanged;
    }

//    private void GameStatusChanged(GameController gameController)
//    {
//        mainMenuGUI.SetActive(gameController.State == GameController.Status.MainMenu);
//        gameHUD.SetActive(gameController.State != GameController.Status.MainMenu);
//        if (gameTouchGUI != null)
//        {
//            gameTouchGUI.SetActive(gameController.State == GameController.Status.InGame);
//        }
//        gameOverGUI.SetActive(gameController.State == GameController.Status.GameOver);
//        pauseMenuGUI.SetActive(gameController.State == GameController.Status.Paused);
//    }

}
