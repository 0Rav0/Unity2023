using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpikes : MonoBehaviour
{
    public GameObject SpikePrefab;
    public List<Vector3> spikePoints = new();

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.CompareTag("spikePoint"))
                spikePoints.Add(child.transform.position);
        }

        int amount = 0;

        if (spikePoints.Count > 1)
            amount = Random.Range(1, 3);
        else
            amount = 1;


        for (int i = 0; i < amount; i++)
        {
            GameObject point = Instantiate(SpikePrefab, spikePoints[Random.Range(0, spikePoints.Count)], Quaternion.identity);
            spikePoints.RemoveAt(i);
            point.transform.SetParent(this.transform, true);
        }
    }
}
