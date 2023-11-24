using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    public float time;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            this.gameObject.GetComponent<Renderer>().material.color = new Color(200, 0, 0);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            time -= Time.deltaTime;
            
            if (time <= 0)
            {

                rb.isKinematic = false;
                rb.useGravity = true;
            }
        }
    }

    private void Update()
    {
        if (transform.position.y + 8f < 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().PlatformDestroyed(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
