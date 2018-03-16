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
		Camera.main.fieldOfView = 60.0f + gameController.getDrunkenCameraFocal();
	}

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
