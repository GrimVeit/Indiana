using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZoneActionPresenter : IPlayerZoneActionProvider
{
    private readonly PlayerZoneActionModel _model;
    private readonly PlayerZoneActionView _view;

    public PlayerZoneActionPresenter(PlayerZoneActionModel model, PlayerZoneActionView view)
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
        _model.OnActivateSmallZone += _view.ActivateSmallZone;
        _model.OnActivateMiddleZone += _view.ActivateMiddleZone;
        _model.OnActivateBigZone += _view.ActivateBigZone;
    }

    private void DeactivateEvents()
    {
        _model.OnActivateSmallZone -= _view.ActivateSmallZone;
        _model.OnActivateMiddleZone -= _view.ActivateMiddleZone;
        _model.OnActivateBigZone -= _view.ActivateBigZone;
    }

    #region Input

    public void ActivateSmallZone()
    {
        _model.ActivateSmallZone();
    }

    public void ActivateMiddleZone()
    {
        _model.ActivateMiddleZone();
    }

    public void ActivateBigZone()
    {
        _model.ActivateBigZone();
    }

    #endregion
}

public interface IPlayerZoneActionProvider
{
    public void ActivateSmallZone();
    public void ActivateMiddleZone();
    public void ActivateBigZone();
}
