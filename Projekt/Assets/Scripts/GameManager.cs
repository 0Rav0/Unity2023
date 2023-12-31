using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab = null;
    public GameObject StartPlatform = null;

    public List<Color> ColorsList = new();
    public List<GameObject> PlatformsList = new();
    public List<Color> Colors = new();

    public int ColorIndex = 0;
    public int PlatformsIndex = 0;
    public int minLevel = 0;
    public int maxLevel = 0;

    public GameObject NextPlatform = null;
    public GameObject CurrentPlatform = null;


    void Start()
    {
        Color c = ColorsList[Random.Range(0, ColorsList.Count)];
        Colors.Add(c);

        c = ColorsList[Random.Range(0, ColorsList.Count)];
        while (Colors[0] == c)
        {
            c = ColorsList[Random.Range(0, ColorsList.Count)];
        }
        Colors.Add(c);

        c = ColorsList[Random.Range(0, ColorsList.Count)];
        while (Colors[0] == c || Colors[1] == c)
        {
            c = ColorsList[Random.Range(0, ColorsList.Count)];
        }
        Colors.Add(c);

        CurrentPlatform = Instantiate(StartPlatform, new Vector3(0, 0, 0), Quaternion.identity);
        CurrentPlatform.GetComponent<Renderer>().material.color = Colors[ColorIndex];
        ColorIndex = 1;

        SpawnPlatform();

        GameObject Player = Instantiate(PlayerPrefab, new Vector3(0, 2, 0), Quaternion.identity);
        Player.GetComponent<Renderer>().material.color = Colors[2];

        GameObject.Find("Camera").GetComponent<CameraController>().enabled = true;
    }

    public bool UpdatePlatforms(GameObject platform)
    {
        if (CurrentPlatform.name != platform.name)
        {
            Destroy(CurrentPlatform);
            CurrentPlatform = platform;
            SpawnPlatform();
            return true;
        }
        return false;
    }

    void SpawnPlatform()
    {
        int minGap = 0;
        int maxGap = 0;

        switch(PlatformsIndex)
        {
            case 0:
                minLevel = 0;
                maxLevel = 1;
                minGap = 0;
                maxGap = 2;
                break;
            case int i when i > 0 && i <= 2:
                minLevel = 0;
                maxLevel = 2;
                minGap = 0;
                maxGap = 3;
                break;
            case int i when i > 2 && i <= 4:
                minLevel = 0;
                maxLevel = 3;
                minGap = 1;
                maxGap = 3;
                break;
            case int i when i > 4 && i <= 6:
                minLevel = 0;
                maxLevel = 4;
                minGap = 1;
                maxGap = 4;
                break;
            case int i when i > 6 && i <= 8:
                minLevel = 1;
                maxLevel = 5;
                minGap = 2;
                maxGap = 4;
                break;
            case int i when i > 8 && i <= 10:
                minLevel = 1;
                maxLevel = 6;
                minGap = 2;
                maxGap = 5;
                break;
            case int i when i > 10 && i <= 12:
                minLevel = 1;
                maxLevel = 7;
                minGap = 3;
                maxGap = 5;
                break;
            case int i when i > 12 && i <=14:
                minLevel = 2;
                maxLevel = 8;
                minGap = 3;
                maxGap = 6;
                break;
            case int i when i > 14 && i <= 16:
                minLevel = 2;
                maxLevel = 9;
                minGap = 4;
                maxGap = 6;
                break;
            case int i when i > 16:
                minLevel = 2;
                maxLevel = 9;
                minGap = 5;
                maxGap = 6;
                break;
            default: break;
        }

        //Debug.Log("min: " + minGap + " max:" + maxGap);
        GameObject platform = PlatformsList[(Random.Range(minLevel, maxLevel))];
        float gap = CurrentPlatform.transform.localScale.z / 2 + platform.transform.localScale.z / 2 + Random.Range(minGap, maxGap);
        NextPlatform = Instantiate(platform, new Vector3(CurrentPlatform.transform.position.x, 0, CurrentPlatform.transform.position.z + gap), Quaternion.identity);
        NextPlatform.GetComponent<Renderer>().material.color = Colors[ColorIndex];       

        if (ColorIndex == 0)
            ColorIndex = 1;
        else
            ColorIndex = 0;

        NextPlatform.name = "platform" + PlatformsIndex.ToString();
        PlatformsIndex++;
    }

    public void PlatformDestroyed(GameObject platform)
    {
        CurrentPlatform = NextPlatform;
        SpawnPlatform();
    }
}
