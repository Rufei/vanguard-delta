using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public abstract class EnemyController : MonoBehaviour {

	public Boundary boundary;
	public GameObject enemyBullet;
	public GameObject hitExplosion;
	public GameObject explosion;

	public float hp = 1;
	public float fireRate;
	public float burstSize;
	public float burstDelay;

	public float rotation = 90.0f;
	public float speed = 150.0f;
	
	protected GameObject player1;
	protected GameObject player2;
	protected GameObject player3;

	protected Transform bulletSpawn;

	protected float nextFire;
	protected int shotNum = 1;

	// Use this for initialization
	void Start () {
		bulletSpawn = this.transform.Find ("BulletSpawn");
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > nextFire) {
			Fire ();
			if (shotNum < burstSize) {
				// In a burst
				nextFire = Time.time + fireRate;
				shotNum++;
			} else {
				// Out of burst, incur burstDelay
				nextFire = Time.time + fireRate + burstDelay;
				shotNum = 0;
			}
		}
	}

	void FixedUpdate () {
		float forwardX = Time.deltaTime * 0 * speed;
		float forwardY = Time.deltaTime * -1 * speed;
		
		float newX = transform.position.x +forwardX;
		float newY = transform.position.y +forwardY;
		
		transform.rotation = Quaternion.AngleAxis(rotation-90, Vector3.forward);
		transform.position = (new Vector3(
			Mathf.Clamp(newX, boundary.xMin, boundary.xMax), 
			Mathf.Clamp(newY, boundary.yMin, boundary.yMax),
			transform.position.z));
	}
	
	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.CompareTag ("Bullet")) {
			Instantiate(hitExplosion, transform.position, Quaternion.identity);
			hp--;
			Destroy (other.gameObject);
			if (hp <= 0) {
				//Debug.Log ("I'm dead because of " + other);
				//Debug.Log ("I was at (" + transform.position.x + "," + transform.position.y + "," + transform.position.z + ")");
				Instantiate(explosion, transform.position, Quaternion.identity);
				GameObject[] gameController = GameObject.FindGameObjectsWithTag("GameController");
				gameController[0].GetComponent<GameController>().AddKill();
				Destroy (this.gameObject);
			}
		}

	}

	protected abstract void Fire ();
	
	protected GameObject FindClosestPlayer() {
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Player");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = bulletSpawn.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}

}
