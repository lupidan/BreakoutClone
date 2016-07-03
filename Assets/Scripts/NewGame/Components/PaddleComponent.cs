using UnityEngine;
using System.Collections;

namespace Game
{
    public class PaddleComponent : MonoBehaviour
    {
        public DefaultPaddle paddle = new DefaultPaddle();

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == BallComponent.Tag)
            {
                BallComponent ballComponent = collision.gameObject.GetComponent<BallComponent>();
                paddle.CollidedWithBall(ballComponent.ball);
            }
        }
    }
}

