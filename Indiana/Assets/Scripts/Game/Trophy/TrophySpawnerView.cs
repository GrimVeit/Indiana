using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrophySpawnerView : View
{
    [SerializeField] private TrophyIndexes trophyIndexes;

    private readonly List<Trophy> _spawnedTrophies = new();

    public void SpawnTrophy(int index, System.Numerics.Vector3 position)
    {
        var prefab = trophyIndexes.GetTrophyByIndex(index);

        var trophy = Instantiate(prefab, new Vector3(position.X, position.Y, position.Z), prefab.transform.rotation);
        trophy.OnSendTrophy += SendTrophy;
        trophy.Activate();

        _spawnedTrophies.Add(trophy);
    }

    public void DestroyTrophy(Trophy trophy)
    {
        trophy.OnSendTrophy -= SendTrophy;

        _spawnedTrophies.Remove(trophy);

        trophy.Deactivate();
    }

    #region Output

    public event Action<int> OnSendTrophy;

    private void SendTrophy(Trophy trophy)
    {
        int id = trophy.Id;

        OnSendTrophy?.Invoke(id);

        DestroyTrophy(trophy);
    }

    #endregion
}

[Serializable]
public class TrophyIndexes
{
    [SerializeField] private List<TrophyIndex> trophyIndexes = new();

    public Trophy GetTrophyByIndex(int index)
    {
        return trophyIndexes.FirstOrDefault(data => data.Index == index).Trophy;
    }
}

[Serializable]
public class TrophyIndex
{
    public Trophy Trophy => trophy;
    public int Index => index;

    [SerializeField] private Trophy trophy;
    [SerializeField] private int index;
}
