using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

public class ZonePresenter : IZoneSpawnerProvider, IGameEventsProvider
{
    private readonly ZoneModel _model;
    private readonly ZoneView _view;

    public ZonePresenter(ZoneModel model, ZoneView view)
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
        _model.OnSpawnZone += _view.SpawnZone;

        _view.OnSendZone += _model.SendZone;
    }

    private void DeactivateEvents()
    {
        _model.OnSpawnZone -= _view.SpawnZone;

        _view.OnSendZone -= _model.SendZone;
    }

    #region Output

    public event Action OnStart
    {
        add => _model.OnStart += value;
        remove => _model.OnStart -= value;
    }

    public event Action OnStop
    {
        add => _model.OnStop += value;
        remove => _model.OnStop -= value;
    }

    #endregion

    #region Input

    public void SpawnZone(ZoneType platformType, Vector3 spawnPosition)
    {
        _model.SpawnZone(platformType, spawnPosition);
    }

    #endregion
}

public interface IZoneSpawnerProvider
{
    void SpawnZone(ZoneType platformType, Vector3 spawnPosition);
}

public interface IGameEventsProvider
{
    public event Action OnStart;
    public event Action OnStop;
}
