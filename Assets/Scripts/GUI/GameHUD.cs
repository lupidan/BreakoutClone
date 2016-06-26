using UnityEngine;
using UnityEngine.UI;

public class GameHUD : MonoBehaviour {

    public Text scoreText;
    public Text livesText;
    public Text levelNameText;

    void Start()
    {
        GameController gameController = Toolbox.GameController;
        gameController.OnScoreChanged += ScoreWasUpdated;
        gameController.OnLivesChanged += LivesWereUpdated;
        gameController.OnLevelStart += LevelDidStart;

        ScoreWasUpdated(gameController);
        LivesWereUpdated(gameController);
        LevelDidStart(gameController);
    }

    void ScoreWasUpdated(GameController gameControl)
    {
        scoreText.text = gameControl.Score.ToString();
    }

    void LivesWereUpdated(GameController gameControl)
    {
        livesText.text = "x " + gameControl.Lives;
    }

    void LevelDidStart(GameController gameControl)
    {
        string text = "";
        if (gameControl.CurrentLevel != null)
        {
            text = gameControl.CurrentLevel.levelName;
        }
        levelNameText.text = text;
    }
}
