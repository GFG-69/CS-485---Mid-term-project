using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillsController : MonoBehaviour {

	private GameController gameController;

	private void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameControllerObject == null)
		{
			Debug.Log("Cannot find 'Scene2GameController' script");
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		Destroy(this.gameObject);
		gameController.SlowTheTime();
	}

}
