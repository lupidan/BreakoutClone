using UnityEngine;

namespace Game
{
    /// <summary>
    /// A Normal Ball component represents a Unity GameObject that manages a normal ball instance.
    /// </summary>
    public class NormalBallComponent : MonoBehaviour
    {
        /// <summary>
        /// The GameObject tag that all Ball elements should have.
        /// </summary>
        public static string Tag = "Ball";

        /// <summary>
        /// The ball instance being handled by this component.
        /// </summary>
        public NormalBall ball = new NormalBall();

        #region Monobehaviour
        void Awake()
        {
            ball.Positionable = new GameObjectPositioner(this.gameObject);
            ball.Speedable = new Rigidbody2DSpeeder(this.gameObject);
            ball.Eliminable = new GameObjectEliminator(this.gameObject);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == BlockComponent.Tag)
            {
                BlockComponent blockComponent = collision.gameObject.GetComponent<BlockComponent>();
                ball.CollidedWithBlock(blockComponent.block);
            }
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

