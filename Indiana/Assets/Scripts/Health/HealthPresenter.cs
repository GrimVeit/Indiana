using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPresenter : IHealthRemoveProvider, ILoseEventProvider
{
    private readonly HealthModel _model;
    private readonly HealthView _view;

    public HealthPresenter(HealthModel model, HealthView view)
    {
        _model = model; _view = view;
    }

    public void Initialize()
    {
        ActtivateEvents();

        _model.Initalize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        _model.Dispose();
    }

    private void ActtivateEvents()
    {
        _model.OnChangeHealth += _view.ChangeHealthCount;
    }

    private void DeactivateEvents()
    {
        _model.OnChangeHealth -= _view.ChangeHealthCount;
    }

    #region Input

    public void AddHealth(int health)
    {
        _model.AddHealth(health);
    }

    public void RemoveHealth(int health)
    {
        _model.RemoveHealth(health);
    }

    #endregion

    #region Output

    public event Action OnLose
    {
        add => _model.OnLose += value;
        remove => _model.OnLose -= value;
    }

    #endregion
}

public interface IHealthRemoveProvider
{
    void RemoveHealth(int health);
}

public interface ILoseEventProvider
{
    public event Action OnLose;
}
