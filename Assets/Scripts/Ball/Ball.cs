
public delegate void BallEvent(Ball ball);

public interface Ball
{
    event BallEvent OnBallDestroyed;
}
