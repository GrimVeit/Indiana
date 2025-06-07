using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinSpawnerView : View
{
    [SerializeField] private CoinIndexes coinIndexes;

    private readonly List<CoinVisualGroup> _spawnedCoinsGroups = new();

    public void SpawnCoinsGroup(int index, System.Numerics.Vector3 position)
    {
        var prefab = coinIndexes.GetCoinGroupByIndex(index);

        var coinVisual = Instantiate(prefab, new Vector3(position.X, position.Y, position.Z), prefab.transform.rotation);
        coinVisual.OnSendCoins += SendCoins;
        coinVisual.Initialize();

        _spawnedCoinsGroups.Add(coinVisual);
    }

    public void Dispose()
    {
        _spawnedCoinsGroups.ForEach(data => data.Dispose());
    }

    #region Output

    public event Action<int> OnSendCoins;

    private void SendCoins(int coins)
    {
        OnSendCoins?.Invoke(coins);
    }

    #endregion
}

[Serializable]
public class CoinIndexes
{
    [SerializeField] private List<CoinIndex> coinIndexes = new();

    public CoinVisualGroup GetCoinGroupByIndex(int index)
    {
        return coinIndexes.FirstOrDefault(data => data.Index == index).CoinVisualGroup;
    }
}

[Serializable]
public class CoinIndex
{
    public CoinVisualGroup CoinVisualGroup => coinVisualGroup;
    public int Index => index;

    [SerializeField] private CoinVisualGroup coinVisualGroup;
    [SerializeField] private int index;
}
