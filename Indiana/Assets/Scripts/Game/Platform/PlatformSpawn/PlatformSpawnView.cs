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
    
    private readonly List<GameObject> _spawnerPlatforms = new();

    private float currentX;

    private void Awake()
    {
        currentX = transformLow.position.x;
    }

    public void SpawnPlatform(PlatformUnit platformUnit)
    {
        var prefab = platformIndexes.GetPlatformByIndex(platformUnit.Platform.Id);
        float y = GetYPosition(platformUnit.PathLevel);
        Vector3 spawnPos = new(currentX, y, 0);

        var platform = Instantiate(prefab, spawnPos, prefab.transform.rotation);

        _spawnerPlatforms.Add(platform);

        currentX += platformUnit.Platform.Width;

        OnSpawnedPlatform?.Invoke(platformUnit, platform.transform.GetChild(0).transform.position.ToSystemVector3());
    }

    private float GetYPosition(PathLevel pathLevel)
    {
        return pathLevel switch
        {
            PathLevel.Low => transformLow.position.y,
            PathLevel.Middle => transformMid.position.y,
            PathLevel.High => transformHigh.position.y,
            _ => transformHigh.position.y,
        };
    }

    #region Output

    public event Action<PlatformUnit, System.Numerics.Vector3> OnSpawnedPlatform;

    #endregion
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
