using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class z3 : MonoBehaviour
{
    public float speed = 2.0f;

    Vector3 targetPos;
    Quaternion targetDeg;
    float rotation = 0;
    int p;  //punkt trasy

    void Start()
    {
        p = 1;
        rotation = 90;
        targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10.0f);
        targetDeg = Quaternion.Euler(0, rotation, 0);
    }

    void Update()
    {
        if(rotation == 360)
            rotation = -360;

        if (transform.position == targetPos)
        {
            if(transform.rotation != targetDeg) 
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, targetDeg, Time.deltaTime * speed);
            }
            else
            {
                rotation += 90;
                transform.rotation = targetDeg;
                targetDeg = Quaternion.Euler(0, rotation, 0);
                switch (p)
                {
                    case 1:
                        targetPos = new Vector3(transform.position.x + 10.0f, transform.position.y, transform.position.z);                        
                        p = 2;
                        break;
                    case 2:
                        targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10.0f);
                        p = 3;
                        break;
                    case 3:
                        targetPos = new Vector3(transform.position.x - 10.0f, transform.position.y, transform.position.z);
                        p = 4;
                        break;
                    case 4:
                        targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10.0f);
                        p = 1;
                        break;
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
        }
    }
}
