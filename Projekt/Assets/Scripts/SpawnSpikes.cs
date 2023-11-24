using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpikes : MonoBehaviour
{
    public GameObject SpikePrefab;
    List<Vector3> spawnPoints = new ();

    void Start()
    {
        int posX = (int)transform.position.x;
        int posZ = (int)transform.position.z;

        while (spawnPoints.Count < 2)
        {
            bool isOk = true;
            Vector3 spawnPoint = new Vector3(Random.Range(posX - 4, posX + 4), 0.1f, Random.Range(posZ - 4, posZ + 4));

            foreach(var pos in spawnPoints)
            {
                if(pos.x == spawnPoint.x || pos.z == spawnPoint.z)
                {
                    isOk = false;
                    break;
                }
            }

            if(isOk)
                spawnPoints.Add(spawnPoint);
        }

        foreach (var spawnPoint in spawnPoints)
        {
            GameObject Spike = Instantiate(SpikePrefab, spawnPoint, Quaternion.identity);
            Spike.transform.SetParent(transform, true);
        }
    }
}
