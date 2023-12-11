using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Lab4z1 : MonoBehaviour
{
    public float delay = 3.0f;
    public GameObject block;
    public int amount = 10;
    public List<Material> materials = new List<Material>();

    List<Vector3> positions = new List<Vector3>();
    int objectCounter = 0;

    void Start()
    {
        int sizeX = (int)GetComponent<Renderer>().bounds.size.x;
        int sizeZ = (int)GetComponent<Renderer>().bounds.size.z;

        Debug.Log($"$$$ {sizeX}x{sizeZ} - {amount}");

        // w momecie uruchomienia generuje x kostek w losowych miejscach !!! nie wiecej ni¿ rozmiar plane !!!
        List<int> pozycje_x = new List<int>(Enumerable.Range(-sizeX / 2, sizeX).OrderBy(x => Guid.NewGuid()).Take(amount));
        List<int> pozycje_z = new List<int>(Enumerable.Range(-sizeZ / 2, sizeZ).OrderBy(x => Guid.NewGuid()).Take(amount));

        for (int i = 0; i < amount; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 5, pozycje_z[i]));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywo³ano coroutine");
        foreach (Vector3 pos in positions)
        {
            block.GetComponent<Renderer>().material = materials[UnityEngine.Random.Range(0, 5)];
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
