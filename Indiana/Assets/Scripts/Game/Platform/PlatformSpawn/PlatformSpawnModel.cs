using System;
using System.Numerics;

public class PlatformSpawnModel
{
    public event Action<PlatformUnit> OnSpawnPlatform;

    private readonly PlatformPathGroup _platformPathGroup;

    private readonly IObstacleSpawnerProvider _obstacleSpawnerProvider;
    private readonly ITrophySpawnerProvider _trophySpawnerProvider;   

    public PlatformSpawnModel(PlatformPathGroup platformPathGroup, IObstacleSpawnerProvider obstacleSpawnerProvider, ITrophySpawnerProvider trophySpawnerProvider)
    {
        _platformPathGroup = platformPathGroup;
        _obstacleSpawnerProvider = obstacleSpawnerProvider;
        _trophySpawnerProvider = trophySpawnerProvider;
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
        _trophySpawnerProvider.SpawnTrophy(platform.TrophyChances, position);
    }
}
