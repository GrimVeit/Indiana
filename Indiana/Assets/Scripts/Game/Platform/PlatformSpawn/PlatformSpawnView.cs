using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformSpawnView : View
{
    [SerializeField] private Transform transformLow;
    [SerializeField] private Transform transformMid;
    [SerializeField] private Transform transformHigh;

    [SerializeField] private PlatformIndexes platformIndexes;
    
    private List<GameObject> _spawnerPlatforms = new();

    private float currentX;

    private void Awake()
    {
        currentX = transformLow.position.x;
    }

    public void SpawnPlatform(Platform platformData, PathLevel pathLevel)
    {
        var prefab = platformIndexes.GetPlatformByIndex(platformData.Id);
        float y = GetYPosition(pathLevel);
        Vector3 spawnPos = new(currentX, y, 0);

        var platform = Instantiate(prefab, spawnPos, prefab.transform.rotation);

        _spawnerPlatforms.Add(platform);

        currentX += platformData.Width;
    }

    private float GetYPosition(PathLevel pathLevel)
    {
        switch (pathLevel)
        {
            case PathLevel.Low: return transformLow.position.y;
            case PathLevel.Middle: return transformMid.position.y;
            case PathLevel.High: return transformHigh.position.y;
            default: return transformHigh.position.y;
        }
    }
}

[Serializable]
public class PlatformIndexes
{
    [SerializeField] private List<PlatformIndex> platformIndexes = new(); 

    public GameObject GetPlatformByIndex(int index)
    {
        return platformIndexes.FirstOrDefault(data => data.Index == index).Platform;
    }
}

[Serializable]
public class PlatformIndex
{
    public GameObject Platform => platform;
    public int Index => index;

    [SerializeField] private GameObject platform;
    [SerializeField] private int index;
}
