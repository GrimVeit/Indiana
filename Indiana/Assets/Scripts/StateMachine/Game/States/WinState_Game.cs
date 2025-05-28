using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState_Game : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameSceneRoot_Game _sceneRoot;
    private readonly ICameraProvider _cameraProvider;

    public WinState_Game(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Game sceneRoot, ICameraProvider cameraProvider)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
        _cameraProvider = cameraProvider;

    }

    public void EnterState()
    {
        Debug.Log("<color=red>ACTIVATE STATE - WIN STATE / GAME</color>");

        _sceneRoot.OpenWinPanel();
        _cameraProvider.DeactivateLookAt();
    }

    public void ExitState()
    {

    }
}
