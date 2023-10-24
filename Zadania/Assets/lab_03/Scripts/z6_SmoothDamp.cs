using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class z6_SmoothDamp : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 2.0f;

    float xVelocity = 0.0f;
    float zVelocity = 0.0f;

    void Update()
    {
        float newX = Mathf.SmoothDamp(transform.position.x, target.position.x, ref xVelocity, smoothTime);
        float newZ = Mathf.SmoothDamp(transform.position.z, target.position.z, ref zVelocity, smoothTime);
        transform.position = new Vector3(newX, transform.position.y, newZ);
    }
}
