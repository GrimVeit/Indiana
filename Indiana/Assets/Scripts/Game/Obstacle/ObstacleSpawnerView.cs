using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawnerView : View
{
    [SerializeField] private ObstacleIndexes obstacleIndexes;

    private readonly List<Obstacle> _spawnedObstacles = new();

    public void SpawnObstacle(int index, System.Numerics.Vector3 position)
    {
        var prefab = obstacleIndexes.GetObstacleByIndex(index);

        var obstacle = Instantiate(prefab, new Vector3(position.X, position.Y, position.Z), prefab.transform.rotation);
        obstacle.Activate();
        _spawnedObstacles.Add(obstacle);
    }

    public void DestroyObstacle(Obstacle obstacle)
    {
        _spawnedObstacles.Remove(obstacle);

        obstacle.Deactivate();
    }
}

[Serializable]
public class ObstacleIndexes
{
    [SerializeField] private List<ObstacleIndex> obstacleIndexes = new();

    public Obstacle GetObstacleByIndex(int index)
    {
        return obstacleIndexes.FirstOrDefault(data => data.Index == index).Obstacle;
    }
}

[Serializable]
public class ObstacleIndex
{
    public Obstacle Obstacle => obstacle;
    public int Index => index;

    [SerializeField] private Obstacle obstacle;
    [SerializeField] private int index;
}
