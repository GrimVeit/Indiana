using System;
using System.Numerics;
public class ObstacleSpawnerModel
{
    public event Action<int, Vector3> OnSpawnObstacle;

    private readonly IHealthRemoveProvider _healthRemoveProvider;

    public ObstacleSpawnerModel(IHealthRemoveProvider healthRemoveProvider)
    {
        _healthRemoveProvider = healthRemoveProvider;
    }

    public void SpawnObstacle(ObstacleChances obstacleChances, Vector3 position)
    {
        if(!obstacleChances.IsSpawnedObstacle) return;

        var index = obstacleChances.GetRandomIndexObstacle();

        if(index < 0)
        {
            UnityEngine.Debug.Log("Not found obstacle with index - " + index);
            return;
        }

        OnSpawnObstacle?.Invoke(index, position);
    }

    public void SendObstacle(int damage)
    {
        _healthRemoveProvider.RemoveHealth(damage);
    }
}
