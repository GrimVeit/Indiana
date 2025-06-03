using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonsHiderPresenter : IGameButtonsHiderProvider
{
    private readonly GameButtonsHiderModel _model;
    private readonly GameButtonsHiderView _view;

    public GameButtonsHiderPresenter(GameButtonsHiderModel model, GameButtonsHiderView view)
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
        _model.OnHideButtons += _view.Hide;
        _model.OnShowButtons += _view.Show;
    }

    private void DeactivateEvents()
    {
        _model.OnHideButtons -= _view.Hide;
        _model.OnShowButtons -= _view.Show;
    }

    #region Input

    public void Show()
    {
        _model.Show();
    }

    public void Hide()
    {
        _model.Hide();
    }

    #endregion
}

public interface IGameButtonsHiderProvider
{
    void Show();
    void Hide();
}
