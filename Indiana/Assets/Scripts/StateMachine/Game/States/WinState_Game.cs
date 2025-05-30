using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState_Game : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameSceneRoot_Game _sceneRoot;
    private readonly ICameraProvider _cameraProvider;
    private readonly IPlayerMoveProvider _playerMoveProvider;
    private readonly IPlayerAnimationProvider _playerAnimationProvider;

    public WinState_Game(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Game sceneRoot, ICameraProvider cameraProvider, IPlayerMoveProvider playerMoveProvider, IPlayerAnimationProvider playerAnimationProvider)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
        _cameraProvider = cameraProvider;
        _playerMoveProvider = playerMoveProvider;
        _playerAnimationProvider = playerAnimationProvider;
    }

    public void EnterState()
    {
        Debug.Log("<color=red>ACTIVATE STATE - WIN STATE / GAME</color>");

        _sceneRoot.OpenWinPanel();
        _cameraProvider.DeactivateLookAt();
        _playerMoveProvider.StopRun();
        _playerAnimationProvider.Die();
    }

    public void ExitState()
    {

    }
}
