using System;
using System.Numerics;
public class ObstacleSpawnerModel
{
    public event Action<int, Vector3> OnSpawnObstacle;

    public void SpawnObstacle(ObstacleChances obstacleChances, Vector3 position)
    {
        if(!obstacleChances.IsSpawnerObstacle) return;

        var index = obstacleChances.GetRandomIndexObstacle();

        if(index < 0)
        {
            UnityEngine.Debug.Log("Not found obstacle with index - " + index);
            return;
        }

        OnSpawnObstacle?.Invoke(index, position);
    }
}
