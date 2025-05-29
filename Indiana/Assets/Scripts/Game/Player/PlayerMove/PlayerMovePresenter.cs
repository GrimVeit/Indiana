using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovePresenter : IPlayerMoveProvider, IPlayerJumpMoveProvider
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
    }

    private void DeactivateEvents()
    {
        _view.OnChangeState -= _model.SetState;

        _model.OnJump -= _view.Jump;
        _model.OnStartRun -= _view.StartRun;
        _model.OnStopRun -= _view.StopRun;
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
}
