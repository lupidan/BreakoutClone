using UnityEngine;

namespace Game
{
    public class BallComponent : MonoBehaviour, PoolableComponent
    {
        /// <summary>
        /// The GameObject tag that all Ball elements should have.
        /// </summary>
        public static string Tag = "Ball";

        public DefaultBall ball = new DefaultBall();

        private Rigidbody2D rigidBody2D = null;

        void Awake()
        {
            this.rigidBody2D = GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == BlockComponent.Tag)
            {
                BlockComponent blockComponent = collision.gameObject.GetComponent<BlockComponent>();
                DefaultBlock block = blockComponent.block;
                ball.CollidedWithBlock(block);
            }
        }

        // PoolableObject implementation
        public void OnSpawn()
        {
            ball.Reset();
        }

        public void OnDespawn()
        {
            
        }
    }
}

