using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour
{

    public float speed = 3f;

    private float initY;
    private Vector3 pos;

    private void Start()
    {
        pos = transform.position;
        initY = pos.y;
    }

    void Update()
    {
        float newY = initY + Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(pos.x, newY, pos.z);
    }
}