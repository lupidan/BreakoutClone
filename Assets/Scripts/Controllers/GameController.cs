using UnityEngine;

public delegate void GameControlEvent(GameController gameControl);

public class GameController : MonoBehaviour {

    public int initialNumberOfLives;

    public int Score { get; private set; }
    public int Lives { get; private set; }

    public event GameControlEvent OnScoreChanged;
    public event GameControlEvent OnLivesChanged;
    public event GameControlEvent OnGameStart;
    public event GameControlEvent OnGamePause;
    public event GameControlEvent OnGameContinue;

    void Start () {
        StartGame();
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

    public void StartGame()
    {
        string level = "   RRRRR    \n  RRRRRRRRR \n  BBBMMBM   \n BMBMMMBMMM \n BMBBMMMBMMM\n BBMMMMBBBB \n   MMMMMMM  \n  RRbRRR    \n RRRbRRbRRR \nRRRRbbbbRRRR\nWWRbYbbYbRWW\nWWbbbbbbbbWW\n  bbb  bbb  \n BBB    BBB \nBBBB    BBBB";
        Toolbox.GameObjectController.CreateGame(level);
        ResetScore();
        ResetLives();

        if (OnGameStart != null)
        {
            OnGameStart(this);
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
