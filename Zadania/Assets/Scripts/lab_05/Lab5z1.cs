using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab5z1 : MonoBehaviour
{
    public float speed = 2.0f;

    Vector3 startPos;
    Vector3 endPos;
    bool isMoving = false;

    void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(transform.position.x + 5.0f, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        isMoving = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isMoving = false;
    }

    void Update()
    {
        if (isMoving)
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
}
