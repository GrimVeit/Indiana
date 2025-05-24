using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnModel
{
    public event Action<Platform, PathLevel> OnSpawnPlatform;

    private readonly PlatformPathGroup _platformPathGroup;

    public PlatformSpawnModel(PlatformPathGroup platformPathGroup)
    {
        _platformPathGroup = platformPathGroup;
    }

    public void SpawnRandoomPath()
    {
        var path = _platformPathGroup.GetPlatformPathRandom();

        for (int i = 0; i < path.platformsUnit.Count; i++)
        {
            OnSpawnPlatform?.Invoke(path.platformsUnit[i].Platform, path.platformsUnit[i].HighLevel);
        }
    }
}
