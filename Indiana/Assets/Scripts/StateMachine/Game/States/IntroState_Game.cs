using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroState_Game : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly IGameEventsProvider _gameEventsProvider;

    public IntroState_Game(IGlobalStateMachineProvider machineProvider, IGameEventsProvider gameEventsProvider)
    {
        _machineProvider = machineProvider;
        _gameEventsProvider = gameEventsProvider;
    }

    public void EnterState()
    {
        Debug.Log("<color=red>ACTIVATE STATE - INTRO STATE / GAME</color>");

        _gameEventsProvider.OnStart += ChangeStateToMain;
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
