using UnityEngine;
using System.Collections;

public class EnemyWallAtk : EnemyController {
	
	public AudioSource shotSfx;
	public float spreadInterval = 4.0f;

	override protected void Fire () {
		Transform closestPlayer = FindClosestPlayer().transform;
		Vector3 ep = bulletSpawn.position;
		Vector3 pp = closestPlayer.position;
		float x = ep.x - pp.x;
		float y = ep.y - pp.y;

		// Shotgun spread
		for (float f = -60.0f; f < 60.0f; f += spreadInterval) {
			float angle = (Mathf.Atan2(y, x) * Mathf.Rad2Deg) + 90 + f;
			bulletSpawn.rotation = Quaternion.Euler (0, 0, angle);
			Instantiate(enemyBullet, bulletSpawn.position, bulletSpawn.rotation);
			shotSfx.Play ();
		}
	}

}
