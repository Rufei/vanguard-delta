using UnityEngine;
using System.Collections;

public class ReturnHandler : MonoBehaviour {
	
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
		    Input.GetKeyDown ("joystick 3 button 7") ||
		    Input.GetMouseButtonUp(0) ||
		    Input.GetMouseButtonUp(1) ||
		    Input.GetMouseButtonUp(2)) {
			Application.LoadLevel (0);
		}

		if (Input.GetKeyDown("escape")) {
			Application.Quit();
		}
	}
}
