using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Idol : Obstacle
{
    [SerializeField] private int damage;
    [SerializeField] private ObstacleTrigger trigger;
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform idolTransform;
    [SerializeField] private float frameDuration;

    private IEnumerator timer;

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
        if(timer != null) Coroutines.Stop(timer);

        timer = Timer();
        Coroutines.Start(timer);
    }

    private IEnumerator Timer()
    {
        int index = 0;

        while (true)
        {
            spriteRenderer.sprite = sprites[index];
            index = (index + 1) % sprites.Count;
            yield return new WaitForSeconds(frameDuration);
        }
    }

    public override void Deactivate()
    {
        Coroutines.Stop(timer);

        Sequence seq = DOTween.Sequence();

        seq.Append(idolTransform.DORotate(new Vector3(0, 0, 720), 1, RotateMode.FastBeyond360))
            .Join(idolTransform.DOScale(Vector3.zero, 1))
            .OnComplete(() => Destroy(gameObject));
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
