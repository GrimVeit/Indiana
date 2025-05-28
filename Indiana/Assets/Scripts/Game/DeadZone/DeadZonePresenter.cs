using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZonePresenter
{
    private readonly DeadZoneModel _model;
    private readonly DeadZoneView _view;

    public DeadZonePresenter(DeadZoneModel model, DeadZoneView view)
    {
        _model = model; _view = view;
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
        _view.OnSendDeadZone += _model.SendDeadZone;
    }

    private void DeactivateEvents()
    {

    }
}
