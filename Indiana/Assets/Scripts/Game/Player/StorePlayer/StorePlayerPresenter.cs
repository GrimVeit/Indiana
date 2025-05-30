using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePlayerPresenter : IStorePlayerDesignEventsProvider
{
    private readonly StorePlayerModel _model;

    public StorePlayerPresenter(StorePlayerModel model)
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

    public event Action<PlayerDesign> OnChooseDesign
    {
        add => _model.OnChooseDesign += value;
        remove => _model.OnChooseDesign -= value;
    }

    #endregion
}

public interface IStorePlayerDesignEventsProvider
{
    public event Action<PlayerDesign> OnChooseDesign;
}
