using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndianaPreviewInputPresenter
{
    private readonly IndianaPreviewInputModel _model;
    private readonly IndianaPreviewInputView _view;

    public IndianaPreviewInputPresenter(IndianaPreviewInputModel model, IndianaPreviewInputView view)
    {
        _model = model;
        _view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        _view.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        _view.Dispose();
    }

    private void ActivateEvents()
    {
        _view.OnSetItem += _model.ChooseClothes;
    }

    private void DeactivateEvents()
    {
        _view.OnSetItem -= _model.ChooseClothes;
    }
}
