using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

    public GameObject player;

	public Text DisplayingSin;

    private Vector3 offset;
	private GameController gameController;

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

	void Update() {
		Camera.main.fieldOfView = 60.0f + (Mathf.Sin (Time.time * 5.0f) * Mathf.Sin (Time.time) * Mathf.Sin (Time.time / 2) * Mathf.Sin (Time.time * 2) * 10.0f) * (gameController.IntensityMax - gameController.getIntensity()) / gameController.IntensityMax;
		DisplayingSin.text += "\n Focus: " + (Mathf.Sin (Time.time * 5.0f) * Mathf.Sin (Time.time) * Mathf.Sin (Time.time / 2) * Mathf.Sin (Time.time * 2) * 10.0f) * (gameController.IntensityMax - gameController.getIntensity()) / gameController.IntensityMax;
	}

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
