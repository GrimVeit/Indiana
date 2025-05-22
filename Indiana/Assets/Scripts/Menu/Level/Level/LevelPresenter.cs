using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPresenter
{
    private readonly LevelModel _model;
    private readonly LevelView _view;

    public LevelPresenter(LevelModel model, LevelView view)
    {
        _model = model; _view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        _model.Initialize();
        _view.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        _model.Dispose();
        _view.Dispose();
    }

    private void ActivateEvents()
    {
        _view.OnActivateLevel += _model.ActivateLevel;
    }

    private void DeactivateEvents()
    {
        _view.OnActivateLevel -= _model.ActivateLevel;
    }
}
