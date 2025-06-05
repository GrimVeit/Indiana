using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoseBirdAnimation : AnimationElement
{
    [SerializeField] private Transform transformEnd;
    [SerializeField] private Vector3 rotateEnd;
    [SerializeField] private float durationMove;

    [SerializeField] private Transform dust;
    [SerializeField] private Image imageDust;
    [SerializeField] private float durationDust;

    private Tween tweenMove;

    private Sequence seqDust;

    public override void Animate()
    {
        tweenMove = element
            .DOLocalMove(transformEnd.localPosition, durationMove)
            .SetEase(Ease.InQuad)
            .OnComplete(() =>
            {
                RotateBird();
                ActivateDust();
            });
    }

    private void RotateBird()
    {
        element.transform.eulerAngles = rotateEnd;
    }

    private void ActivateDust()
    {
        dust.gameObject.SetActive(true);

        seqDust = DOTween.Sequence();

        seqDust
            .Append(dust.DOScale(2, durationDust))
            .Join(imageDust.DOFade(0, durationDust));
    }

    public override void Dispose()
    {
        tweenMove?.Kill();
    }
}
