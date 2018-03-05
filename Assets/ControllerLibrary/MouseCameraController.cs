using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCameraController : MonoBehaviour {

    public Vector2 mouseLook;
    public Vector2 smoothV;

    public float sensivity = 5.0f;
    public float smoothing = 2.0f;

    GameObject player;

	// Use this for initialization
	void Start () {
        player = this.transform.parent.gameObject;
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
            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
        }
    }
}
