using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab3z6_Lerp : MonoBehaviour
{
    public float minimum = -1.0F;
    public float maximum = 1.0F;

    static float t = 0.0f;

    void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), 0, 0);

        t += 0.5f * Time.deltaTime;

        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}
