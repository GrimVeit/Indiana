using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState_Game : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameSceneRoot_Game _sceneRoot;

    private readonly IPlayerMoveProvider _playerMoveProvider;
    private readonly IPlayerAnimationProvider _playerAnimationProvider;
    private readonly IObstacleStateProvider _obstacleStateProvider;

    public PauseState_Game(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Game sceneRoot, IPlayerMoveProvider playerMoveProvider, IPlayerAnimationProvider playerAnimationProvider, IObstacleStateProvider obstacleStateProvider)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
        _playerMoveProvider = playerMoveProvider;
        _playerAnimationProvider = playerAnimationProvider;
        _obstacleStateProvider = obstacleStateProvider;
    }
    
    public void EnterState()
    {
        Debug.Log("<color=red>ACTIVATE STATE - PAUSE STATE / GAME</color>");

        _sceneRoot.OnClickToResume_Pause += ChangeStateToMain;

        _sceneRoot.OpenPausePanel();

        _playerMoveProvider.Freeze();
        _playerAnimationProvider.Pause();
        _obstacleStateProvider.Pause();
    }

    public void ExitState()
    {
        _sceneRoot.OnClickToResume_Pause -= ChangeStateToMain;

        _sceneRoot.ClosePausePanel();

        _playerMoveProvider.Unfreeze();
        _playerAnimationProvider.Resume();
        _obstacleStateProvider.Resume();
    }

    private void ChangeStateToMain()
    {
        _machineProvider.SetState(_machineProvider.GetState<MainState_Game>());
    }
}
