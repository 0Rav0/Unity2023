using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPlatform : MonoBehaviour
{
    public float time = 10;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().PlatformDestroyed(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            time -= Time.deltaTime;
            transform.localScale -= new Vector3(Time.deltaTime * 3.5f, 0, 0);
            if (transform.localScale.x < 0.1)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().PlatformDestroyed(this.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
