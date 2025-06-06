using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WinStars : AnimationElement
{
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;

    [SerializeField] private Vector3 minScale;
    [SerializeField] private Vector3 maxScale;
    [SerializeField] private float durationScale;

    [SerializeField] private Image image;

    private Sequence sequence;

    public override void Animate()
    {
        sequence = DOTween.Sequence();

        sequence.AppendCallback(() =>
        {
            element.localScale = minScale;
            image.color = new Color(1, 1, 1, 1);
            image.sprite = sprite1;
        });

        sequence.Append(element.DOScale(maxScale, durationScale)).OnUpdate(() =>
        {
            if (element.localScale.x >= 1.0f && image.sprite != sprite2)
            {
                image.sprite = sprite2;
            }
        });

        sequence.Join(image.DOFade(0, durationScale));

        sequence.SetLoops(3, LoopType.Restart);
    }
}
