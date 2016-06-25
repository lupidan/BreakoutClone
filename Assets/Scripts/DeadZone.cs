using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == BallComponent.Tag)
        {
            DestroyObject(collider.gameObject);
        }
    }

}
