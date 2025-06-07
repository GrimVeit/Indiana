using System;
using DG.Tweening;
using UnityEngine;

public class CoinVisual : MonoBehaviour
{
    public int Coins => coins;

    [SerializeField] private int coins;
    [SerializeField] private Transform coin;
    [SerializeField] private CoinTrigger coinTrigger;

    private bool isActive = true;

    public void Initialize()
    {
        coinTrigger.OnTriggerEnter += Enter;
    }

    public void Dispose()
    {
        coinTrigger.OnTriggerEnter -= Enter;
    }

    public void Activate()
    {
        isActive = true;
    }

    public void Deactivate()
    {
        isActive = false;

        coin.DOScale(0, 0.1f).OnComplete(() =>
        {
            Dispose();
            Destroy(gameObject);
        });
    }

    private void Enter()
    {
        if (!isActive) return;

        OnSendCoin?.Invoke(this);
    }

    #region Output

    public event Action<CoinVisual> OnSendCoin;

    #endregion
}
