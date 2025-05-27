using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Kangaroo : Obstacle
{
    [SerializeField] private int damage;
    [SerializeField] private ObstacleTrigger trigger;
    [SerializeField] private Transform firstJumpPoint;
    [SerializeField] private Transform secondJumpPoint;
    [SerializeField] private Transform kangarooTransform;
    [SerializeField] private float durationJump;
    [SerializeField] private float jumpPower;
    [SerializeField] private float pauseDuration;

    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float frameDuration;

    private IEnumerator timer;

    private void Awake()
    {
        trigger.OnTriggerEnter += Enter;
    }

    private void OnDestroy()
    {
        trigger.OnTriggerEnter -= Enter;
    }

    override public void Activate()
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendInterval(pauseDuration);
        seq.AppendCallback(() => spriteRenderer.flipX = true);
        seq.AppendCallback(() => Coroutines.Start(Timer()));
        seq.Append(kangarooTransform.DOLocalJump(secondJumpPoint.localPosition, jumpPower, 1, durationJump).SetEase(Ease.Linear));
        seq.AppendInterval(pauseDuration);
        seq.AppendCallback(() => spriteRenderer.flipX = false);
        seq.AppendCallback(() => Coroutines.Start(Timer()));
        seq.Append(kangarooTransform.DOLocalJump(firstJumpPoint.localPosition, jumpPower, 1, durationJump).SetEase(Ease.Linear));
        seq.SetLoops(-1);
    }

    private IEnumerator Timer()
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            spriteRenderer.sprite = sprites[i];
            yield return new WaitForSeconds(frameDuration);
        }
    }

    private void Enter()
    {
        OnSendObstacle?.Invoke(damage);
    }
}
