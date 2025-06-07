using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "PlatformPath", menuName = "Game/Platform/Path")]
public class PlatformPath : ScriptableObject
{
    public List<PlatformUnit> platformsUnit = new();
}

[Serializable]
public class PlatformUnit
{
    public Platform Platform => platform;
    public ZoneType ZoneType => zoneType;
    public PathLevel PathLevel => pathLevel;
    public ObstacleChances ObstacleChances => obstacleChances;
    public TrophyChances TrophyChances => trophyChances;
    public WeaponChances WeaponChances => weaponChances;
    public CoinsChances CoinsChances => coinsChances;


    [SerializeField] private Platform platform;
    [SerializeField] private ZoneType zoneType;

    [Header("Level")]
    [SerializeField] private PathLevel pathLevel;

    [Header("Obstacle")]
    [SerializeField] private ObstacleChances obstacleChances;

    [Header("Trophy")]
    [SerializeField] private TrophyChances trophyChances;

    [Header("Weapon")]
    [SerializeField] private WeaponChances weaponChances;

    [Header("Coins")]
    [SerializeField] private CoinsChances coinsChances;

}

public enum ZoneType
{
    Usual, Start, End
}

public enum PathLevel
{
    Low, Middle, High
}





[Serializable]
public class ObstacleChances
{
    public bool IsSpawnedObstacle => isSpawnedObstacle;

    [SerializeField] private List<ObstacleChance> obstacleChances = new();
    [SerializeField] private bool isSpawnedObstacle;

    public int GetRandomIndexObstacle()
    {
        float totalChance = 0;

        obstacleChances.ForEach(data => totalChance += data.DropChance);

        float randomPoint = Random.Range(0, totalChance);
        float currentSum = 0f;

        foreach (var data in obstacleChances)
        {
            currentSum += data.DropChance;

            if(randomPoint <= currentSum)
            {
                return data.IdObstacle;
            }
        }

        return -1;
    }
}

[Serializable]
public class ObstacleChance
{
    public int IdObstacle => idObstacle;
    public float DropChance => dropChance;

    [SerializeField] private int idObstacle;
    [SerializeField] private float dropChance;
}




[Serializable]
public class TrophyChances
{
    public bool IsSpawnedTrophy => isSpawnedTrophy;

    [SerializeField] private List<TrophyChance> trophyChances = new();
    [SerializeField] private bool isSpawnedTrophy;

    public int GetRandomIndexTrophy()
    {
        float totalChance = 0;

        trophyChances.ForEach(data => totalChance += data.DropChance);

        float randomPoint = Random.Range(0, totalChance);
        float currentSum = 0f;

        foreach (var data in trophyChances)
        {
            currentSum += data.DropChance;

            if (randomPoint <= currentSum)
            {
                return data.IdTrophy;
            }
        }

        return -1;
    }
}

[Serializable]
public class TrophyChance
{
    public int IdTrophy => idTrophy;
    public float DropChance => dropChance;

    [SerializeField] private int idTrophy;
    [SerializeField] private float dropChance;
}




[Serializable]
public class WeaponChances
{
    public bool IsSpawnerWeapon => isSpawnedWeapon;

    [SerializeField] private List<WeaponChance> weaponChances = new();
    [SerializeField] private bool isSpawnedWeapon;

    public int GetRandomIndexWeapon()
    {
        float totalChance = 0;

        weaponChances.ForEach(data => totalChance += data.DropChance);

        float randomPoint = Random.Range(0, totalChance);
        float currentSum = 0f;

        foreach (var data in weaponChances)
        {
            currentSum += data.DropChance;

            if (randomPoint <= currentSum)
            {
                return data.IdWeapon;
            }
        }

        return -1;
    }
}

[Serializable]
public class WeaponChance
{
    public int IdWeapon => idWeapon;
    public float DropChance => dropChance;

    [SerializeField] private int idWeapon;
    [SerializeField] private float dropChance;
}





[Serializable]
public class CoinsChances
{
    public bool IsSpawnedCoins => isSpawnedCoins;

    [SerializeField] private List<CoinChance> coinChances = new();
    [SerializeField] private bool isSpawnedCoins;

    public int GetRandomIndexCoinsGroup()
    {
        float totalChance = 0;

        coinChances.ForEach(data => totalChance += data.DropChance);

        float randomPoint = Random.Range(0, totalChance);
        float currentSum = 0f;

        foreach (var data in coinChances)
        {
            currentSum += data.DropChance;

            if (randomPoint <= currentSum)
            {
                return data.IdCoins;
            }
        }

        return -1;
    }
}

[Serializable]
public class CoinChance
{
    public int IdCoins => idCoins;
    public float DropChance => dropChance;

    [SerializeField] private int idCoins;
    [SerializeField] private float dropChance;
}
