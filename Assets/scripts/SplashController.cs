using UnityEngine;
using System.Collections;

public class SplashController : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		// Switch context
		if (Input.GetKeyDown ("joystick 1 button 0") ||
		    Input.GetKeyDown ("joystick 1 button 1") ||
		    Input.GetKeyDown ("joystick 1 button 2") ||
		    Input.GetKeyDown ("joystick 1 button 3") ||
		    Input.GetKeyDown ("joystick 1 button 4") ||
		    Input.GetKeyDown ("joystick 1 button 5") ||
		    Input.GetKeyDown ("joystick 1 button 6") ||
		    Input.GetKeyDown ("joystick 1 button 7") ||
		    Input.GetKeyDown ("joystick 2 button 0") ||
		    Input.GetKeyDown ("joystick 2 button 1") ||
		    Input.GetKeyDown ("joystick 2 button 2") ||
		    Input.GetKeyDown ("joystick 2 button 3") ||
		    Input.GetKeyDown ("joystick 2 button 4") ||
		    Input.GetKeyDown ("joystick 2 button 5") ||
		    Input.GetKeyDown ("joystick 2 button 6") ||
		    Input.GetKeyDown ("joystick 2 button 7") ||
		    Input.GetKeyDown ("joystick 3 button 0") ||
		    Input.GetKeyDown ("joystick 3 button 1") ||
		    Input.GetKeyDown ("joystick 3 button 2") ||
		    Input.GetKeyDown ("joystick 3 button 3") ||
		    Input.GetKeyDown ("joystick 3 button 4") ||
		    Input.GetKeyDown ("joystick 3 button 5") ||
		    Input.GetKeyDown ("joystick 3 button 6") ||
		    Input.GetKeyDown ("joystick 3 button 7")) {
			Application.LoadLevel (2);
		}

		if (Input.GetKeyDown("escape")) {
			Application.Quit();
		}
	}

	void OnGUI () {
		if (GUI.Button(new Rect(Screen.width/2 - 35, Screen.height/2 + 65, 70, 30), "Credits")) {
			Application.LoadLevel (1);
		}
		GUI.Label(new Rect(Screen.width/2 - 40f, Screen.height/2 + 115f, 100f, 40f), "Press Xbox controller button");
	}
}
