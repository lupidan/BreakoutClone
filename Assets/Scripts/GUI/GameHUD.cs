﻿///
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
using UnityEngine.UI;

/// <summary>
/// A GameHUD implements the behaviour of the Game Heads Up Display that contains all the game information.
/// </summary>
public class GameHUD : MonoBehaviour {

    /// <summary>
    /// The Text UI component displaying the score.
    /// </summary>
    public Text scoreText;

    /// <summary>
    /// The Text UI component displaying the amount of lives left.
    /// </summary>
    public Text livesText;

    /// <summary>
    /// The Text UI component displaying the level name.
    /// </summary>
    public Text levelNameText;

    void Start()
    {
        GameController gameController = Toolbox.GameController;
        gameController.OnScoreChanged += ScoreWasUpdated;
        gameController.OnLivesChanged += LivesWereUpdated;
        gameController.OnLevelChanged += LevelDidChange;

        RefreshHUD(gameController);
    }

    private void RefreshHUD(GameController gameController)
    {
        ScoreWasUpdated(gameController);
        LivesWereUpdated(gameController);
        LevelDidChange(gameController);
    }

    private void ScoreWasUpdated(GameController gameController)
    {
        scoreText.text = gameController.Score.ToString();
    }

    private void LivesWereUpdated(GameController gameController)
    {
        livesText.text = "x " + gameController.Lives;
    }

    private void LevelDidChange(GameController gameController)
    {
        string text = "";
        if (gameController.CurrentLevel != null)
        {
            text = gameController.CurrentLevel.levelName;
        }
        levelNameText.text = text;
    }
}
