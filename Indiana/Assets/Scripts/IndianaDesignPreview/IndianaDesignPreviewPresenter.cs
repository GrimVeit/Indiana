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
    }

    public void Dispose()
    {
        DeactivateEvents();
    }

    private void ActivateEvents()
    {

    }

    private void DeactivateEvents()
    {

    }
}
