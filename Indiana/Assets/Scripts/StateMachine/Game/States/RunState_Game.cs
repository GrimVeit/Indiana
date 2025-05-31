using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState_Game : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly IPlayerMoveProvider _playerMoveProvider;
    private readonly IPlayerAnimationProvider _playerAnimationProvider;

    private readonly ILoseEventProvider _loseEventProvider;
    private readonly IGameEventsProvider _gameEventsProvider;

    public RunState_Game(IGlobalStateMachineProvider machineProvider, IPlayerMoveProvider playerMoveProvider, IPlayerAnimationProvider playerAnimationProvider, ILoseEventProvider loseEventProvider, IGameEventsProvider gameEventsProvider)
    {
        _machineProvider = machineProvider;
        _playerMoveProvider = playerMoveProvider;
        _playerAnimationProvider = playerAnimationProvider;
        _loseEventProvider = loseEventProvider;
        _gameEventsProvider = gameEventsProvider;
    }

    public void EnterState()
    {
        Debug.Log("<color=red>ACTIVATE STATE - RUN STATE / GAME</color>");

        _loseEventProvider.OnLose += ChangeStateToLose;
        _gameEventsProvider.OnStop += ChangeStateToWin;

        _playerAnimationProvider.Run();
        _playerMoveProvider.StartRun();

        ChangeStateToMain();
    }

    public void ExitState()
    {
        _loseEventProvider.OnLose -= ChangeStateToLose;
        _gameEventsProvider.OnStop -= ChangeStateToWin;
    }

    private void ChangeStateToMain()
    {
        _machineProvider.SetState(_machineProvider.GetState<MainState_Game>());
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
