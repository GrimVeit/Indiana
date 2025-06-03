using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainState_Game : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameSceneRoot_Game _sceneRoot;

    private readonly ILoseEventProvider _loseEventProvider;
    private readonly IGameEventsProvider _gameEventsProvider;
    private readonly IPlayerInputEventsProvider _playerInputEventsProvider;

    public MainState_Game(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Game sceneRoot, ILoseEventProvider loseEventProvider, IGameEventsProvider gameEventsProvider, IPlayerInputEventsProvider playerInputEventsProvider)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
        _loseEventProvider = loseEventProvider;
        _gameEventsProvider = gameEventsProvider;
        _playerInputEventsProvider = playerInputEventsProvider;
    }

    public void EnterState()
    {
        Debug.Log("<color=red>ACTIVATE STATE - MAIN STATE / GAME</color>");

        _loseEventProvider.OnLose += ChangeStateToLose;
        _gameEventsProvider.OnStop += ChangeStateToWin;
        _sceneRoot.OnClickToPause_Header += ChangeStateToPause;

        _playerInputEventsProvider.OnClickToHitPunch += ChangeStateToAttackPunch;
        _playerInputEventsProvider.OnClickToHitKnife += ChangeStateToAttackKnife;
        _playerInputEventsProvider.OnClickToHitWhip += ChangeStateToAttackWhip;

        _sceneRoot.OpenFooterPanel();
        _sceneRoot.OpenHeaderPanel();
        
    }

    public void ExitState()
    {
        _loseEventProvider.OnLose -= ChangeStateToLose;
        _gameEventsProvider.OnStop -= ChangeStateToWin;
        _sceneRoot.OnClickToPause_Header -= ChangeStateToPause;

        _playerInputEventsProvider.OnClickToHitPunch -= ChangeStateToAttackPunch;
        _playerInputEventsProvider.OnClickToHitKnife -= ChangeStateToAttackKnife;
        _playerInputEventsProvider.OnClickToHitWhip -= ChangeStateToAttackWhip;
    }

    private void ChangeStateToPause()
    {
        _machineProvider.SetState(_machineProvider.GetState<PauseState_Game>());
    }

    private void ChangeStateToWin()
    {
        _machineProvider.SetState(_machineProvider.GetState<WinState_Game>());
    }

    private void ChangeStateToLose()
    {
        _machineProvider.SetState(_machineProvider.GetState<LoseState_Game>());
    }


    private void ChangeStateToAttackPunch()
    {
        _machineProvider.SetState(_machineProvider.GetState<AttackPunchState_Game>());
    }

    private void ChangeStateToAttackKnife()
    {
        _machineProvider.SetState(_machineProvider.GetState<AttackKnifeState_Game>());
    }

    private void ChangeStateToAttackWhip()
    {
        _machineProvider.SetState(_machineProvider.GetState<AttackWhipState_Game>());
    }
}
