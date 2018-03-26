using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDownController : MonoBehaviour
{

    public float speed = 3f;
	public float length;

	private float initY;
	private Vector3 pos;

    private void Start()
    {
        pos = transform.position;
        initY = pos.y;
    }

    void Update()
    {
		float newY = initY + Mathf.Sin(Time.time * speed) * length;
        transform.position = new Vector3(pos.x, newY, pos.z);
    }
}
