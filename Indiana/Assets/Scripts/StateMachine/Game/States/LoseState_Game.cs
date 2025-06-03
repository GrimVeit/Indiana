using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState_Game : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameSceneRoot_Game _sceneRoot;
    private readonly ICameraProvider _cameraProvider;
    private readonly IPlayerMoveProvider _playerMoveProvider;
    private readonly IPlayerAnimationProvider _playerAnimationProvider;
    private readonly IPlayerColliderProvider _playerColliderProvider;

    public LoseState_Game(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Game sceneRoot, ICameraProvider cameraProvider, IPlayerMoveProvider playerMoveProvider, IPlayerAnimationProvider playerAnimationProvider, IPlayerColliderProvider playerColliderProvider)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
        _cameraProvider = cameraProvider;
        _playerMoveProvider = playerMoveProvider;
        _playerAnimationProvider = playerAnimationProvider;
        _playerColliderProvider = playerColliderProvider;

    }

    public void EnterState()
    {
        Debug.Log("<color=red>ACTIVATE STATE - LOSE STATE / GAME</color>");

        _sceneRoot.CloseFooterPanel();
        _sceneRoot.CloseHeaderPanel();
        _sceneRoot.OpenLosePanel();
        _playerColliderProvider.ActivateDie();
        _cameraProvider.DeactivateLookAt();
        _playerMoveProvider.StopRun();
        _playerAnimationProvider.Die();
    }

    public void ExitState()
    {

    }
}
