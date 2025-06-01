using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMenuVisualModel
{
    public event Action<int, int> OnChangeCountWeapon;

    private readonly IStoreWeaponsEventsProvider _storeWeaponsEventsProvider;

    public WeaponMenuVisualModel(IStoreWeaponsEventsProvider storeWeaponsEventsProvider)
    {
        _storeWeaponsEventsProvider = storeWeaponsEventsProvider;
        _storeWeaponsEventsProvider.OnChangeCountWeapon += ChangeItemCollectionCount;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _storeWeaponsEventsProvider.OnChangeCountWeapon -= ChangeItemCollectionCount;
    }

    private void ChangeItemCollectionCount(Weapon weapon, int count)
    {
        OnChangeCountWeapon?.Invoke(weapon.Id, count);
    }
}
