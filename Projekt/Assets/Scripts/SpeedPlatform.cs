using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPlatform : MonoBehaviour
{
    float temp;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            temp = collision.gameObject.GetComponent<Rigidbody>().angularDrag;
            GetComponent<Renderer>().material.color = new Color(0, 175, 255);
            collision.gameObject.GetComponent<Rigidbody>().angularDrag = 0f;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, 20f));
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().angularDrag = temp;
        }
    }
}
