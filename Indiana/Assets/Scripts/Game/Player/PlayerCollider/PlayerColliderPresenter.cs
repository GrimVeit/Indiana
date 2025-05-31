using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderPresenter : IPlayerColliderProvider
{
    private readonly PlayerColliderModel _model;
    private readonly PlayerColliderView _view;

    public PlayerColliderPresenter(PlayerColliderModel model, PlayerColliderView view)
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
        _model.OnActivateDie += _view.ActivateDie;
        _model.OnActivateNormal += _view.ActivateNormal;
    }

    private void DeactivateEvents()
    {
        _model.OnActivateDie -= _view.ActivateDie;
        _model.OnActivateNormal -= _view.ActivateNormal;
    }

    #region Input

    public void ActivateNormal()
    {
        _model.ActivateNormal();
    }

    public void ActivateDie()
    {
        _model.ActivateDie();
    }

    #endregion
}

public interface IPlayerColliderProvider
{
    public void ActivateNormal();

    public void ActivateDie();
}
