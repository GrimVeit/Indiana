using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnPresenter
{
    private readonly PlatformSpawnModel _model;
    private readonly PlatformSpawnView _view;

    public PlatformSpawnPresenter(PlatformSpawnModel model, PlatformSpawnView view)
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
        _view.OnSpawnedPlatform += _model.SpawnPlatform;

        _model.OnSpawnPlatform += _view.SpawnPlatform;
    }

    private void DeactivateEvents()
    {
        _view.OnSpawnedPlatform -= _model.SpawnPlatform;

        _model.OnSpawnPlatform -= _view.SpawnPlatform;
    }

    #region Input

    public void SpawnPlatforms()
    {
        _model.SpawnRandoomPath();
    }

    #endregion
}
