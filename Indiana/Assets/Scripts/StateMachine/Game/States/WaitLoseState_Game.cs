using System.Collections;
using UnityEngine;

public class WaitLoseState_Game : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameSceneRoot_Game _sceneRoot;
    private readonly ICameraProvider _cameraProvider;
    private readonly IPlayerMoveProvider _playerMoveProvider;
    private readonly IPlayerAnimationProvider _playerAnimationProvider;
    private readonly IPlayerColliderProvider _playerColliderProvider;

    private IEnumerator timer;

    public WaitLoseState_Game(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Game sceneRoot, ICameraProvider cameraProvider, IPlayerMoveProvider playerMoveProvider, IPlayerAnimationProvider playerAnimationProvider, IPlayerColliderProvider playerColliderProvider)
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
        _playerColliderProvider.ActivateDie();
        _cameraProvider.DeactivateLookAt();
        _playerMoveProvider.StopRun();
        _playerAnimationProvider.Die();

        if(timer != null) Coroutines.Stop(timer);

        timer = Timer(1);
        Coroutines.Start(timer);
    }

    public void ExitState()
    {
        if (timer != null) Coroutines.Stop(timer);
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);

        ChangeStateToLose();
    }

    private void ChangeStateToLose()
    {
        _machineProvider.SetState(_machineProvider.GetState<StartLoseState_Game>());
    }
}
