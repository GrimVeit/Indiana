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

    private Sequence seq;
    private IEnumerator timer;
    private bool isPaused = false;

    private void Awake()
    {
        trigger.OnTriggerEnter += Enter;
        trigger.OnZoneAction += ZoneAction;
    }

    private void OnDestroy()
    {
        trigger.OnTriggerEnter -= Enter;
        trigger.OnZoneAction -= ZoneAction;

        seq?.Kill();

        Coroutines.Stop(timer);
    }

    override public void Activate()
    {
        seq = DOTween.Sequence();

        seq.AppendInterval(pauseDuration);
        seq.AppendCallback(() => spriteRenderer.flipX = true);
        seq.AppendCallback(() => Coroutines.Start(timer = Timer()));
        seq.Append(kangarooTransform.DOLocalJump(secondJumpPoint.localPosition, jumpPower, 1, durationJump).SetEase(Ease.Linear));
        seq.AppendInterval(pauseDuration);
        seq.AppendCallback(() => spriteRenderer.flipX = false);
        seq.AppendCallback(() => Coroutines.Start(timer = Timer()));
        seq.Append(kangarooTransform.DOLocalJump(firstJumpPoint.localPosition, jumpPower, 1, durationJump).SetEase(Ease.Linear));
        seq.SetLoops(-1);
    }

    public override void Deactivate()
    {
        seq?.Kill();

        Coroutines.Stop(timer);

        seq = DOTween.Sequence();

        seq.Append(kangarooTransform.DORotate(new Vector3(0, 0, 720), 2, RotateMode.FastBeyond360))
            .Join(kangarooTransform.DOScale(Vector3.zero, 2))
            .OnComplete(() => Destroy(gameObject));
    }

    private IEnumerator Timer()
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            yield return new WaitUntil(() => !isPaused);

            spriteRenderer.sprite = sprites[i];
            yield return new WaitForSeconds(frameDuration);
        }
    }

    public override void Pause()
    {
        isPaused = true;

        seq?.Pause();
    }

    public override void Resume()
    {
        isPaused = false;

        seq?.Play();
    }

    private void Enter()
    {
        OnSendObstacle?.Invoke(damage);
    }

    private void ZoneAction()
    {
        OnSendZoneAction?.Invoke(this);
    }
}
