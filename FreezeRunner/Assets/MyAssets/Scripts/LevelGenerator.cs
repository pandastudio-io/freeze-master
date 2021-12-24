using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();
    public float platformIncreX = 15;
    public float platformsDistance;

    private void Awake()
    {
        InstantiatePlatform(platforms[0]);
        platforms.RemoveAt(0);

        int size = getPlatformSize();
   
        for (int i = 1; i <= size; i++)
        {
            int randIndex = Random.Range(0, getPlatformSize());
            InstantiatePlatform(platforms[randIndex]);
            platforms.RemoveAt(randIndex);
        }
        InstantiatePlatform(platforms[0]);
        platforms.RemoveAt(0);
    }

    public int getPlatformSize()
    {
        Debug.Log("Platform" + ( platforms.Count - 1));

        return platforms.Count - 1;
    }
    public void InstantiatePlatform(GameObject platform)
    {
            Transform tra = Instantiate(platform, transform.position, transform.rotation).transform;
            tra.position = new Vector3(platformIncreX, -2.5f, 0);
            platformIncreX = platformIncreX + platformsDistance;
    }
}
