using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab5z2 : MonoBehaviour
{
    bool open = false;
    public Transform Door;
    public float speed = 2.0f;
    Vector3 startPos;
    Vector3 endPos;

    void Start()
    {
        startPos = Door.position;
        endPos = new Vector3(Door.position.x + 5.0f, Door.position.y, Door.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        open = true;
    }

    private void OnTriggerExit(Collider other)
    {
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            if (Door.position == endPos) return;
            Door.position = Vector3.MoveTowards(Door.position, endPos, Time.deltaTime * speed);
        }
        else
        {
            if (Door.position == startPos) return;
            Door.position = Vector3.MoveTowards(Door.position, startPos, Time.deltaTime * speed);
        }
    }
}
