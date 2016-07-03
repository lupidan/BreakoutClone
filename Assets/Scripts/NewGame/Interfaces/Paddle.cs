
using UnityEngine;

namespace Game
{
    public interface Paddle : Collisionable<Ball>
    {
        /// <summary>
        /// The speed the ball is bounced up when colliding with the paddle, or when it's first launched.
        /// </summary>
        float LaunchSpeed { get; }

        float BounceCorrectFactor { get; }

        /// <summary>
        /// The move area this component's GameObject is allowed to move in.
        /// </summary>
        Rect MoveArea { get; }
    }
}

