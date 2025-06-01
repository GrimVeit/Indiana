using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreWeaponPresenter : IStoreWeaponProvider, IStoreWeaponsEventsProvider
{
    private readonly StoreWeaponModel _model;

    public StoreWeaponPresenter(StoreWeaponModel model)
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

    public event Action<Weapon, int> OnChangeCountWeapon
    {
        add => _model.OnChangeCountWeapon += value;
        remove => _model.OnChangeCountWeapon -= value;
    }

    #endregion

    #region Input

    public void AddWeapon(int id)
    {
        _model.AddWeapon(id);
    }

    public void RemoveWeapon(int id)
    {
        _model.RemoveWeapon(id);
    }

    #endregion
}

public interface IStoreWeaponsEventsProvider
{
    public event Action<Weapon, int> OnChangeCountWeapon;
}

public interface IStoreWeaponProvider
{
    void AddWeapon(int id);
    void RemoveWeapon(int id);
}
