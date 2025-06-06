using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishWinState_Game : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameSceneRoot_Game _sceneRoot;

    public FinishWinState_Game(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Game sceneRoot)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        Debug.Log("<color=red>ACTIVATE STATE - LOSE STATE / GAME</color>");

        _sceneRoot.OpenFinishWinPanel();
    }

    public void ExitState()
    {

    }
}
