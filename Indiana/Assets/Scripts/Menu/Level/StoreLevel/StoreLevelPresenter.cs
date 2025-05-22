using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreLevelPresenter : IStoreLevelProvider, IStoreLevelEventsProvider
{
    private readonly StoreLevelModel _model;

    public StoreLevelPresenter(StoreLevelModel model)
    {
        _model = model;
    }

    public void Initialize()
    {
        _model.Initialize();
    }

    public void Dispose()
    {
        _model.Dispose();
    }



    #region Output

    public event Action<int, bool> OnChangeStatusLevel
    {
        add => _model.OnChangeStatusLevel += value;
        remove => _model.OnChangeStatusLevel -= value;
    }

    #endregion



    #region Input

    public void OpenLevel(int id)
    {
        _model.OpenLevel(id);
    }

    #endregion
}

public interface IStoreLevelProvider
{
    void OpenLevel(int id);
}

public interface IStoreLevelEventsProvider
{
    public event Action<int, bool> OnChangeStatusLevel;
}
