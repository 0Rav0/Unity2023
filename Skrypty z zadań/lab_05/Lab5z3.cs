using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab5z3 : MonoBehaviour
{
    public float speed = 2.0f;
    public List<Vector3> points = new();
    bool isMoving = false;
    bool moveForward = true;
    int i;

    public Vector3 endPos;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        endPos = points[1];
    }

    private void OnTriggerEnter(Collider other)
    {
        isMoving = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            if(transform.position == endPos)
            {
                if(transform.position == points[points.Count - 1])
                {
                    moveForward = false;
                }
                else if (transform.position == points[0])
                {
                    moveForward = true;
                }

                if (moveForward)
                {
                    i++;
                    endPos = points[i];
                }
                else
                {
                    i--;
                    endPos = points[i];
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, endPos, Time.deltaTime * speed);
        }
    }
}
