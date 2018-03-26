using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

	void OnGUI()
	{
		if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 200, 200, 100), "Play"))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("_Scenes/MainScene");
		}
		if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "Help"))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("_Scenes/Help");
		}
		if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 200, 100), "Exit"))
		{
			Application.Quit();
		}
	}

}
