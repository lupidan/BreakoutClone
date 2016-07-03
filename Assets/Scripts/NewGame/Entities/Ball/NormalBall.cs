using UnityEngine;

namespace Game
{
    /// <summary>
    /// A normal ball for the game, no special characteristics.
    /// </summary>
    [System.Serializable]
    public class NormalBall : Ball
    {
        [SerializeField]
        private bool isOnPlay = false;

        #region Ball implementation
        public bool IsOnPlay { get { return isOnPlay; } }
        public GameController GameController { get; set; }
        public Positionable Positionable { get; set; }
        public Eliminable Eliminable { get; set; }
        public Speedable Speedable { get; set; }

        public void Reset()
        {
            isOnPlay = false;
            if (Speedable != null)
            {
                Speedable.Velocity = Vector2.zero;
            }
        }

        public void Launch(float angle, float speed)
        {
            isOnPlay = true;
            if (Speedable != null)
            {
                float radians = angle * Mathf.Deg2Rad;
                Vector3 directionVector = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0.0f).normalized;
                Speedable.Velocity = directionVector * speed;
            }
        }

        public void CollidedWithBlock(Block block)
        {
            if ((block != null) && (GameController != null))
            {
                block.Eliminate();
                GameController.AddPoints(block.Points);
                if (GameController.AreAllBlocksDestroyed)
                {
                    GameController.GoToNextLevel();
                }
            }
        }
        #endregion

    }
}

