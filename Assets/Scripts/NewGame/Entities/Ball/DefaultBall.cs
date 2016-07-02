using UnityEngine;

namespace Game
{
    [System.Serializable]
    public class DefaultBall : Ball
    {
        public GameController gameController;
        public GameEntity gameEntity;
        [SerializeField]
        private bool isOnPlay = false;

        public bool IsOnPlay { get { return isOnPlay; } }

        public void Reset()
        {
            isOnPlay = false;
        }

        public void Launch(float angle, float speed)
        {
            float radians = angle * Mathf.Deg2Rad;
            Vector3 directionVector = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0.0f).normalized;
            gameEntity.Velocity = directionVector * speed;
        }

        public void CollidedWithBlock(Block block)
        {
            gameController.AddPoints(block.Points);
            block.Destroy();
            if (gameController.AreAllBlocksDestroyed)
            {
                gameController.GoToNextLevel();
            }
        }

        public void Destroy()
        {
            gameEntity.Destroy();
        }

    }
}

