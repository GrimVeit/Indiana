using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreClothesPresenter : IStoreClothesProvider, IStoreClothesEventsProvider
{
    private readonly StoreClothesModel _model;

    public StoreClothesPresenter(StoreClothesModel model)
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

    public event Action<int> OnChooseDesign
    {
        add => _model.OnChooseDesign += value;
        remove => _model.OnChooseDesign -= value;
    }

    #endregion


    #region Input

    public void ChooseClothes(int clothesId, int id)
    {
        _model.ChooseClothes(clothesId, id);
    }

    #endregion
}

public interface IStoreClothesProvider
{
    void ChooseClothes(int clothesId, int id);
}

public interface IStoreClothesEventsProvider
{
    public event Action<int> OnChooseDesign;
}
