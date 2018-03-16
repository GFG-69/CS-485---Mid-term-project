using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	private float DurationOfSlowing;
	private float TimeOfSlowing;
	private float Intensity;

	public float pillsBoostSpeed;
	public float pillsBoostJump;
	public float IntensityMax;
	public float DurationOfRising;
	public float DurationOfPlateau;
	public float DurationOfDecreasing;
	public Text DisplayingTime;

	// Use this for initialization
	void Start () {
		DurationOfSlowing = 0.0f;
		Intensity = 0.0f;
		DisplayingTime.text = "";
	}

	// Update is called once per frame
	void Update () {
		if (DurationOfSlowing - Time.time > DurationOfDecreasing + DurationOfPlateau)
			Intensity = IntensityMax * (Time.time - TimeOfSlowing) / DurationOfRising;
		else if (DurationOfSlowing - Time.time > DurationOfDecreasing)
			Intensity = IntensityMax;
		else if (DurationOfSlowing - Time.time > 0.0f)
			Intensity = IntensityMax * (DurationOfSlowing - Time.time) / DurationOfDecreasing;
		else
			Intensity = 0.0f;
		if (DurationOfSlowing - Time.time > 0.0f)
			DisplayingTime.text = "Time before getting normal: " + (DurationOfSlowing - Time.time) + "\nIntensity: " + Intensity;
		else
			DisplayingTime.text = "";
		Time.timeScale = 1.0f - Intensity;
	}

	public void SlowTheTime() {
		if (Intensity == 0.0f) {
			DurationOfSlowing = Time.time + DurationOfRising + DurationOfPlateau + DurationOfDecreasing;
			TimeOfSlowing = Time.time;
		}
	}

	public float getIntensity() {
		return (Intensity);
	}

}
