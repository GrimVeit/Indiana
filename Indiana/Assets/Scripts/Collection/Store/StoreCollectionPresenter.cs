using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreCollectionPresenter : IItemCollectionProvider, IItemCollectionEventsProvider
{
    private readonly StoreCollectionModel _model;

    public StoreCollectionPresenter(StoreCollectionModel model)
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

    public event Action<ItemCollection, int> OnChangeCountItem
    {
        add => _model.OnChangeCountItem += value;
        remove => _model.OnChangeCountItem -= value;
    }

    #endregion



    #region Input

    public void AddItemCollection(int id)
    {
        _model.AddItemCollection(id);
    }

    #endregion
}

public interface IItemCollectionEventsProvider
{
    public event Action<ItemCollection, int> OnChangeCountItem;
}

public interface IItemCollectionProvider
{
    void AddItemCollection(int id);
}
