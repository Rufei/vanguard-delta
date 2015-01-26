using UnityEngine;
using System.Collections;

public class FormationChecker : MonoBehaviour {
	
	public GameObject bullet;
	
	public GameObject circleIndicator;
	public GameObject lineIndicator;
	public GameObject columnIndicator;

	public GameObject shield;
	
	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	
	public float fireRate;

	private GameObject shieldObject;
	
	private float formationXThreshold = 60;
	private float formationYThreshold = 60;
	private float formationInnerRadiusThreshold = 50;
	private float formationShieldRadiusThreshold = 20;

	private float nextFire;
	private float nextShield;

	// Use this for initialization
	void Start () {
		nextFire = Time.time;
		nextShield = Time.time;
		//circleIndicator = Instantiate (circleIndicator, new Vector3(0,0,0), new Quaternion());
		circleIndicator = (GameObject) Instantiate (circleIndicator, this.transform.position, this.transform.rotation);
		lineIndicator = (GameObject) Instantiate (lineIndicator, this.transform.position, this.transform.rotation);
		columnIndicator = (GameObject) Instantiate (columnIndicator, this.transform.position, this.transform.rotation);
		shieldObject = Instantiate (shield, circleIndicator.transform.position, Quaternion.identity) as GameObject;
		
		circleIndicator.renderer.material.color = new Color (1.0f, 1.0f, 1.0f, 0.0f);
		circleIndicator.transform.localScale = new Vector3(1.0f,1.0f,1.0f);
		
		columnIndicator.renderer.material.color = new Color (1.0f, 1.0f, 1.0f, 0.0f);
		columnIndicator.transform.localScale = new Vector3(1.0f,1.0f,1.0f);
		
		lineIndicator.renderer.material.color = new Color (1.0f, 1.0f, 1.0f, 0.0f);
		lineIndicator.transform.localScale = new Vector3(1.0f,1.0f,1.0f);

		shieldObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		//float sumXPosition = 0;
		//float sumYPosition = 0;
		
		float formationCentroidX = ((float) (player1.transform.position.x+player2.transform.position.x+player3.transform.position.x))/3.0f;
		float formationCentroidY = ((float) (player1.transform.position.y+player2.transform.position.y+player3.transform.position.y))/3.0f;
		
		float player1Distance = (float) getDistance(formationCentroidX,formationCentroidY,player1.transform.position.x,player1.transform.position.y);
		float player2Distance = (float) getDistance(formationCentroidX,formationCentroidY,player2.transform.position.x,player2.transform.position.y);
		float player3Distance = (float) getDistance(formationCentroidX,formationCentroidY,player3.transform.position.x,player3.transform.position.y);
		
		float formationAverageRadius = ((float) (player1Distance + player2Distance + player3Distance)) / 3.0f;
		
		float player1XVariance = Mathf.Abs(player1.transform.position.x - formationCentroidX);
		float player2XVariance = Mathf.Abs(player2.transform.position.x - formationCentroidX);
		float player3XVariance = Mathf.Abs(player3.transform.position.x - formationCentroidX);
		
		float formationXVariance = player1XVariance + player2XVariance + player3XVariance;
		
		float player1YVariance = Mathf.Abs(player1.transform.position.y - formationCentroidY);
		float player2YVariance = Mathf.Abs(player2.transform.position.y - formationCentroidY);
		float player3YVariance = Mathf.Abs(player3.transform.position.y - formationCentroidY);
		
		float formationYVariance = player1YVariance + player2YVariance + player3YVariance;
		
		//Debug.Log ("Forma Radius: " + formationAverageDistance);
		//Debug.Log ("Forma X: " + formationXVariance);
		//Debug.Log ("Forma Y: " + formationYVariance);
		
		circleIndicator.transform.position = new Vector3 (formationCentroidX, formationCentroidY, 0);
		lineIndicator.transform.position = new Vector3 (formationCentroidX, formationCentroidY, 0);
		columnIndicator.transform.position = new Vector3 (formationCentroidX, formationCentroidY, 0);
		
		
		
		float circleOpacity = (float)(70f - formationAverageRadius) / 70f;
		circleOpacity = Mathf.Max (Mathf.Min (circleOpacity, 0.4f), 0.0f);
		float circleRadius = (formationAverageRadius/18.0f);
		
		circleRadius = Mathf.Max(circleRadius,1.0f);
		
		circleIndicator.transform.localScale = new Vector3(circleRadius,circleRadius,1.0f);
		circleIndicator.renderer.material.color = new Color(1.0f,1.0f,1.0f,circleOpacity);
		
		
		
		float lineOpacity = ((float)(200f - formationYVariance) / 200.0f) - 3.0f*circleOpacity;
		lineOpacity = Mathf.Max (Mathf.Min (lineOpacity, 0.35f), 0.0f);
		float lineScale = (formationYVariance/40.0f);
		float lineWidth = (formationAverageRadius/60.0f);
		
		lineScale = Mathf.Max (lineScale, 1.0f);
		
		lineIndicator.transform.localScale = new Vector3(lineWidth,lineScale,1.0f);
		lineIndicator.renderer.material.color = new Color(1.0f,1.0f,1.0f,lineOpacity);
		
		
		float columnOpacity = ((float)(200f - formationXVariance) / 200.0f) - 3.0f*circleOpacity;
		columnOpacity = Mathf.Max (Mathf.Min (columnOpacity, 0.35f), 0.0f);
		float columnScale = (formationXVariance/40.0f);
		float columnWidth = (formationAverageRadius/60.0f);
		
		columnScale = Mathf.Max (columnScale, 1.0f);
		
		columnIndicator.transform.localScale = new Vector3(columnScale,columnWidth,1.0f);
		columnIndicator.renderer.material.color = new Color(1.0f,1.0f,1.0f,columnOpacity);
		
		
		if (formationAverageRadius < formationShieldRadiusThreshold) {
			//Debug.Log ("CircleFormation!");
			if (Time.time > nextShield) {
				shieldObject.transform.position = circleIndicator.transform.position;
				shieldObject.SetActive(true);
				circleIndicator.renderer.material.color = new Color(1.0f,1.0f,1.0f,0.0f);
			}
		} else if (shieldObject.activeSelf){
			shieldObject.SetActive(false);
			circleIndicator.renderer.material.color = new Color(1.0f,1.0f,1.0f,circleOpacity);
		} else if (formationXVariance < formationXThreshold && formationAverageRadius < formationXThreshold * 2 && formationAverageRadius > formationInnerRadiusThreshold){
			//Debug.Log("Vertical Line!");
			tryToFire();
		} else if (formationYVariance < formationYThreshold && formationAverageRadius < formationYThreshold * 2 && formationAverageRadius > formationInnerRadiusThreshold){
			//Debug.Log ("Horizontal Line!");
			tryToFire();
		}
	}
	
	void tryToFire() {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(bullet,player1.transform.Find ("BulletSpawn").position,player1.transform.Find ("BulletSpawn").rotation);
			Instantiate(bullet,player2.transform.Find ("BulletSpawn").position,player2.transform.Find ("BulletSpawn").rotation);
			Instantiate(bullet,player3.transform.Find ("BulletSpawn").position,player3.transform.Find ("BulletSpawn").rotation);
			audio.Play ();
		}
	}
	
	
	float getDistance(float x1, float y1, float x2, float y2) {
		return Mathf.Sqrt(Mathf.Pow(x1-x2, 2) + Mathf.Pow(y1-y2, 2));
	}
	
}
