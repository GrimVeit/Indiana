using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

public class PlatformSpawnModel
{
    public event Action<PlatformUnit> OnSpawnPlatform;

    private readonly PlatformPathGroup _platformPathGroup;
    private readonly IObstacleSpawnerProvider _obstacleSpawnerProvider;

    public PlatformSpawnModel(PlatformPathGroup platformPathGroup, IObstacleSpawnerProvider obstacleSpawnerProvider)
    {
        _platformPathGroup = platformPathGroup;
        _obstacleSpawnerProvider = obstacleSpawnerProvider;

    }

    public void SpawnRandoomPath()
    {
        var path = _platformPathGroup.GetPlatformPathRandom();

        for (int i = 0; i < path.platformsUnit.Count; i++)
        {
            OnSpawnPlatform?.Invoke(path.platformsUnit[i]);
        }
    }

    public void SpawnPlatform(PlatformUnit platform, Vector3 position)
    {
        _obstacleSpawnerProvider.SpawnObstacle(platform.ObstacleChances, position);
    }
}
