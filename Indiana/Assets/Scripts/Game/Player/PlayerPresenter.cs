using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPresenter
{
    private readonly PlayerModel _model;
    private readonly PlayerView _view;

    public PlayerPresenter(PlayerModel model, PlayerView view)
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

    #region Input

    public void Run()
    {

    }

    public void Jump()
    {

    }

    public void Attack()
    {

    }

    public void Die()
    {

    }

    #endregion
}
