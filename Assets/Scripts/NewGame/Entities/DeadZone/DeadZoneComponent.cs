using UnityEngine;
using System.Collections;

namespace Game
{
    /// <summary>
    /// A DeadZone component defines a behaviour for a Ball GameObjects destruction area.
    /// It requires one or more Collider2D masks set as triggers to interact with Ball elements.
    /// </summary>
    public class DeadZoneComponent : MonoBehaviour
    {
        public DefaultDeadZone deadZone = new DefaultDeadZone();

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == BallComponent.Tag)
            {
                BallComponent ballComponent = collider.gameObject.GetComponent<BallComponent>();
                deadZone.CollidedWithBall(ballComponent.ball);
            }
        }

    }
}

