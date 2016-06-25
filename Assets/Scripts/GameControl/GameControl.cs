
public delegate void GameControlEvent(GameControl gameControl);

public interface GameControl {

    event GameControlEvent OnScoreChanged;

    void AddScore(int score);
    void ResetScore();
    
}
