using System;
using System.Numerics;

public class PlatformSpawnModel
{
    public event Action<PlatformUnit> OnSpawnPlatform;

    private readonly PlatformPathGroup _platformPathGroup;

    private readonly IObstacleSpawnerProvider _obstacleSpawnerProvider;
    private readonly ITrophySpawnerProvider _trophySpawnerProvider;
    private readonly IWeaponSpawnerProvider _weaponSpawnerProvider;
    private readonly IZoneSpawnerProvider _zoneSpawnerProvider;
    private readonly ICoinSpawnerProvider _coinSpawnerProvider;

    public PlatformSpawnModel(PlatformPathGroup platformPathGroup, IObstacleSpawnerProvider obstacleSpawnerProvider, ITrophySpawnerProvider trophySpawnerProvider, IZoneSpawnerProvider zoneSpawnerProvider, IWeaponSpawnerProvider weaponSpawnerProvider, ICoinSpawnerProvider coinSpawnerProvider)
    {
        _platformPathGroup = platformPathGroup;
        _obstacleSpawnerProvider = obstacleSpawnerProvider;
        _trophySpawnerProvider = trophySpawnerProvider;
        _zoneSpawnerProvider = zoneSpawnerProvider;
        _weaponSpawnerProvider = weaponSpawnerProvider;
        _coinSpawnerProvider = coinSpawnerProvider;
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
        _zoneSpawnerProvider.SpawnZone(platform.ZoneType, position);
        _weaponSpawnerProvider.SpawnWeapon(platform.WeaponChances, position);
        _coinSpawnerProvider.SpawnCoins(platform.CoinsChances, position);
    }
}
