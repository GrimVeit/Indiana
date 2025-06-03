using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWhipState_Game : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly IPlayerMoveProvider _playerMoveProvider;
    private readonly IPlayerAnimationProvider _playerAnimationProvider;

    private readonly ILoseEventProvider _loseEventProvider;
    private readonly IGameEventsProvider _gameEventsProvider;
    private readonly IPlayerZoneActionProvider _playerZoneActionProvider;
    private readonly IStoreWeaponProvider _weaponProvider;
    private readonly IGameButtonsHiderProvider _gameButtonsHiderProvider;

    private IEnumerator timer;

    public AttackWhipState_Game(IGlobalStateMachineProvider machineProvider, IPlayerMoveProvider playerMoveProvider, IPlayerAnimationProvider playerAnimationProvider, ILoseEventProvider loseEventProvider, IGameEventsProvider gameEventsProvider, IPlayerZoneActionProvider playerZoneActionProvider, IStoreWeaponProvider weaponProvider, IGameButtonsHiderProvider gameButtonsHiderProvider)
    {
        _machineProvider = machineProvider;
        _playerMoveProvider = playerMoveProvider;
        _playerAnimationProvider = playerAnimationProvider;
        _loseEventProvider = loseEventProvider;
        _gameEventsProvider = gameEventsProvider;
        _playerZoneActionProvider = playerZoneActionProvider;
        _weaponProvider = weaponProvider;
        _gameButtonsHiderProvider = gameButtonsHiderProvider;
    }

    public void EnterState()
    {
        Debug.Log("<color=red>ACTIVATE STATE - ATTACK WHIP STATE / GAME</color>");

        _loseEventProvider.OnLose += ChangeStateToLose;
        _gameEventsProvider.OnStop += ChangeStateToWin;

        _weaponProvider.RemoveWeapon(1);
        _playerAnimationProvider.AttackWhip();
        _playerMoveProvider.StopRun();
        _gameButtonsHiderProvider.Hide(0);
        _gameButtonsHiderProvider.Hide();

        if (timer != null) Coroutines.Stop(timer);

        timer = Timer(1.2f);
        Coroutines.Start(timer);
    }

    public void ExitState()
    {
        _loseEventProvider.OnLose -= ChangeStateToLose;
        _gameEventsProvider.OnStop -= ChangeStateToWin;

        if (timer != null) Coroutines.Stop(timer);
    }

    private IEnumerator Timer(float time)
    {
        float timeAttack = 0.9f;

        yield return new WaitForSeconds(timeAttack);

        _playerZoneActionProvider.ActivateSmallZone();

        yield return new WaitForSeconds(time - timeAttack);

        ChangeStateToRun();
    }

    private void ChangeStateToRun()
    {
        _machineProvider.SetState(_machineProvider.GetState<RunState_Game>());
    }

    private void ChangeStateToWin()
    {
        _machineProvider.SetState(_machineProvider.GetState<WinState_Game>());
    }

    private void ChangeStateToLose()
    {
        _machineProvider.SetState(_machineProvider.GetState<LoseState_Game>());
    }
}
