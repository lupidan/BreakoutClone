using UnityEngine;

public interface Paddle {
    float LaunchSpeed { get; }
    PlayerInput PlayerInput { get; }
    Rect MoveArea { get; }
}
