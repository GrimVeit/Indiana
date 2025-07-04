using System;
using System.Numerics;

public class CoinSpawnerModel
{
    public event Action<int, Vector3> OnSpawnCoins;

    private readonly IMoneyProvider _moneyProvider;
    private readonly ISoundProvider _soundProvider;

    public CoinSpawnerModel(IMoneyProvider moneyProvider, ISoundProvider soundProvider)
    {
        _moneyProvider = moneyProvider;
        _soundProvider = soundProvider;

    }

    public void SpawnCoins(CoinsChances coinsChances, Vector3 position)
    {
        if (!coinsChances.IsSpawnedCoins) return;

        var index = coinsChances.GetRandomIndexCoinsGroup();

        if (index < 0)
        {
            UnityEngine.Debug.Log("Not found trophy with index - " + index);
            return;
        }

        OnSpawnCoins?.Invoke(index, position);
    }

    public void SendCoins(int money)
    {
        _moneyProvider.SendMoney(money);

        _soundProvider.PlayOneShot("Item");
    }
}
