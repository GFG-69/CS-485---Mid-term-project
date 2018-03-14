using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	
	private float TimeOfSlowing;

	public float Intensity;
	public float Duration;

	// Use this for initialization
	void Start () {
		TimeOfSlowing = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		if (TimeOfSlowing - Time.time > 0)
			Time.timeScale = 1.0f - ((TimeOfSlowing - Time.time) / Duration * Intensity);
		else
			Time.timeScale = 1.0f;
	}

	public void SlowTheTime() {
		TimeOfSlowing = Time.time + Duration;
	}

}
