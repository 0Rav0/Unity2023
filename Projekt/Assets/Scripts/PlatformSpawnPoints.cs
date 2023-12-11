using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformSpawnPoints : MonoBehaviour
{
    public GameObject Point;
    public List<Vector3> coinPoints = new();

    private void Awake()
    {
        foreach(Transform child in transform)
        {
            if(child.gameObject.CompareTag("coinPoint"))
                coinPoints.Add(child.transform.position);
        }

        int amount = 0;

        if (coinPoints.Count > 1)
            amount = Random.Range(1, 3);
        else
            amount = 1;


        for(int i = 0; i < amount; i++)
        {
            GameObject point = Instantiate(Point, coinPoints[Random.Range(0, coinPoints.Count)], Quaternion.Euler(90,0,0));
            coinPoints.RemoveAt(i);
            point.transform.SetParent(this.transform, true);
        }
    }
}
