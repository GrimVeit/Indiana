using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPunchState_Game : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly IPlayerMoveProvider _playerMoveProvider;
    private readonly IPlayerAnimationProvider _playerAnimationProvider;

    private readonly ILoseEventProvider _loseEventProvider;
    private readonly IGameEventsProvider _gameEventsProvider;

    private IEnumerator timer;

    public AttackPunchState_Game(IGlobalStateMachineProvider machineProvider, IPlayerMoveProvider playerMoveProvider, IPlayerAnimationProvider playerAnimationProvider, ILoseEventProvider loseEventProvider, IGameEventsProvider gameEventsProvider)
    {
        _machineProvider = machineProvider;
        _playerMoveProvider = playerMoveProvider;
        _playerAnimationProvider = playerAnimationProvider;
        _loseEventProvider = loseEventProvider;
        _gameEventsProvider = gameEventsProvider;
    }
    
    public void EnterState()
    {
        Debug.Log("<color=red>ACTIVATE STATE - ATTACK PUNCH STATE / GAME</color>");

        _loseEventProvider.OnLose += ChangeStateToLose;
        _gameEventsProvider.OnStop += ChangeStateToWin;

        _playerAnimationProvider.AttackPunch();
        _playerMoveProvider.StopRun();

        if(timer != null) Coroutines.Stop(timer);

        timer = Timer(1);
        Coroutines.Start(timer);
    }

    public void ExitState()
    {
        _loseEventProvider.OnLose -= ChangeStateToLose;
        _gameEventsProvider.OnStop -= ChangeStateToWin;

        if (timer != null) Coroutines.Stop(timer);
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);

        ChangeStateToRun();
    }

    private void ChangeStateToRun()
    {
        _machineProvider.SetState(_machineProvider.GetState<RunState_Game>());
    }

    private void ChangeStateToWin()
    {
        _machineProvider.SetState(_machineProvider.GetState<WinState_Game>());
    }

    private void ChangeStateToLose()
    {
        _machineProvider.SetState(_machineProvider.GetState<LoseState_Game>());
    }
}
