using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    public int Id => id;

    [SerializeField] private int id;
    [SerializeField] private Transform transformButton;
    [SerializeField] private float duration;

    [SerializeField] private Vector3 vectorShowRotate;
    [SerializeField] private Vector3 vectorHideRotate;

    [SerializeField] private Transform transformShow;
    [SerializeField] private Transform transformHide;

    private Sequence seq;

    public void Show()
    {
        seq?.Kill();

        seq = DOTween.Sequence();

        seq.Append(transformButton.DOLocalMove(transformShow.localPosition, duration))
            .Join(transformButton.DORotate(vectorShowRotate, duration));
    }

    public void Hide()
    {
        seq?.Kill();

        seq = DOTween.Sequence();

        seq.Append(transformButton.DOLocalMove(transformHide.localPosition, duration))
            .Join(transformButton.DORotate(vectorHideRotate, duration));
    }
}
