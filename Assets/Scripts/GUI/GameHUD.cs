using UnityEngine;
using UnityEngine.UI;

public class GameHUD : MonoBehaviour {

    public Text scoreText;
    public Text livesText;

    void OnEnable()
    {
        GameController gameController = Toolbox.GameController;
        gameController.OnScoreChanged += ScoreWasUpdated;
        gameController.OnLivesChanged += LivesWereUpdated;

        ScoreWasUpdated(gameController);
        LivesWereUpdated(gameController);
    }

    void OnDisable()
    {
        GameController gameController = Toolbox.GameController;
        gameController.OnScoreChanged -= ScoreWasUpdated;
        gameController.OnLivesChanged -= LivesWereUpdated;
    }

    void ScoreWasUpdated(GameController gameControl)
    {
        scoreText.text = gameControl.Score.ToString();
    }

    void LivesWereUpdated(GameController gameControl)
    {
        livesText.text = "x " + gameControl.Lives;
    }
}
