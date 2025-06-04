using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WeaponItem : MonoBehaviour
{
    public int Id => id;

    [SerializeField] private int id;
    [SerializeField] private Transform transformUp;
    [SerializeField] private Transform transformDown;
    [SerializeField] private Transform transformWeapon;
    [SerializeField] private float duration;
    [SerializeField] private TrophyTrigger trigger;

    private Sequence sequence;

    private bool isActive;

    private void Awake()
    {
        trigger.OnTriggerEnter += Enter;
    }

    private void OnDestroy()
    {
        trigger.OnTriggerEnter -= Enter;
    }

    public void Activate()
    {
        isActive = true;

        sequence = DOTween.Sequence();

        sequence
            .Append(transformWeapon.DOLocalMove(transformUp.localPosition, duration))
            .Append(transformWeapon.DOLocalMove(transformDown.localPosition, duration))
            .SetLoops(-1);
    }

    public void Deactivate()
    {
        isActive = false;

        if (sequence != null) sequence?.Kill();

        transformWeapon.DOScale(0, 0.1f).OnComplete(() => Destroy(gameObject));
    }

    private void Enter()
    {
        if (!isActive) return;

        OnSendWeapon?.Invoke(this);
    }

    #region Output

    public event Action<WeaponItem> OnSendWeapon;

    #endregion
}
