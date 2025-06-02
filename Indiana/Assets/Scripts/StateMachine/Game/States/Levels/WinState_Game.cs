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
    private readonly IStoreOpenLevelProvider _storeOpenLevelProvider;

    private readonly int _level;

    public WinState_Game(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Game sceneRoot, ICameraProvider cameraProvider, IPlayerMoveProvider playerMoveProvider, IPlayerAnimationProvider playerAnimationProvider, IStoreOpenLevelProvider storeOpenLevelProvider, int level)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
        _cameraProvider = cameraProvider;
        _playerMoveProvider = playerMoveProvider;
        _playerAnimationProvider = playerAnimationProvider;
        _storeOpenLevelProvider = storeOpenLevelProvider;
        _level = level;
    }

    public void EnterState()
    {
        Debug.Log("<color=red>ACTIVATE STATE - WIN STATE / GAME</color>");

        _sceneRoot.OpenWinPanel();
        _cameraProvider.DeactivateLookAt();
        _playerAnimationProvider.Jump();
        _playerMoveProvider.Jump();
        _storeOpenLevelProvider.OpenLevel(_level);
    }

    public void ExitState()
    {

    }
}
