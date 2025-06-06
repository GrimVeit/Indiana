using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class IndicatorAnimation : AnimationElement
{
    [SerializeField] private float minAngle = 30f;
    [SerializeField] private float maxAngle = 70;

    [SerializeField] private float minDuration = 0.8f;
    [SerializeField] private float maxDuration = 1.2f;

    private Sequence sequence;

    public override void Initialize()
    {
        Animate();
    }

    public override void Animate()
    {
        sequence?.Kill();

        sequence = DOTween.Sequence().SetLoops(-1);

        sequence.AppendCallback(() =>
        {
            element.DORotate(new Vector3(0, 0, -GetRandomAngle()), GetRandomDuration())
            .SetEase(Ease.InOutSine);
        });

        sequence.AppendInterval(maxDuration);

        sequence.AppendCallback(() =>
        {
            element.DORotate(new Vector3(0, 0, GetRandomAngle()), GetRandomDuration())
            .SetEase(Ease.InOutSine);
        });

        sequence.AppendInterval(maxDuration);
    }

    public override void Dispose()
    {
        sequence?.Kill();
    }

    private float GetRandomAngle()
    {
        return Random.Range(minAngle, maxAngle);
    }

    private float GetRandomDuration()
    {
        return Random.Range(minDuration, maxDuration);
    }
}
