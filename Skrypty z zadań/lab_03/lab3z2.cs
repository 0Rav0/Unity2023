using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab3z2 : MonoBehaviour
{
    public float speed = 2.0f;

    Vector3 startPos;
    Vector3 endPos;

    void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(transform.position.x + 10.0f, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (transform.position == endPos)
        {
            Vector3 temp = endPos;
            endPos = startPos;
            startPos = temp;
        }

        transform.position = Vector3.MoveTowards(transform.position, endPos, Time.deltaTime * speed);
    }
}
