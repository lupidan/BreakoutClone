
namespace Game
{
    /// <summary>
    /// A Ball represents a ball object in the game. It contains methods to be launched and reset, as well as providing methods for collision with other elements.
    /// </summary>
    public interface Ball
    {
        /// <summary>
        /// The game controller to communicate with.
        /// </summary>
        GameController GameController { get; }

        /// <summary>
        /// The object able to position the ball on the game scene.
        /// </summary>
        Positionable Positionable { get; }

        /// <summary>
        /// The object able to eliminate the ball from the game scene.
        /// </summary>
        Eliminable Eliminable { get; }

        /// <summary>
        /// The object able to apply speed to the ball in the game scene.
        /// </summary>
        Speedable Speedable { get; }

        /// <summary>
        /// Whether the ball is being played or not.
        /// </summary>
        bool IsOnPlay { get; }

        /// <summary>
        /// Resets the ball status.
        /// </summary>
        void Reset();

        /// <summary>
        /// Launches the ball in a specific angle at a specific speed from it current position.
        /// </summary>
        /// <param name="angle">The angle to launch the ball.</param>
        /// <param name="speed">The speed to launch the ball.</param>
        void Launch(float angle, float speed);

        /// <summary>
        /// Method called when the ball collides with a block.
        /// </summary>
        /// <param name="block">The block that collided with the ball.</param>
        void CollidedWithBlock(Block block);

    }
}

