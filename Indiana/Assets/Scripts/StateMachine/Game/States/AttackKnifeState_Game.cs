using System.Collections;
using UnityEngine;

public class AttackKnifeState_Game : IState
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

    public AttackKnifeState_Game(IGlobalStateMachineProvider machineProvider, IPlayerMoveProvider playerMoveProvider, IPlayerAnimationProvider playerAnimationProvider, ILoseEventProvider loseEventProvider, IGameEventsProvider gameEventsProvider, IPlayerZoneActionProvider playerZoneActionProvider, IStoreWeaponProvider weaponProvider, IGameButtonsHiderProvider gameButtonsHiderProvider)
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
        Debug.Log("<color=red>ACTIVATE STATE - ATTACK KNIFE STATE / GAME</color>");

        _loseEventProvider.OnLose += ChangeStateToLose;
        _gameEventsProvider.OnStop += ChangeStateToWin;

        _weaponProvider.RemoveWeapon(0);
        _playerAnimationProvider.AttackKnife();
        _playerMoveProvider.StopRun();
        _gameButtonsHiderProvider.Hide(0);
        _gameButtonsHiderProvider.Hide();

        if (timer != null) Coroutines.Stop(timer);

        timer = Timer(1);
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
        float timeAttack = 0.6f;

        yield return new WaitForSeconds(timeAttack);

        _playerZoneActionProvider.ActivateMiddleZone();

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
