using UnityEngine;
using System.Collections;

public class BoundaryHandler : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Bullet")) {
			Destroy (other.gameObject);
		} else if (other.gameObject.CompareTag ("EnemyBullet")) {
			Destroy (other.gameObject);
		} else if (other.gameObject.CompareTag ("Enemy")) {
			Destroy (other.gameObject);
		} else {
			Debug.Log ("OTHER COLLISION");
		}
	}

}
