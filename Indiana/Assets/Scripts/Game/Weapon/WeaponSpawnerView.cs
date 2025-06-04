using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponSpawnerView : View
{
    [SerializeField] private WeaponIndexes weaponIndexes;

    private readonly List<WeaponItem> _spawnedWeapons = new();

    public void SpawnWeapon(int index, System.Numerics.Vector3 position)
    {
        var prefab = weaponIndexes.GetWeaponByIndex(index);

        var trophy = Instantiate(prefab, new Vector3(position.X, position.Y, position.Z), prefab.transform.rotation);
        trophy.OnSendWeapon += SendWeapon;
        trophy.Activate();

        _spawnedWeapons.Add(trophy);
    }

    public void DestroyWeapon(WeaponItem weapon)
    {
        weapon.OnSendWeapon -= SendWeapon;

        _spawnedWeapons.Remove(weapon);

        weapon.Deactivate();
    }

    #region Output

    public event Action<int> OnSendWeapon;

    private void SendWeapon(WeaponItem weapon)
    {
        int id = weapon.Id;

        OnSendWeapon?.Invoke(id);

        DestroyWeapon(weapon);
    }

    #endregion
}

[Serializable]
public class WeaponIndexes
{
    [SerializeField] private List<WeaponIndex> weaponIndexes = new();

    public WeaponItem GetWeaponByIndex(int index)
    {
        return weaponIndexes.FirstOrDefault(data => data.Index == index).Weapon;
    }
}

[Serializable]
public class WeaponIndex
{
    public WeaponItem Weapon => weapon;
    public int Index => index;

    [SerializeField] private WeaponItem weapon;
    [SerializeField] private int index;
}
