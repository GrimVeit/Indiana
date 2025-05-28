using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainState_Game : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameSceneRoot_Game _sceneRoot;

    private ILoseEventProvider _loseEventProvider;
    private IZoneSpawnerProvider

    public MainState_Game(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Game sceneRoot)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _loseEventProvider.OnLose += ChangeStateToLose;
    }

    public void ExitState()
    {
        _loseEventProvider.OnLose -= ChangeStateToLose;
    }

    private void ChangeStateToWin()
    {
        _machineProvider.SetState(_machineProvider.GetState<MainState_Menu>());
    }

    private void ChangeStateToLose()
    {
        _machineProvider.SetState(_machineProvider.GetState<MainState_Menu>());
    }
}
