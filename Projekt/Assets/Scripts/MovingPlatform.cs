using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameManager gm;
    public float speed = 2f;

    Vector3 startPos;
    Vector3 endPos;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        int direction = Random.Range(0, 2);

        if(direction == 0)
        {
            startPos = new Vector3(transform.position.x + -5.0f, transform.position.y, transform.position.z);
            endPos = new Vector3(transform.position.x + 5.0f, transform.position.y, transform.position.z);
        }
        else
        {
            startPos = new Vector3(transform.position.x, transform.position.y - 3f, transform.position.z);
            endPos = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
        }
        
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
