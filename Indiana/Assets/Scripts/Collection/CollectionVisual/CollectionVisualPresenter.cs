using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionVisualPresenter
{
    private readonly CollectionVisualModel _model;
    private readonly CollectionVisualView _view;

    public CollectionVisualPresenter(CollectionVisualModel model, CollectionVisualView view)
    {
        _model = model;
        _view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        _model.Initialize();
    }

    public void Dispose()
    {
        DeaactivateEvents();

        _model.Dispose();
    }

    private void ActivateEvents()
    {
        _model.OnChangeCountItem += _view.SetData;
    }

    private void DeaactivateEvents()
    {
        _model.OnChangeCountItem -= _view.SetData;
    }
}
