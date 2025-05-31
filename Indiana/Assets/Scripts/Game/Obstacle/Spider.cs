using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Spider : Obstacle
{
    [SerializeField] private int damage;
    [SerializeField] private ObstacleTrigger trigger;
    [SerializeField] private Transform topLeft;
    [SerializeField] private Transform topRight;
    [SerializeField] private Transform bottomLeft;
    [SerializeField] private Transform bottomRight;
    [SerializeField] private Transform spider;
    [SerializeField] private float moveDuration;

    [SerializeField] private float waitTime;

    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float frameDuration;

    private Vector2 minBounds;
    private Vector2 maxBounds;

    private Sequence seq;

    private IEnumerator timer;
    private IEnumerator timerFrame;

    private void Awake()
    {
        trigger.OnTriggerEnter += Enter;
        trigger.OnZoneAction += ZoneAction;
    }

    private void OnDestroy()
    {
        trigger.OnTriggerEnter -= Enter;
        trigger.OnZoneAction -= ZoneAction;
    }

    public override void Activate()
    {
        minBounds = new Vector2
            (Mathf.Min(topLeft.localPosition.x, bottomLeft.localPosition.x),
            Mathf.Min(bottomLeft.localPosition.y, bottomRight.localPosition.y));

        maxBounds = new Vector2
            (Mathf.Max(topRight.localPosition.x, bottomRight.localPosition.x),
            Mathf.Max(topLeft.localPosition.y, topRight.localPosition.y));

        if(timer != null) Coroutines.Stop(timer);
        if(timerFrame != null) Coroutines.Stop(timerFrame);

        timer = Timer();
        timerFrame = TimerFrame();

        Coroutines.Start(timer);
        Coroutines.Start(timerFrame);
    }

    public override void Deactivate()
    {
        seq?.Kill();

        Coroutines.Stop(timer);
        Coroutines.Stop(timerFrame);

        seq = DOTween.Sequence();

        seq.Append(spider.DORotate(new Vector3(0, 0, 720), 2, RotateMode.FastBeyond360))
            .Join(spider.DOScale(Vector3.zero, 2))
            .OnComplete(() => Destroy(gameObject));
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            Vector3 targetPos = GetRandomPoint();
            Vector3 direction = (targetPos - spider.localPosition).normalized;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            seq?.Kill();

            seq = DOTween.Sequence();

            seq.Append(spider.DORotate(new Vector3(0, 0, angle + 90), 0.3f))
                .Join(spider.DOLocalMove(targetPos, moveDuration));

            yield return new WaitForSeconds(moveDuration + waitTime);
        }
    }

    private Vector3 GetRandomPoint()
    {
        float x = Random.Range(minBounds.x, maxBounds.x);
        float y = Random.Range(minBounds.y, maxBounds.y);

        return new Vector3(x, y, 0);
    }

    private IEnumerator TimerFrame()
    {
        int index = 0;

        while (true)
        {
            spriteRenderer.sprite = sprites[index];
            index = (index + 1) % sprites.Count;
            yield return new WaitForSeconds(frameDuration);
        }
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
