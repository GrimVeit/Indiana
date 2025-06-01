using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationPresenter : IPlayerAnimationProvider
{
    private readonly PlayerAnimationModel _model;
    private readonly PlayerAnimationView _view;

    public PlayerAnimationPresenter(PlayerAnimationModel model, PlayerAnimationView view)
    {
        _model = model; _view = view;
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
        _model.OnChangeSprite += _view.SetSprite;
    }

    private void DeactivateEvents()
    {
        _model.OnChangeSprite -= _view.SetSprite;
    }

    #region Input

    public void Run()
    {
        _model.Run();
    }

    public void Jump()
    {
        _model.Jump();
    }

    public void Die()
    {
        _model.Die();
    }

    public void AttackPunch()
    {
        _model.AttackPunch();
    }

    public void AttackKnife()
    {
        _model.AttackKnife();
    }

    public void AttackWhip()
    {
        _model.AttackWhip();
    }

    public void Pause()
    {
        _model.Pause();
    }

    public void Resume()
    {
        _model.Resume();
    }

    #endregion
}

public interface IPlayerAnimationProvider
{
    void Run();
    void Jump();
    void Die();

    public void AttackPunch();
    public void AttackKnife();
    public void AttackWhip();


    void Pause();
    void Resume();
}
