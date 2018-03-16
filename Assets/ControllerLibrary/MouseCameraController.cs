using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseCameraController : MonoBehaviour {

    public Vector2 mouseLook;
    public Vector2 smoothV;

    public float sensivity = 5.0f;
    public float smoothing = 2.0f;

	public Text DisplayingSin;

	private GameController gameController;

    GameObject player;

	// Use this for initialization
	void Start () {
        player = this.transform.parent.gameObject;
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
        var avg = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        avg = Vector2.Scale(avg, new Vector2(sensivity * smoothing, sensivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, avg.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, avg.y, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);
        if (Cursor.lockState == CursorLockMode.Locked)
        {
			transform.localRotation = Quaternion.AngleAxis(-mouseLook.y + ((Mathf.Sin (Time.time * 6.0f) * Mathf.Sin (Time.time) * Mathf.Sin (Time.time / 4) * Mathf.Sin (Time.time * 3) * 10.0f) * (gameController.IntensityMax - gameController.getIntensity()) / gameController.IntensityMax), Vector3.right);
			player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x + ((Mathf.Sin (Time.time * 3.5f) * Mathf.Sin (Time.time) * Mathf.Sin (Time.time / 3) * Mathf.Sin (Time.time * 4) * 10.0f) * (gameController.IntensityMax - gameController.getIntensity()) / gameController.IntensityMax) * 2, player.transform.up);
			DisplayingSin.text += "\n Hor: " + ((Mathf.Sin (Time.time * 6.0f) * Mathf.Sin (Time.time) * Mathf.Sin (Time.time / 4) * Mathf.Sin (Time.time * 3) * 10.0f) * (gameController.IntensityMax - gameController.getIntensity()) / gameController.IntensityMax);
			DisplayingSin.text += "\n Ver: " + ((Mathf.Sin (Time.time * 3.5f) * Mathf.Sin (Time.time) * Mathf.Sin (Time.time / 3) * Mathf.Sin (Time.time * 4) * 10.0f) * (gameController.IntensityMax - gameController.getIntensity()) / gameController.IntensityMax) * 2;
        }
    }
}
