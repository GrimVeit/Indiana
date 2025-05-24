using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPresenter
{
    private readonly CameraModel _model;
    private readonly CameraView _view;

    public CameraPresenter(CameraModel model, CameraView view)
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
        _model.OnActivateLookAt += _view.ActivateLookAt;
        _model.OnDeactivateLookAt += _view.DeactivateLookAt;
    }

    private void DeactivateEvents()
    {
        _model.OnActivateLookAt -= _view.ActivateLookAt;
        _model.OnDeactivateLookAt -= _view.DeactivateLookAt;
    }

    #region Input

    public void ActivateLookAt()
    {
        _model.ActivateLookAt();
    }

    public void DeactivateLookAt()
    {
        _model.DeactivateLookAt();
    }

    #endregion
}
