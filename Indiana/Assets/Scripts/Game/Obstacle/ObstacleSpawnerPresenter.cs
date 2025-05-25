using System.Collections;
using System.Collections.Generic;
using System.Numerics;

public class ObstacleSpawnerPresenter : IObstacleSpawnerProvider
{
    private readonly ObstacleSpawnerModel _model;
    private readonly ObstacleSpawnerView _view;

    public ObstacleSpawnerPresenter(ObstacleSpawnerModel model, ObstacleSpawnerView view)
    {
        _model = model;
        _view = view;
    }

    public void Initialize()
    {
        ActivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();
    }

    private void ActivateEvents()
    {
        _model.OnSpawnObstacle += _view.SpawnObstacle;
    }

    private void DeactivateEvents()
    {
        _model.OnSpawnObstacle -= _view.SpawnObstacle;
    }

    #region Input

    public void SpawnObstacle(ObstacleChances obstacleChances, Vector3 spawnPosition)
    {
        _model.SpawnObstacle(obstacleChances, spawnPosition);
    }

    #endregion
}

public interface IObstacleSpawnerProvider
{
    void SpawnObstacle(ObstacleChances obstacleChances, Vector3 spawnPosition);
}
