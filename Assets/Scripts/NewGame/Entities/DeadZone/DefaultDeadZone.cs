using UnityEngine;
using System.Collections;

namespace Game
{
    public class DefaultDeadZone : DeadZone {

        public GameController gameController;

        public void CollidedWithBall(Ball ball)
        {
            ball.Destroy();
            gameController.SubstractLife();
        }

    }
}

