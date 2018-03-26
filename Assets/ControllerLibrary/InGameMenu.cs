using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour {

	private GameController gameController;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameControllerObject == null)
		{
			Debug.Log("Cannot find 'GameController' script");
		}	
	}

	void OnGUI()
	{
		if (gameController.isPaused)
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 200, 200, 100), "Resume")) {
				gameController.isPaused = false;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "Menu (will exit the play)")) {
				UnityEngine.SceneManagement.SceneManager.LoadScene ("_Scenes/Menu");
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 100, 200, 100), "Exit")) {
				Application.Quit ();
			}
		}
	}

}
