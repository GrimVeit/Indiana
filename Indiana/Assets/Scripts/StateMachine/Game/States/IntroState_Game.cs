using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroState_Game : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameSceneRoot_Game _sceneRoot;

    public IntroState_Game(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Game sceneRoot)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {

    }

    public void ExitState()
    {

    }

    private void ChangeStateToCameraFollow()
    {
        _machineProvider.SetState(_machineProvider.GetState<MainState_Menu>());
    }
}
