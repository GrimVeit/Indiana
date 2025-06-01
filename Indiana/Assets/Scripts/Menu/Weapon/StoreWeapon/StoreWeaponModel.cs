using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class StoreWeaponModel
{
    public event Action<Weapon, int> OnChangeCountWeapon;

    private readonly WeaponGroup _weaponGroup;

    private List<ItemWeaponData> _itemWeaponDatas = new List<ItemWeaponData>();

    public readonly string FilePath = Path.Combine(Application.persistentDataPath, "Weapons.json");

    public StoreWeaponModel(WeaponGroup weaponGroup)
    {
        _weaponGroup = weaponGroup;

        if (File.Exists(FilePath))
        {
            string loadedJson = File.ReadAllText(FilePath);
            ItemWeaponDatas itemWeaponDatas = JsonUtility.FromJson<ItemWeaponDatas>(loadedJson);

            Debug.Log("Load data");

            _itemWeaponDatas = itemWeaponDatas.Datas.ToList();
        }
        else
        {
            Debug.Log("New Data");

            _itemWeaponDatas = new List<ItemWeaponData>();

            for (int i = 0; i < _weaponGroup.weapons.Count; i++)
            {
                _itemWeaponDatas.Add(new ItemWeaponData(3));
            }
        }

        for (int i = 0; i < weaponGroup.weapons.Count; i++)
        {
            weaponGroup.weapons[i].SetData(_itemWeaponDatas[i]);
        }
    }

    public void Initialize()
    {
        for (int i = 0; i < _weaponGroup.weapons.Count; i++)
        {
            OnChangeCountWeapon?.Invoke(_weaponGroup.weapons[i], _weaponGroup.weapons[i].Data.Count);
        }
    }

    public void Dispose()
    {
        string json = JsonUtility.ToJson(new ItemWeaponDatas(_itemWeaponDatas.ToArray()));
        File.WriteAllText(FilePath, json);
    }

    public void AddWeapon(int id)
    {
        var weapon = _weaponGroup.GetWeaponById(id);

        if (weapon == null)
        {
            Debug.LogError($"Not found weapon by id - {id}");
            return;
        }

        weapon.Data.AddItem(1);
        OnChangeCountWeapon?.Invoke(weapon, weapon.Data.Count);
    }

    public void RemoveWeapon(int id)
    {
        var weapon = _weaponGroup.GetWeaponById(id);

        if (weapon == null)
        {
            Debug.LogError($"Not found weapon by id - {id}");
            return;
        }

        weapon.Data.RemoveItem(1);

        if(weapon.Data.Count < 0)
        {
            weapon.Data.Count = 0;
        }

        OnChangeCountWeapon?.Invoke(weapon, weapon.Data.Count);
    }
}

[Serializable]
public class ItemWeaponDatas
{
    public ItemWeaponData[] Datas;

    public ItemWeaponDatas(ItemWeaponData[] datas)
    {
        Datas = datas;
    }
}

[Serializable]
public class ItemWeaponData
{
    public int Count;

    public ItemWeaponData(int count)
    {
        Count = count;
    }

    public void AddItem(int count)
    {
        Count += count;
    }

    public void RemoveItem(int count)
    {
        Count -= count;
    }
}
