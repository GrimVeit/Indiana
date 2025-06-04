using System;
using System.Numerics;

public class WeaponSpawnerModel
{
    public event Action<int, Vector3> OnSpawnWeapon;

    private readonly IStoreWeaponProvider _storeWeaponProvider;

    public WeaponSpawnerModel(IStoreWeaponProvider storeWeaponProvider)
    {
        _storeWeaponProvider = storeWeaponProvider;
    }

    public void SpawnWeapon(WeaponChances weaponChances, Vector3 position)
    {
        var index = weaponChances.GetRandomIndexWeapon();

        if (index < 0)
        {
            UnityEngine.Debug.Log("Not found weapon with index - " + index);
            return;
        }

        OnSpawnWeapon?.Invoke(index, position);
    }

    public void SendWeapon(int id)
    {
        _storeWeaponProvider.AddWeapon(id);
    }
}
