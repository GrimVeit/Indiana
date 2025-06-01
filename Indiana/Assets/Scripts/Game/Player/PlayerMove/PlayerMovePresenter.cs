using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovePresenter : IPlayerMoveProvider, IPlayerJumpMoveProvider, IPlayerGroundEventsProvider
{
    private readonly PlayerMoveModel _model;
    private readonly PlayerMoveView _view;

    public PlayerMovePresenter(PlayerMoveModel model, PlayerMoveView view)
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
        _view.OnChangeState += _model.SetState;

        _model.OnJump += _view.Jump;
        _model.OnStartRun += _view.StartRun;
        _model.OnStopRun += _view.StopRun;

        _model.OnFreezeEnd += _view.Unfreeze;
        _model.OnFreeze += _view.Freeze;
    }

    private void DeactivateEvents()
    {
        _view.OnChangeState -= _model.SetState;

        _model.OnJump -= _view.Jump;
        _model.OnStartRun -= _view.StartRun;
        _model.OnStopRun -= _view.StopRun;

        _model.OnFreezeEnd -= _view.Unfreeze;
        _model.OnFreeze -= _view.Freeze;
    }

    #region Output

    public event Action OnPlayerInGround
    {
        add => _model.OnPlayerInGround += value;
        remove => _model.OnPlayerInGround -= value;
    }

    public event Action OnPlayerOutGround
    {
        add => _model.OnPlayerOutGround += value;
        remove => _model.OnPlayerOutGround -= value;
    }

    #endregion

    #region Input

    public void StartRun()
    {
        _model.StartRun();
    }

    public void StopRun()
    {
        _model.StopRun();
    }

    public void Jump()
    {
        _model.Jump();
    }

    public void Freeze()
    {
        _model.Freeze();
    }

    public void Unfreeze()
    {
        _model.Unfreeze();
    }

    #endregion
}

public interface IPlayerJumpMoveProvider
{
    void Jump();
}

public interface IPlayerMoveProvider
{
    void StartRun();
    void StopRun();
    void Jump();
    void Freeze();
    void Unfreeze();
}

public interface IPlayerGroundEventsProvider
{
    public event Action OnPlayerInGround;

    public event Action OnPlayerOutGround;
}
