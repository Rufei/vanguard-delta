using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public AudioSource mainBgm;
	public AudioSource mainBgmFiltered;

	public GameObject enemyBasicAtkNearest;
	public GameObject enemyBasicAtkWave;
	
	public GameObject enemyBlueAtkNearest;
	public GameObject enemyBlueAtkWave;
	public GameObject enemyRedAtkNearest;
	public GameObject enemyRedAtkWave;
	public GameObject enemyYellowAtkNearest;
	public GameObject enemyYellowAtkWave;

	public float startDelay;
	public float spawnDelay;
	public float waveDelay;
	
	private GameObject player1;
	private GameObject player2;
	private GameObject player3;

	private GameObject go;

	private int kills = 0;
	private int deaths = 0;

	private bool isTextOn = false;

	public void AddKill() {
		kills++;
	}

	public void AddDeath() {
		deaths++;
	}

	// Use this for initialization
	void Start () {
		mainBgm.playOnAwake = true;
		mainBgm.volume = 0.35f;
		mainBgmFiltered.mute = true;
		mainBgmFiltered.playOnAwake = true;
		mainBgmFiltered.volume = 0.35f;

		mainBgm.Play ();
		mainBgmFiltered.Play ();
		StartCoroutine (SpawnWaves ());
	}

	void Update() {
		if (Input.GetKeyDown("escape")) {
			Application.Quit();
		}
	}

	void OnGUI() {
		if (isTextOn) {
			GUI.Label(new Rect(Screen.width/2 - 30f, Screen.height/2 - 10f, 100f, 40f), "Kills: " + kills + "\nDeaths: " + deaths);
		}
	}
	
	IEnumerator SpawnWaves () {
		/*
		//Debug.Log ("Waiting for " + startDelay + " seconds...");
		yield return new WaitForSeconds (startDelay);
		//Debug.Log ("Spawning waves!");
		while (true) {
			for (int i = 0; i < 20; i++) {
				float x = Random.Range (-260, 260);
				float y = 500;
				float z = 0;
				Debug.Log ("Spawning at: (" + x + "," + y + "," + z + ")");
				Vector3 spawnPosition = new Vector3 (x, y, z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (enemyBasicAtkWave, spawnPosition, spawnRotation);
				//Instantiate (enemyBasicAtkNearest, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnDelay);
			}
			yield return new WaitForSeconds (waveDelay);
		}
		*/

		//Debug.Log ("Waiting for " + startDelay + " seconds...");
		yield return new WaitForSeconds (3.5f);
		//Debug.Log ("Spawning waves!");

		float x = 0f;
		float y = 0f;
		float z = 0f;

		// Wave 0
		x = 0;
		y = 500;
		z = 0;
		Vector3 p = new Vector3 (x, y, z);
		Quaternion r = Quaternion.identity;
		Instantiate (enemyBasicAtkNearest, p, r);
		yield return new WaitForSeconds (4.5f);

		for (int wave = 1; wave <= 13; wave++) {
			// Individual wave, 8 seconds
			for (int i = 0; i < 4; i++) {
				x = Random.Range (-260, 260);
				y = 500;
				z = 0;
				Vector3 spawnPosition = new Vector3 (x, y, z);
				Quaternion spawnRotation = Quaternion.identity;
				spawnShip (wave, false, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (0.25f);
			}
			yield return new WaitForSeconds (0.5f);
			
			x = -140f;
			for (int j = 0; j < 5; j++) {
				x += j * 3;
				y = 500;
				z = 0;
				Vector3 spawnPosition = new Vector3 (x, y, z);
				Quaternion spawnRotation = Quaternion.identity;
				spawnShip (wave, false, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (0.2f);
			}
			yield return new WaitForSeconds (0.5f);
			x = 140f;
			for (int j = 0; j < 5; j++) {
				x -= j * 3;
				y = 500;
				z = 0;
				Vector3 spawnPosition = new Vector3 (x, y, z);
				Quaternion spawnRotation = Quaternion.identity;
				spawnShip (wave, false, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (0.2f);
			}
			yield return new WaitForSeconds (1.5f);
			x = 0;
			y = 500;
			z = 0;
			Vector3 pos = new Vector3 (x, y, z);
			Quaternion rot = Quaternion.identity;
			spawnShip (wave, true, pos, rot);
			//Instantiate (enemyBasicAtkNearest, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (2.5f);
		}
		yield return new WaitForSeconds (waveDelay);

		printScores ();
	}

	private void spawnShip(int wave, bool big, Vector3 position, Quaternion rotation) {
		if (wave > 5) {
			int num = Random.Range (1, 4);
			switch (num) {
			case 1:
				Instantiate (big ? enemyBlueAtkWave : enemyBlueAtkNearest, position, rotation);
				break;
			case 2:
				Instantiate (big ? enemyRedAtkWave : enemyRedAtkNearest, position, rotation);
				break;
			case 3:
				Instantiate (big ? enemyYellowAtkWave : enemyYellowAtkNearest, position, rotation);
				break;
			default:
				Instantiate (big ? enemyYellowAtkWave : enemyYellowAtkNearest, position, rotation);
				break;
			}
		} else {
			Instantiate (big ? enemyBasicAtkWave : enemyBasicAtkNearest, position, rotation);
		}
	}

	private void printScores() {
		//Debug.Log ("PRINT SCORES.");
		isTextOn = true;
		//GUI.Label(new Rect(-50, 10, 100, 40), "Kills: " + kills + "\nDeaths: " + deaths);
	}


}
