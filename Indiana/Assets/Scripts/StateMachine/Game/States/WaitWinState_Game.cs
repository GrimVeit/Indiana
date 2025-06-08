using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitWinState_Game : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameSceneRoot_Game _sceneRoot;
    private readonly ICameraProvider _cameraProvider;
    private readonly IPlayerMoveProvider _playerMoveProvider;
    private readonly IPlayerAnimationProvider _playerAnimationProvider;
    private readonly IStoreOpenLevelProvider _storeOpenLevelProvider;
    private readonly ISoundProvider _soundProvider;

    private readonly int _level;

    private IEnumerator timer;

    public WaitWinState_Game(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Game sceneRoot, ICameraProvider cameraProvider, IPlayerMoveProvider playerMoveProvider, IPlayerAnimationProvider playerAnimationProvider, IStoreOpenLevelProvider storeOpenLevelProvider, int level, ISoundProvider soundProvider)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
        _cameraProvider = cameraProvider;
        _playerMoveProvider = playerMoveProvider;
        _playerAnimationProvider = playerAnimationProvider;
        _storeOpenLevelProvider = storeOpenLevelProvider;
        _level = level;
        _soundProvider = soundProvider;

    }

    public void EnterState()
    {
        Debug.Log("<color=red>ACTIVATE STATE - WIN STATE / GAME</color>");

        _sceneRoot.CloseFooterPanel();
        _sceneRoot.CloseHeaderPanel();

        _soundProvider.PlayOneShot("Yes");

        _cameraProvider.DeactivateLookAt();
        _playerAnimationProvider.Jump();
        _playerMoveProvider.Jump();
        _storeOpenLevelProvider.OpenLevel(_level);

        if (timer != null) Coroutines.Stop(timer);

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
        _machineProvider.SetState(_machineProvider.GetState<StartWinState_Game>());
    }
}
