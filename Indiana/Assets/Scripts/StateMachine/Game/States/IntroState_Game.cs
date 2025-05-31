using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroState_Game : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly IGameEventsProvider _gameEventsProvider;
    private readonly IPlayerColliderProvider _playerColliderProvider;

    public IntroState_Game(IGlobalStateMachineProvider machineProvider, IGameEventsProvider gameEventsProvider, IPlayerColliderProvider playerColliderProvider)
    {
        _machineProvider = machineProvider;
        _gameEventsProvider = gameEventsProvider;
        _playerColliderProvider = playerColliderProvider;
    }

    public void EnterState()
    {
        Debug.Log("<color=red>ACTIVATE STATE - INTRO STATE / GAME</color>");

        _gameEventsProvider.OnStart += ChangeStateToMain;

        _playerColliderProvider.ActivateNormal();
    }

    public void ExitState()
    {
        _gameEventsProvider.OnStart += ChangeStateToMain;
    }

    private void ChangeStateToMain()
    {
        _machineProvider.SetState(_machineProvider.GetState<MainState_Game>());
    }
}
