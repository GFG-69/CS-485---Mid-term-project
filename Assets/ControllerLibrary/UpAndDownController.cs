using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDownController : MonoBehaviour
{

    public float speed = 3f;
	public float length;

	private GameController gameController;
	private float initY;
	private Vector3 pos;

    private void Start()
    {
        pos = transform.position;
        initY = pos.y;
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
		if (!gameController.getIsAsleep())
		{
			float newY = initY + Mathf.Sin(Time.time * speed) * length;
        	transform.position = new Vector3(pos.x, newY, pos.z);
		}
    }
}
