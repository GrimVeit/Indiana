using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndianaDesignPreviewPresenter
{
    private readonly IndianaDesignPreviewModel _model;
    private readonly IndianaDesignPreviewView _view;

    public IndianaDesignPreviewPresenter(IndianaDesignPreviewModel model, IndianaDesignPreviewView view)
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
        DeactivateEvents();

        _model.Dispose();
    }

    private void ActivateEvents()
    {
        _model.OnChooseDesign += _view.SetData;
    }

    private void DeactivateEvents()
    {
        _model.OnChooseDesign -= _view.SetData;
    }
}
