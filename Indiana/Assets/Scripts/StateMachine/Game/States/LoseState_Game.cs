using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState_Game : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameSceneRoot_Game _sceneRoot;
    private readonly ICameraProvider _cameraProvider;

    public LoseState_Game(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Game sceneRoot, ICameraProvider cameraProvider)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
        _cameraProvider = cameraProvider;

    }

    public void EnterState()
    {
        Debug.Log("<color=red>ACTIVATE STATE - LOSE STATE / GAME</color>");

        _sceneRoot.OpenLosePanel();
        _cameraProvider.DeactivateLookAt();
    }

    public void ExitState()
    {

    }
}
