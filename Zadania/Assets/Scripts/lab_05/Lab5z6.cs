using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab5z6 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "przeszkoda")
        {
            Debug.Log("Zderzenie z przeszkod¹");
        }
    }
}
