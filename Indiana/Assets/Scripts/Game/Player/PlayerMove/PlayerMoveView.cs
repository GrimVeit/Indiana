using System;
using UnityEngine;

public class PlayerMoveView : View
{
    [SerializeField] private Player player;

    [SerializeField] private float speedRun;

    public void Initialize()
    {
        player.OnChangeJumpState += SetState;

        player.ChangeSpeed(speedRun);
    }

    public void Dispose()
    {
        player.OnChangeJumpState -= SetState;
    }

    public void StartRun()
    {
        player.StartRun();
    }

    public void StopRun()
    {
        player.StopRun();
    }

    public void Jump()
    {
        player.Jump();
    }

    #region Output

    public event Action<JumpState> OnChangeState;

    private void SetState(JumpState jumpState)
    {
        OnChangeState?.Invoke(jumpState);
    }

    #endregion
}
