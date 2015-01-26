using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float speed;
	
	// Update is called once per frame
	void Update () {
		float tempAngle = this.transform.rotation.eulerAngles.z+90;
		float tempX = Mathf.Cos (Mathf.Deg2Rad*tempAngle)*Time.deltaTime*speed;
		float tempY = Mathf.Sin (Mathf.Deg2Rad*tempAngle)*Time.deltaTime*speed;
		Vector3 movementVector = new Vector3(tempX,tempY,0);
		this.transform.position = this.transform.position + movementVector;
	}
}
