using UnityEngine;
using System.Collections;

public class ShieldController : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("EnemyBullet")) {
			Destroy (other.gameObject);
		}
	}
}
