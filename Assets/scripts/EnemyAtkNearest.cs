using UnityEngine;
using System.Collections;

public class EnemyAtkNearest : EnemyController {

	public AudioSource shotSfx;

	override protected void Fire () {
		Transform closestPlayer = FindClosestPlayer().transform;
		Vector3 ep = bulletSpawn.position;
		Vector3 pp = closestPlayer.position;
		//Debug.Log ("player is at " + pp);
		//Debug.Log ("enemy is at " + ep);
		//Vector3 vectorToTarget = -1*closestPlayer.position + bulletSpawn.position;
		//Debug.Log ("vector is " + vectorToTarget);
		float x = ep.x - pp.x;
		float y = ep.y - pp.y;
		//Debug.Log ("delta x: " + x);
		//Debug.Log ("delta y: " + y);
		float angle = (Mathf.Atan2(y, x) * Mathf.Rad2Deg)+90;
		//Debug.Log ("CALCULATED angle: " + angle);
		//Debug.Log ("enemy angle: " + transform.rotation);
		//bulletSpawn.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		bulletSpawn.rotation = Quaternion.Euler (0, 0,angle);
		//bulletSpawn.rotation = Quaternion.LookRotation (closestPlayer.position - bulletSpawn.position);
		Instantiate(enemyBullet, bulletSpawn.position, bulletSpawn.rotation);
		shotSfx.Play ();
	}
}
