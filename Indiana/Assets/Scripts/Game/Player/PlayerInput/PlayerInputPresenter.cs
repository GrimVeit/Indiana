using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputPresenter
{
    private readonly PlayerInputModel _model;
    private readonly PlayerInputView _view;

    public PlayerInputPresenter(PlayerInputModel model, PlayerInputView view)
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
        _view.OnJump += _model.Jump;

        _view.OnHitPunch += _model.HitPunch;
        _view.OnHitKnife += _model.HitKnife;
        _view.OnHitWhip += _model.HitWhip;
    }

    private void DeactivateEvents()
    {
        _view.OnJump -= _model.Jump;

        _view.OnHitPunch -= _model.HitPunch;
        _view.OnHitKnife -= _model.HitKnife;
        _view.OnHitWhip -= _model.HitWhip;
    }
}
