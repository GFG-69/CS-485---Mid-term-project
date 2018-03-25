using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;
	private GameController gameController;
	private float x;
	private float y;

    void Start()
    {
        offset = transform.position - player.transform.position;
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

	void Update()
	{
		if (!gameController.isPaused && Time.time > gameController.timeBeforeStarting) {
			Camera.main.fieldOfView = 60.0f + gameController.getDrunkenCameraFocal ();
			Camera.main.transform.Rotate (0.0f, 0.0f, gameController.getDrunkenCameraZ ());
		}
	}

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
