using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationModel
{
    private readonly IStorePlayerDesignEventsProvider _storePlayerDesignEventsProvider;
    private readonly IPlayerGroundEventsProvider _playerGroundEventsProvider;

    private PlayerDesign _currentPlayerDesign;

    private IEnumerator frameTimer;

    private bool isDie = false;

    private bool isResume = true;

    public PlayerAnimationModel(IStorePlayerDesignEventsProvider storePlayerDesignEventsProvider, IPlayerGroundEventsProvider playerGroundEventsProvider)
    {
        _storePlayerDesignEventsProvider = storePlayerDesignEventsProvider;
        _playerGroundEventsProvider = playerGroundEventsProvider;

        _storePlayerDesignEventsProvider.OnChooseDesign += SetDesign;
        _playerGroundEventsProvider.OnPlayerOutGround += EndJump;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _storePlayerDesignEventsProvider.OnChooseDesign -= SetDesign;
        _playerGroundEventsProvider.OnPlayerOutGround -= EndJump;
    }

    public void Pause()
    {
        isResume = false;
    }

    public void Resume()
    {
        isResume = true;
    }

    public void Run()
    {
        if (isDie) return;

        Change(_currentPlayerDesign.SpritesRun, 0.2f, true);
    }

    public void EndJump()
    {
        if(isDie) return;

        Change(_currentPlayerDesign.SpritesEndJump, 0.2f, false, Run);
    }

    public void Jump()
    {
        if (isDie) return;

        Change(_currentPlayerDesign.SpritesJump, 0.2f, false);
    }

    public void Die()
    {
        isDie = true;

        Change(_currentPlayerDesign.SpritesDie, 0.2f, false);
    }

    public void AttackPunch()
    {
        if (isDie) return;

        Change(_currentPlayerDesign.SpritesHitPunch, 0.2f, false);
    }

    public void AttackKnife()
    {
        if (isDie) return;

        Change(_currentPlayerDesign.SpritesHitKnife, 0.2f, false);
    }

    public void AttackWhip()
    {
        if (isDie) return;

        Change(_currentPlayerDesign.SpritesHitWhip, 0.1f, false);
    }

    private void Change(List<Sprite> sprites, float duration, bool isLoop, Action OnEnd = null)
    {
        if (frameTimer != null) Coroutines.Stop(frameTimer);

        if (isLoop)
        {
            frameTimer = TimerFrameLoop(sprites, duration);
        }
        else
        {
            frameTimer = TimerFrame(sprites, duration, OnEnd);
        }

        Coroutines.Start(frameTimer);
    }

    private IEnumerator TimerFrameLoop(List<Sprite> sprites, float duration)
    {
        int index = 0;

        while (true)
        {
            yield return new WaitUntil(() => isResume);

            OnChangeSprite?.Invoke(sprites[index]);
            index = (index + 1) % sprites.Count;
            yield return new WaitForSeconds(duration);
        }
    }

    private IEnumerator TimerFrame(List<Sprite> sprites, float duration, Action action)
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            yield return new WaitUntil(() => isResume);

            OnChangeSprite?.Invoke(sprites[i]);
            yield return new WaitForSeconds(duration);
        }

        action?.Invoke();
    }


    private void SetDesign(PlayerDesign playerDesign)
    {
        _currentPlayerDesign = playerDesign;
    }

    #region Output

    public event Action<Sprite> OnChangeSprite;

    #endregion
}
