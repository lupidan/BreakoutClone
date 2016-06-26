using UnityEngine;

public delegate void GameControlEvent(GameController gameController);

public class GameController : MonoBehaviour {

    public enum Status
    {
        MainMenu,
        InGame,
        Paused,
        GameOver
    }

    public int initialNumberOfLives = 3;

    public int Score { get; private set; }
    public int Lives { get; private set; }
    public int CurrentLevelIndex { get; private set; }
    public Status status { get; private set; }
    public LevelInfo CurrentLevel { get; private set; }

    public event GameControlEvent OnScoreChanged;
    public event GameControlEvent OnLivesChanged;
    public event GameControlEvent OnStatusChanged;
    public event GameControlEvent OnLevelChanged;

    public LevelInfo[] levels;

    void Start () {
        SetGameStatus(Status.MainMenu);
    }

    /// <summary>
    /// Adds points for the player.
    /// </summary>
    /// <param name="score">The amount of points to add</param>
    public void AddPoints(int points)
    {
        if (points > 0)
        {
            Score += points;
            NotifyScoreChange();
        }
    }

    /// <summary>
    /// Resets the score back to zero.
    /// </summary>
    public void ResetScore()
    {
        Score = 0;
        NotifyScoreChange();
    }

    /// <summary>
    /// Substracts one life
    /// </summary>
    public void SubstractLife()
    {
        if (Lives > 0)
        {
            Lives -= 1;
            NotifyLivesChange();
            Toolbox.GameObjectController.CreateBall();
        }
        else
        {
            Toolbox.GameObjectController.DestroyPaddle();
            FinishGame();
        }
    }

    /// <summary>
    /// Resets the amount of lives
    /// </summary>
    public void ResetLives()
    {
        Lives = initialNumberOfLives;
        NotifyLivesChange();
    }

    /// <summary>
    /// Starts the game.
    /// </summary>
    public void StartGame()
    {
        if (status == Status.MainMenu || status == Status.GameOver)
        {
            ResetScore();
            ResetLives();
            StartLevel(0);
            SetGameStatus(Status.InGame);
        }
    }

    /// <summary>
    /// Goes to the next level.
    /// </summary>
    public void GoToNextLevel()
    {
        StartLevel(CurrentLevelIndex + 1);
    }
    
    /// <summary>
    /// Pauses the game.
    /// </summary>
    public void PauseGame()
    {
        if (status == Status.InGame)
        {
            Time.timeScale = 0.0f;
            SetGameStatus(Status.Paused);
        }
    }

    /// <summary>
    /// Continues the game.
    /// </summary>
    public void ContinueGame()
    {
        if (status == Status.Paused)
        {
            Time.timeScale = 1.0f;
            SetGameStatus(Status.InGame);
        }
    }

    /// <summary>
    /// Finishes the game
    /// </summary>
    public void FinishGame()
    {
        if (status == Status.InGame)
        {
            SetGameStatus(Status.GameOver);
        }
    }

    private void StartLevel(int level)
    {
        SetCurrentLevelIndex(level);
        Toolbox.GameObjectController.DestroyGame();
        Toolbox.GameObjectController.CreateGame(CurrentLevel.blocks);
    }

    private void SetGameStatus(Status status)
    {
        this.status = status;
        if (OnStatusChanged != null)
        {
            OnStatusChanged(this);
        }
    }

    private void SetCurrentLevelIndex(int levelIndex)
    {
        levelIndex = Mathf.Clamp(levelIndex, 0, levels.Length - 1);
        CurrentLevelIndex = levelIndex;
        CurrentLevel = levels[levelIndex];

        if (OnLevelChanged != null)
        {
            OnLevelChanged(this);
        }
    }

    private void NotifyScoreChange()
    {
        if (OnScoreChanged != null)
        {
            OnScoreChanged(this);
        }
    }

    public void NotifyLivesChange()
    {
        if (OnLivesChanged != null)
        {
            OnLivesChanged(this);
        }
    }
}
