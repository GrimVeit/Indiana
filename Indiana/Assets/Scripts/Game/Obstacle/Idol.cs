using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idol : Obstacle
{
    [SerializeField] private int damage;
    [SerializeField] private ObstacleTrigger trigger;
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

    }

    private void Enter()
    {
        OnSendObstacle?.Invoke(damage);
    }
}
