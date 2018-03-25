using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionFilter : MonoBehaviour {

	private GameController gameController;
	private Color color;

	public Material FilterBlue;
	public Material FilterBlack;
	public Material Filter;

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
	
	// Update is called once per frame
	void Update () {
		if (gameController.getIntensity() > 0)
		{
			color = FilterBlue.GetColor ("_Color");
			color.a = gameController.BlueIntensity * gameController.getIntensity();
		}
		else
		{
			color = FilterBlack.GetColor ("_Color");
			color.a = 0.0f;
			if (Time.time < gameController.timeBeforeStarting)
			{
				color.a = (gameController.timeBeforeStarting - Time.time) / gameController.timeBeforeStarting;
			}
			else if (gameController.getTimeOfSleeping () - Time.time < 3)
				color.a = (3 - gameController.getTimeOfSleeping () + Time.time) / 3;
		}
		Filter.SetColor ("_Color", color);
	}
}
