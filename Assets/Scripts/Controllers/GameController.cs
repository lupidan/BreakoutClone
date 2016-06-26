using UnityEngine;

public delegate void GameControlEvent(GameController gameControl);

public class GameController : MonoBehaviour {

    public int initialNumberOfLives;

    public int Score { get; private set; }
    public int Lives { get; private set; }
    public int CurrentLevelIndex { get; private set; }
    public LevelInfo CurrentLevel { get; private set; }

    public event GameControlEvent OnScoreChanged;
    public event GameControlEvent OnLivesChanged;
    public event GameControlEvent OnLevelStart;
    public event GameControlEvent OnGamePause;
    public event GameControlEvent OnGameContinue;

    
    public LevelInfo[] levels;

    void Start () {
        StartLevel(0);

        Toolbox.GameObjectController.OnNoMoreBlocks += DestroyedAllBlocks;
    }

    private void DestroyedAllBlocks(GameObjectController controller)
    {
        StartLevel(CurrentLevelIndex + 1);
    }

    public void AddScore(int score)
    {
        if (score > 0)
        {
            Score += score;
            if (OnScoreChanged != null)
            {
                OnScoreChanged(this);
            }
        }
    }

    public void ResetScore()
    {
        Score = 0;
        if (OnScoreChanged != null)
        {
            OnScoreChanged(this);
        }
    }

    public void SubstractLife()
    {
        Lives -= 1;
        if (OnLivesChanged != null)
        {
            OnLivesChanged(this);
        }
    }

    public void ResetLives()
    {
        Lives = initialNumberOfLives;
        if (OnLivesChanged != null)
        {
            OnLivesChanged(this);
        }
    }

    public void StartLevel(int level)
    {
        level = Mathf.Clamp(level, 0, levels.Length - 1);
        CurrentLevelIndex = level;
        CurrentLevel = levels[level];

        Toolbox.GameObjectController.DestroyGame();
        Toolbox.GameObjectController.CreateGame(CurrentLevel.blocks);
        ResetScore();
        ResetLives();

        if (OnLevelStart != null)
        {
            OnLevelStart(this);
        }
    }

    public void PauseGame()
    {
        if (OnGamePause != null)
        {
            OnGamePause(this);
        }
    }

    public void ContinueGame()
    {
        if (OnGameContinue != null)
        {
            OnGameContinue(this);
        }
    }
}
