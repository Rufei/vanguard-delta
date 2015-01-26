using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	public int playerNumber = 0;
	public Boundary boundary;
	public Transform bulletSpawn;
	public GameObject hitExplosion;

	public float rotation = 90.0f;
	public float speed = 250.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	// Called per physics update
	void FixedUpdate() {
		
		// Handle player movement
		float xAxis = Input.GetAxis ("L_XAxis_"+playerNumber);
		float yAxis = Input.GetAxis ("L_YAxis_"+playerNumber);
		
		float forwardX = Time.deltaTime * xAxis * speed;
		float forwardY = Time.deltaTime * -yAxis * speed;
		
		float newX = transform.position.x +forwardX;
		float newY = transform.position.y +forwardY;
		
		
		// Update position
		transform.rotation = Quaternion.AngleAxis(rotation-90, Vector3.forward);
		
		transform.position = (new Vector3(
			Mathf.Clamp(newX, boundary.xMin, boundary.xMax), 
			Mathf.Clamp(newY, boundary.yMin, boundary.yMax),
			transform.position.z));

	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("EnemyBullet")) {
			//Debug.Log ("I've been hit because of " + other);
			Instantiate(hitExplosion, transform.position, Quaternion.identity);
			GameObject[] gameController = GameObject.FindGameObjectsWithTag("GameController");
			gameController[0].GetComponent<GameController>().AddDeath();
			Destroy (other.gameObject);
		}
	}


}
