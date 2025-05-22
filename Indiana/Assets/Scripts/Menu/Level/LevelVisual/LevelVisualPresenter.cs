using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelVisualPresenter
{
    private readonly LevelVisualModel _model;
    private readonly LevelVisualView _view;

    public LevelVisualPresenter(LevelVisualModel model, LevelVisualView view)
    {
        _model = model;
        _view = view;
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
        _view.OnChooseLevel += _model.SelectLevel;

        _model.OnOpenVisual += _view.Open;
        _model.OnCloseVisual += _view.Close;
    }

    private void DeactivateEvents()
    {
        _view.OnChooseLevel -= _model.SelectLevel;

        _model.OnOpenVisual -= _view.Open;
        _model.OnCloseVisual -= _view.Close;
    }
}
