using UnityEngine;
using System.Collections;
using System;

public class GameControlComponent : MonoBehaviour, GameControl {

    public int Score { get; private set; }

    public event GameControlEvent OnScoreChanged;

    void Start () {
        ResetScore();
    }

    public void AddScore(int score)
    {
        if (score > 0)
        {
            Score += score;
            OnScoreChanged(this);
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
}
