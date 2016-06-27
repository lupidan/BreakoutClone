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
/// A delegate type defining an event that happens on a GameController
/// </summary>
/// <param name="gameController">The game controller where the event happened.</param>
public delegate void GameControlEvent(GameController gameController);

/// <summary>
/// A GameController instance controls the game status. Controls the score and lives, and informs observers about changes.
/// </summary>
public class GameController : MonoBehaviour {

    /// <summary>
    /// The status of the game.
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// On the main menu.
        /// </summary>
        MainMenu,

        /// <summary>
        /// Playing the game.
        /// </summary>
        InGame,

        /// <summary>
        /// The game is paused.
        /// </summary>
        Paused,

        /// <summary>
        /// GameOver screen.
        /// </summary>
        GameOver
    }

    /// <summary>
    /// Method called when the score changes.
    /// </summary>
    public event GameControlEvent OnScoreChanged;

    /// <summary>
    /// Method called when the number of lives changes.
    /// </summary>
    public event GameControlEvent OnLivesChanged;

    /// <summary>
    /// Method called when the game status changes.
    /// </summary>
    public event GameControlEvent OnStatusChanged;

    /// <summary>
    /// Method called when the level changes.
    /// </summary>
    public event GameControlEvent OnLevelChanged;

    /// <summary>
    /// The initial number of lives.
    /// </summary>
    public int initialNumberOfLives = 5;

    /// <summary>
    /// The current player score.
    /// </summary>
    public int Score { get; private set; }

    /// <summary>
    /// The amount of lives left.
    /// </summary>
    public int Lives { get; private set; }

    /// <summary>
    /// The current level index.
    /// </summary>
    public int CurrentLevelIndex { get; private set; }

    /// <summary>
    /// The current level.
    /// </summary>
    public LevelInfo CurrentLevel { get; private set; }

    /// <summary>
    /// The current game status.
    /// </summary>
    public Status State { get; private set; }

    /// <summary>
    /// Array of levels to go trough.
    /// </summary>
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
        if (State == Status.MainMenu || State == Status.GameOver)
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
        int nextLevel = (CurrentLevelIndex + 1) % levels.Length;
        StartLevel(nextLevel);
    }

    /// <summary>
    /// Goes to the main menu.
    /// </summary>
    public void GoToMainMenu()
    {
        SetGameStatus(Status.MainMenu);
        Toolbox.GameObjectController.DestroyGame();
    }
    
    /// <summary>
    /// Pauses the game.
    /// </summary>
    public void PauseGame()
    {
        if (State == Status.InGame)
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
        if (State == Status.Paused)
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
        if (State == Status.InGame)
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

    private void SetGameStatus(Status state)
    {
        this.State = state;
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
