using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpController : MonoBehaviour {

	void OnGUI()
	{
		if (GUI.Button (new Rect (Screen.width - 250, Screen.height / 2 - 150, 150, 75), "Get back to the Menu")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("_Scenes/Menu");
		}
	}

}
