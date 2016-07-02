using UnityEngine;

namespace Game
{
    public class BallComponent : MonoBehaviour, Positionable, Destroyable, PoolableComponent 
    {

        /// <summary>
        /// The GameObject tag that all Ball elements should have.
        /// </summary>
        public static string Tag = "Ball";

        /// <summary>
        /// The ball instance being handled by this component.
        /// </summary>
        public DefaultBall ball = new DefaultBall();

        private Rigidbody2D rigidBody2D = null;

        #region Monobehaviour
        void Awake()
        {
            rigidBody2D = GetComponent<Rigidbody2D>();
            ball.destroyable = this;
            ball.positionable = this;
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
        #endregion

        #region Positionable implementation
        public Vector3 Position { get { return transform.position; } set { transform.position = value; } }
        public Vector2 Velocity { get { return rigidBody2D.velocity; } set { rigidBody2D.velocity = value; } }
        #endregion

        #region Destroyable implementation
        public void Destroy()
        {
            Destroy(gameObject);
        }
        #endregion

        #region PoolableObject implementation
        public void OnSpawn()
        {
            ball.Reset();
        }

        public void OnDespawn()
        {
            
        }
        #endregion
    }
}

