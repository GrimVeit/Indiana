using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WinBirdAnimation : AnimationElement
{
    [SerializeField] private Transform transformEnd;
    [SerializeField] private Vector3 rotateEnd;
    [SerializeField] private float durationMove;

    [SerializeField] private Image imageBird;
    [SerializeField] private List<Sprite> spritesFly = new List<Sprite>();
    [SerializeField] private Sprite spriteStop;
    [SerializeField] private float durationFrame;

    private Tween tweenMove;

    private IEnumerator timer;

    public override void Animate()
    {
        if(timer != null) Coroutines.Stop(timer);

        timer = TimerFrame();
        Coroutines.Start(timer);

        tweenMove = element
            .DOLocalMove(transformEnd.localPosition, durationMove)
            .SetEase(Ease.InQuad)
            .OnComplete(() =>
            {
                RotateBird();
            });
    }

    private void RotateBird()
    {
        if (timer != null) Coroutines.Stop(timer);

        imageBird.sprite = spriteStop;
    }

    public override void Dispose()
    {
        tweenMove?.Kill();
    }

    private IEnumerator TimerFrame()
    {
        int index = 0;

        while (true)
        {
            imageBird.sprite = spritesFly[index];
            index = (index + 1) % spritesFly.Count;
            yield return new WaitForSeconds(durationFrame);
        }
    }
}
