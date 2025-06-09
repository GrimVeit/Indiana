using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

public class TrophySpawnerModel
{
    public event Action<int, Vector3> OnSpawnTrophy;

    private readonly IItemCollectionProvider _itemCollectionProvider;
    private readonly ISoundProvider _soundProvider;

    public TrophySpawnerModel(IItemCollectionProvider itemCollectionProvider, ISoundProvider soundProvider)
    {
        _itemCollectionProvider = itemCollectionProvider;
        _soundProvider = soundProvider;
    }

    public void SpawnTrophy(TrophyChances trophyChances, Vector3 position)
    {
        var index = trophyChances.GetRandomIndexTrophy();

        if (index < 0)
        {
            UnityEngine.Debug.Log("Not found trophy with index - " + index);
            return;
        }

        OnSpawnTrophy?.Invoke(index, position);
    }

    public void SendTrophy(int id)
    {
        _itemCollectionProvider.AddItemCollection(id);

        _soundProvider.PlayOneShot("ManCollect");
    }
}
