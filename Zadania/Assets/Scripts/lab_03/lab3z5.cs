using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab3z5 : MonoBehaviour
{
    public GameObject Cube;
    HashSet<Vector3> spawnPoints = new HashSet<Vector3>();

    void Start()
    {
        while (spawnPoints.Count < 10)
        {
            Vector3 spawnPoint = new Vector3(Random.Range(-4, 4), 0.5f, Random.Range(-4, 4));
            spawnPoints.Add(spawnPoint);
        }

        foreach (var spawnPoint in spawnPoints)
        {
            Instantiate(Cube, spawnPoint, Quaternion.identity);
        }
    }
}
