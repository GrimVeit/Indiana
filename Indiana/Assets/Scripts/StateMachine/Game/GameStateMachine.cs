using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : IGlobalStateMachineProvider
{
    private readonly Dictionary<Type, IState> states = new();

    private IState _currentState;

    public GameStateMachine(
        UIGameSceneRoot_Game sceneRoot,
        IGameEventsProvider gameEventsProvider,
        ILoseEventProvider loseEventProvider,
        ICameraProvider cameraProvider,
        IPlayerMoveProvider playerMoveProvider,
        IPlayerAnimationProvider playerAnimationProvider, 
        IPlayerInputEventsProvider playerInputEventsProvider, 
        IPlayerZoneActionProvider playerZoneActionProvider,
        IPlayerColliderProvider playerColliderProvider,
        IObstacleStateProvider obstacleStateProvider,
        IStoreWeaponProvider storeWeaponProvider, 
        IStoreOpenLevelProvider storeOpenLevelProvider,
        int level,
        IGameButtonsHiderProvider gameButtonsHiderProvider,
        IAnimationElementProvider animationElementProvider)
    {
        states[typeof(IntroState_Game)] = new IntroState_Game(this, gameEventsProvider, playerColliderProvider);
        states[typeof(MainState_Game)] = new MainState_Game(this, sceneRoot, loseEventProvider, gameEventsProvider, playerInputEventsProvider);
        states[typeof(RunState_Game)] = new RunState_Game(this, playerMoveProvider, playerAnimationProvider, loseEventProvider, gameEventsProvider, gameButtonsHiderProvider);
        states[typeof(AttackPunchState_Game)] = new AttackPunchState_Game(this, playerMoveProvider, playerAnimationProvider, loseEventProvider, gameEventsProvider, playerZoneActionProvider, gameButtonsHiderProvider);
        states[typeof(AttackKnifeState_Game)] = new AttackKnifeState_Game(this, playerMoveProvider, playerAnimationProvider, loseEventProvider, gameEventsProvider, playerZoneActionProvider, storeWeaponProvider, gameButtonsHiderProvider);
        states[typeof(AttackWhipState_Game)] = new AttackWhipState_Game(this, playerMoveProvider, playerAnimationProvider, loseEventProvider, gameEventsProvider, playerZoneActionProvider, storeWeaponProvider, gameButtonsHiderProvider);
        states[typeof(PauseState_Game)] = new PauseState_Game(this, sceneRoot, playerMoveProvider, playerAnimationProvider, obstacleStateProvider);


        states[typeof(WinState_Game)] = new WinState_Game(this, sceneRoot, cameraProvider, playerMoveProvider, playerAnimationProvider, storeOpenLevelProvider, level);

        states[typeof(WaitLoseState_Game)] = new WaitLoseState_Game(this, sceneRoot, cameraProvider, playerMoveProvider, playerAnimationProvider, playerColliderProvider);
        states[typeof(StartLoseState_Game)] = new StartLoseState_Game(this, sceneRoot, animationElementProvider);
        states[typeof(FinishLoseState_Game)] = new FinishLoseState_Game(this, sceneRoot);
    }

    public void Initialize()
    {
        SetState(GetState<IntroState_Game>());
    }

    public void Dispose()
    {

    }

    public IState GetState<T>() where T : IState
    {
        return states[typeof(T)];
    }

    public void SetState(IState state)
    {
        _currentState?.ExitState();

        _currentState = state;
        _currentState.EnterState();
    }
}
