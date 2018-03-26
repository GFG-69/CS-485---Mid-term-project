using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	private float DurationOfSlowing;
	private float TimeOfSlowing;
	private float pillsIntensity;
	private float drunkIntensity;
	private float TimeOfSleeping;

	private float randCF1;
	private float randCF2;
	private float randCF3;
	private float randCF4;
	private float randCF5;
	private float randCF6;
	private float randCF7;

	private float randCX1;
	private float randCX2;
	private float randCX3;
	private float randCX4;
	private float randCX5;
	private float randCX6;
	private float randCX7;

	private float randCZ1;
	private float randCZ2;
	private float randCZ3;
	private float randCZ4;
	private float randCZ5;
	private float randCZ6;
	private float randCZ7;

	private float randCY1;
	private float randCY2;
	private float randCY3;
	private float randCY4;
	private float randCY5;
	private float randCY6;
	private float randCY7;

	private float randPX1;
	private float randPX2;
	private float randPX3;
	private float randPX4;
	private float randPX5;
	private float randPX6;
	private float randPX7;

	private float randPZ1;
	private float randPZ2;
	private float randPZ3;
	private float randPZ4;
	private float randPZ5;
	private float randPZ6;
	private float randPZ7;

	public bool isPaused;
	public float timeBeforeStarting;
	public float BlueIntensity;
	public float DurationOfAwake;
	public float movementIntensity;
	public float drunkIntensityMin;
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
		pillsIntensity = 0.0f;
		DisplayingTime.text = "";
		setDrunkenRandom ();
		TimeOfSleeping = Time.time + DurationOfAwake + 3;
		Cursor.visible = false;
	}

	// Update is called once per frame
	void Update () {
		setIntensity ();
		if (!isPaused)
			Time.timeScale = 1.0f - pillsIntensity;
		else
			Time.timeScale = 0.0f;
		drunkIntensity = getDrunkIntensity();
		if (Time.time > TimeOfSleeping + 1)
			DisplayingTime.text = "You fall asleep...\nGAME OVER";
		if (Time.time > TimeOfSleeping + 4) {
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			UnityEngine.SceneManagement.SceneManager.LoadScene ("_Scenes/Menu");
		}
		//affiche les tests
		/*if (DurationOfSlowing - Time.time > 0.0f)
			DisplayingTime.text = "Time before getting normal: " + (DurationOfSlowing - Time.time) + "\nIntensity: " + pillsIntensity;
		else
			DisplayingTime.text = "Time before getting asleep: " + (TimeOfSleeping - Time.time);*/
	}

	private void setIntensity() {
		if (DurationOfSlowing - Time.time > DurationOfDecreasing + DurationOfPlateau)
			pillsIntensity = IntensityMax * (Time.time - TimeOfSlowing) / DurationOfRising;
		else if (DurationOfSlowing - Time.time > DurationOfDecreasing)
			pillsIntensity = IntensityMax;
		else if (DurationOfSlowing - Time.time > 0.0f)
			pillsIntensity = IntensityMax * (DurationOfSlowing - Time.time) / DurationOfDecreasing;
		else
			pillsIntensity = 0.0f;
	}

	public void SlowTheTime() {
		if (pillsIntensity == 0.0f) {
			DurationOfSlowing = Time.time + DurationOfRising + DurationOfPlateau + DurationOfDecreasing;
			TimeOfSlowing = Time.time;
			TimeOfSleeping = DurationOfSlowing + DurationOfAwake;
		}
	}

	public bool getIsAsleep () {
		return (Time.time > TimeOfSleeping);
	}

	public float getTimeOfSleeping () {
		return (TimeOfSleeping);
	}

	public float getIntensity() {
		return (pillsIntensity);
	}

	private void setDrunkenRandom()
	{
		randCF1 = Random.Range(4.5f, 5.5f);
		randCF2 = Random.Range(0.0f, 1.0f);
		randCF3 = Random.Range(0.0f, 1.0f);
		randCF4 = Random.Range(1.5f, 2.5f);
		randCF5 = Random.Range(0.0f, 1.0f);
		randCF6 = Random.Range(1.5f, 2.5f);
		randCF7 = Random.Range(0.0f, 1.0f);

		randCX1 = Random.Range(3.0f, 4.0f);
		randCX2 = Random.Range(0.0f, 1.0f);
		randCX3 = Random.Range(0.0f, 1.0f);
		randCX4 = Random.Range(2.5f, 3.5f);
		randCX5 = Random.Range(0.0f, 1.0f);
		randCX6 = Random.Range(3.5f, 4.5f);
		randCX7 = Random.Range(0.0f, 1.0f);

		randCZ1 = Random.Range(2.0f, 3.0f);
		randCZ2 = Random.Range(0.0f, 1.0f);
		randCZ3 = Random.Range(0.0f, 1.0f);
		randCZ4 = Random.Range(3.0f, 4.0f);
		randCZ5 = Random.Range(0.0f, 1.0f);
		randCZ6 = Random.Range(3.0f, 4.0f);
		randCZ7 = Random.Range(0.0f, 1.0f);

		randCY1 = Random.Range(5.5f, 6.5f);
		randCY2 = Random.Range(0.0f, 1.0f);
		randCY3 = Random.Range(0.0f, 1.0f);
		randCY4 = Random.Range(3.5f, 4.5f);
		randCY5 = Random.Range(0.0f, 1.0f);
		randCY6 = Random.Range(2.5f, 3.5f);
		randCY7 = Random.Range(0.0f, 1.0f);

		randPX1 = Random.Range(5.5f, 6.5f);
		randPX2 = Random.Range(0.0f, 1.0f);
		randPX3 = Random.Range(0.0f, 1.0f);
		randPX4 = Random.Range(3.5f, 4.5f);
		randPX5 = Random.Range(0.0f, 1.0f);
		randPX6 = Random.Range(2.5f, 3.5f);
		randPX7 = Random.Range(0.0f, 1.0f);

		randPZ1 = Random.Range(3.0f, 4.0f);
		randPZ2 = Random.Range(0.0f, 1.0f);
		randPZ3 = Random.Range(0.0f, 1.0f);
		randPZ4 = Random.Range(2.5f, 3.5f);
		randPZ5 = Random.Range(0.0f, 1.0f);
		randPZ6 = Random.Range(3.5f, 4.5f);
		randPZ7 = Random.Range(0.0f, 1.0f);
	}

	public float getDrunkenCameraFocal()
	{
		return ((Mathf.Sin (Time.time * randCF1 + randCF2) * Mathf.Sin (Time.time + randCF3) * Mathf.Sin (Time.time / randCF4 + randCF5) * Mathf.Sin (Time.time * randCF6 + randCF7) * drunkIntensity) * (IntensityMax - getIntensity ()) / IntensityMax * 4.0f);
	}

	public float getDrunkenCameraX()
	{
		return (((Mathf.Sin (Time.time * randCX1 + randCX2) * Mathf.Sin (Time.time + randCX3) * Mathf.Sin (Time.time / randCX4 + randCX5) * Mathf.Sin (Time.time * randCX6 + randCX7) * drunkIntensity) * (IntensityMax - getIntensity()) / IntensityMax) * 3.0f);
	}

	public float getDrunkenCameraY()
	{
		return (((Mathf.Sin (Time.time * randCY1 + randCY2) * Mathf.Sin (Time.time + randCY3) * Mathf.Sin (Time.time / randCY4 + randCY5) * Mathf.Sin (Time.time * randCY6 + randCY7) * drunkIntensity) * (IntensityMax - getIntensity()) / IntensityMax) * 4.0f);
	}

	public float getDrunkenCameraZ()
	{
		return (((Mathf.Sin (Time.time * randCZ1 + randCZ2) * Mathf.Sin (Time.time + randCZ3) * Mathf.Sin (Time.time / randCZ4 + randCZ5) * Mathf.Sin (Time.time * randCZ6 + randCZ7) * drunkIntensity) * (IntensityMax - getIntensity()) / IntensityMax) * 4.0f);
	}

	public float getDrunkenPlayerX()
	{
		return (((Mathf.Sin (Time.time * randPX1 + randPX2) * Mathf.Sin (Time.time + randPX3) * Mathf.Sin (Time.time / randPX4 + randPX5) * Mathf.Sin (Time.time * randPX6 + randPX7) * drunkIntensity) * (IntensityMax - getIntensity()) / IntensityMax) / 40);
	}

	public float getDrunkenPlayerZ()
	{
		return (((Mathf.Sin (Time.time * randPZ1 + randPZ2) * Mathf.Sin (Time.time + randPZ3) * Mathf.Sin (Time.time / randPZ4 + randPZ5) * Mathf.Sin (Time.time * randPZ6 + randPZ7) * drunkIntensity) * (IntensityMax - getIntensity()) / IntensityMax) / 50);
	}

	private float getDrunkIntensity()
	{
		return (((Mathf.Abs(Input.GetAxis("Horizontal"))) + (Mathf.Abs(Input.GetAxis("Vertical")))) * movementIntensity + drunkIntensityMin);
	}

}
