using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformSpawnPoints : MonoBehaviour
{
    public GameObject Point;
    public Vector3 SpawnPoint;
    public int sizeX, sizeZ;

    private void Start()
    {
        sizeX = (int)transform.localScale.x / 2;
        sizeZ = (int)transform.localScale.z / 2;

        int x = UnityEngine.Random.Range(0, 4);

        if(x > 0)
        {
            SpawnPoint = (new Vector3(
                UnityEngine.Random.Range(transform.position.x - sizeX + 2, transform.position.x + sizeX - 2),
                1f,
                UnityEngine.Random.Range(transform.position.z - sizeZ + 2, transform.position.z + sizeZ - 2)
                )
            );
            GameObject point = Instantiate(Point, SpawnPoint, Quaternion.Euler(90,0,0));
            point.transform.SetParent(this.transform, true);
        }
    }
}
