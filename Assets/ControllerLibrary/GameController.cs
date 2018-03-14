using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	
	private float TimeOfSlowing;

	public float Intensity;
	public float DurationOfRising;
	public float DurationOfPlateau;
	public float DurationOfDecreasing;

	// Use this for initialization
	void Start () {
		TimeOfSlowing = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		if (TimeOfSlowing - Time.time > DurationOfRising + DurationOfPlateau)
			Time.timeScale = 1.0f - (DurationOfRising / (DurationOfRising - TimeOfSlowing - DurationOfDecreasing - DurationOfPlateau + Time.time) * Intensity);
		else if (TimeOfSlowing - Time.time > DurationOfRising)
			Time.timeScale = 1.0f - Intensity;
		else if (TimeOfSlowing - Time.time > 0)
			Time.timeScale = 1.0f - Intensity;//- ((TimeOfSlowing - Time.time) / DurationOfDecreasing * Intensity);
		else
			Time.timeScale = 1.0f;
	}

	public void SlowTheTime() {
		TimeOfSlowing = Time.time + DurationOfRising + DurationOfPlateau + DurationOfDecreasing;
	}

}
