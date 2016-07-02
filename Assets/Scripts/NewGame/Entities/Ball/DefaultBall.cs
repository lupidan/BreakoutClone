using UnityEngine;

namespace Game
{
    [System.Serializable]
    public class DefaultBall : Ball
    {
        public GameController gameController;
        public Destroyable destroyable;
        public Positionable positionable;

        [SerializeField]
        private bool isOnPlay = false;

        public bool IsOnPlay { get { return isOnPlay; } }

        public void Reset()
        {
            isOnPlay = false;
            if (positionable != null)
            {
                positionable.Velocity = Vector2.zero;
            }
        }

        public void Launch(float angle, float speed)
        {
            isOnPlay = true;
            if (positionable != null)
            {
                float radians = angle * Mathf.Deg2Rad;
                Vector3 directionVector = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0.0f).normalized;
                positionable.Velocity = directionVector * speed;
            }
        }

        public void CollidedWithBlock(Block block)
        {
            if ((block != null) && (gameController != null))
            {
                block.Destroy();
                gameController.AddPoints(block.Points);
                if (gameController.AreAllBlocksDestroyed)
                {
                    gameController.GoToNextLevel();
                }
            }
        }

        public void Destroy()
        {
            if (destroyable != null)
            {
                destroyable.Destroy();
            }
        }

    }
}

