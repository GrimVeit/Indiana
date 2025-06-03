using System.Collections;
using System.Collections.Generic;
using System.Numerics;

public class TrophySpawnerPresenter : ITrophySpawnerProvider
{
    private readonly TrophySpawnerModel _model;
    private readonly TrophySpawnerView _view;

    public TrophySpawnerPresenter(TrophySpawnerModel model, TrophySpawnerView view)
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
        _view.OnSendTrophy += _model.SendTrophy;

        _model.OnSpawnTrophy += _view.SpawnTrophy;
    }

    private void DeactivateEvents()
    {
        _view.OnSendTrophy -= _model.SendTrophy;

        _model.OnSpawnTrophy -= _view.SpawnTrophy;
    }


    #region Input

    public void SpawnTrophy(TrophyChances obstacleChances, Vector3 spawnPosition)
    {
        _model.SpawnTrophy(obstacleChances, spawnPosition);
    }

    #endregion
}

public interface ITrophySpawnerProvider
{
    void SpawnTrophy(TrophyChances obstacleChances, Vector3 spawnPosition);
}
