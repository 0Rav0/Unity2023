using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    public Vector2 start;
    public Vector2 end;
    public Vector2 playerPos;
    public bool playerDetected = false;
    public Animator animator;

    void Start()
    {
        start = transform.position;

        end.y = transform.position.y;
        start.y = end.y;
        playerPos = start;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x != end.x)
        {
            if (!playerDetected)
            {
                if (transform.position.x < end.x)
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                else
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                transform.position = Vector2.MoveTowards(transform.position, end, Time.deltaTime);
            }
                
        }
        else{
            Vector2 temp = start;
            start = end;
            end = temp;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            playerDetected = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(other.transform.position.x > transform.position.x)
                transform.rotation = Quaternion.Euler(0, 0, 0);
            else
                transform.rotation = Quaternion.Euler(0, 180, 0);

            if (end.x < start.x)
            {
                if (transform.position.x > end.x && transform.position.x < start.x)
                {
                    playerPos.x = other.transform.position.x;
                    transform.position = Vector2.MoveTowards(transform.position, playerPos, Time.deltaTime);
                }
                else
                    animator.SetBool("taunt", true);
            }
            else
            {
                if (transform.position.x < end.x && transform.position.x > start.x)
                {
                    playerPos.x = other.transform.position.x;
                    transform.position = Vector2.MoveTowards(transform.position, playerPos, Time.deltaTime);
                }
                else
                    animator.SetBool("taunt", true);
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("taunt", false);
            playerDetected = false;
        }
    }
}
