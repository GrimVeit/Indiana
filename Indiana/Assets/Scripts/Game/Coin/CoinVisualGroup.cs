using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinVisualGroup : MonoBehaviour
{
    [SerializeField] private List<CoinVisual> coinVisuals = new();

    public void Initialize()
    {
        coinVisuals.ForEach(x =>
        {
            x.OnSendCoin += SendCoin;
            x.Initialize();
        });
    }

    public void Dispose()
    {
        coinVisuals.ForEach(x =>
        {
            x.OnSendCoin -= SendCoin;
            x.Dispose();
        });
    }

    public void DestroyCoinVisual(CoinVisual coinVisual)
    {
        coinVisual.OnSendCoin -= SendCoin;

        coinVisuals.Remove(coinVisual);

        coinVisual.Deactivate();
    }

    #region Output

    public event Action<int> OnSendCoins;

    private void SendCoin(CoinVisual coinVisual)
    {
        int coins = coinVisual.Coins;

        OnSendCoins?.Invoke(coins);

        DestroyCoinVisual(coinVisual);
    }

    #endregion
}
