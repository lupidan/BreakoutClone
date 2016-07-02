
using UnityEngine;

namespace Game
{
    [System.Serializable]
    public class DefaultPaddle : Paddle
    {
        [SerializeField]
        private float launchSpeed = 7.0f;
        [SerializeField]
        private Rect moveArea = new Rect(-5.0f, -5.0f, 10.0f, 10.0f);
        [SerializeField]
        private float bounceCorrectFactor = 0.4f;

        public Destroyable destroyable;
        

        public float LaunchSpeed { get { return launchSpeed; } }
        public Rect MoveArea { get { return moveArea; } }
        public float BounceCorrectFactor { get { return bounceCorrectFactor; } }

        public void CollidedWithBall(Ball ball)
        {
            //TODO: Calcular angulo y lanzar
            ball.Launch(45.0f, launchSpeed);
        }

        public void Destroy()
        {
            destroyable.Destroy();
        }

        //TODO: Movign

    }
}

