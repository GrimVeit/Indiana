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
    public PathLevel PathLevel => pathLevel;
    public ObstacleChances ObstacleChances => obstacleChances;

    [SerializeField] private Platform platform;

    [Header("Level")]
    [SerializeField] private PathLevel pathLevel;

    [Header("Obstacle")]
    [SerializeField] private ObstacleChances obstacleChances;

}

public enum PathLevel
{
    Low, Middle, High
}

[Serializable]
public class ObstacleChances
{
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
