using UnityEngine;
using System.Collections;

namespace Game
{
    public class DefaultDeadZone : DeadZone {

        public GameController gameController;

        public void CollidedWithBall(Ball ball)
        {
            if (ball != null)
            {
                ball.Destroy();
            }

            if (gameController != null)
            {
                gameController.SubstractLife();
            }
        }

    }
}

