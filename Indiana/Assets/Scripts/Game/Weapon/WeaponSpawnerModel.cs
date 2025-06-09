using System;
using System.Numerics;

public class WeaponSpawnerModel
{
    public event Action<int, Vector3> OnSpawnWeapon;

    private readonly IStoreWeaponProvider _storeWeaponProvider;
    private readonly ISoundProvider _soundProvider;

    public WeaponSpawnerModel(IStoreWeaponProvider storeWeaponProvider, ISoundProvider soundProvider)
    {
        _storeWeaponProvider = storeWeaponProvider;
        _soundProvider = soundProvider;

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

        _soundProvider.PlayOneShot("Item");
    }
}
