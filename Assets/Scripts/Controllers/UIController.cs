using UnityEngine;

public class UIController : MonoBehaviour {

    public GameObject mainMenuGUI;
    public GameObject gameHUD;
    public GameObject gameTouchGUI;
    public GameObject gameOverGUI;
    public GameObject pauseMenuGUI;

    void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            Destroy(gameTouchGUI);
            gameTouchGUI = null;
        }

        Toolbox.GameController.OnStatusChanged += GameStatusChanged;
    }

    private void GameStatusChanged(GameController gameController)
    {
        mainMenuGUI.SetActive(gameController.State == GameController.Status.MainMenu);
        gameHUD.SetActive(gameController.State != GameController.Status.MainMenu);
        if (gameTouchGUI != null)
        {
            gameTouchGUI.SetActive(gameController.State == GameController.Status.InGame);
        }
        gameOverGUI.SetActive(gameController.State == GameController.Status.GameOver);
        pauseMenuGUI.SetActive(gameController.State == GameController.Status.Paused);
    }

}
