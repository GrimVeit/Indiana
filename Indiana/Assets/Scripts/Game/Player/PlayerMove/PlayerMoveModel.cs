using System;
using UnityEngine;

public class PlayerMoveModel
{
    private JumpState currentJumpState = JumpState.Grounded;

    public void SetState(JumpState state)
    {
        if(currentJumpState == state || currentJumpState != JumpState.Grounded && state != JumpState.Grounded) return;

        if(currentJumpState == JumpState.Grounded)
        {
            Debug.Log("бнгдсу");
            OnPlayerInGround?.Invoke();
        }

        if(currentJumpState != JumpState.Grounded)
        {
            Debug.Log("гелкъ");
            OnPlayerOutGround?.Invoke();
        }

        currentJumpState = state;
    }

    public void StartRun()
    {
        OnStartRun?.Invoke();
    }

    public void StopRun()
    {
        OnStopRun?.Invoke();
    }

    public void Jump()
    {
        OnJump?.Invoke();
    }

    public void Freeze()
    {
        OnFreeze?.Invoke();
    }

    public void Unfreeze()
    {
        OnFreezeEnd?.Invoke();
    }

    #region Output

    public event Action OnPlayerInGround;
    public event Action OnPlayerOutGround;

    public event Action OnStartRun;
    public event Action OnStopRun;
    public event Action OnJump;

    public event Action OnFreeze;
    public event Action OnFreezeEnd;

    #endregion
}
