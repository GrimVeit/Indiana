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
        IPlayerZoneActionProvider playerZoneActionProvider)
    {
        states[typeof(IntroState_Game)] = new IntroState_Game(this, gameEventsProvider);
        states[typeof(MainState_Game)] = new MainState_Game(this, sceneRoot, loseEventProvider, gameEventsProvider, playerInputEventsProvider);
        states[typeof(RunState_Game)] = new RunState_Game(this, playerMoveProvider, playerAnimationProvider, loseEventProvider, gameEventsProvider);
        states[typeof(AttackPunchState_Game)] = new AttackPunchState_Game(this, playerMoveProvider, playerAnimationProvider, loseEventProvider, gameEventsProvider, playerZoneActionProvider);
        states[typeof(AttackKnifeState_Game)] = new AttackKnifeState_Game(this, playerMoveProvider, playerAnimationProvider, loseEventProvider, gameEventsProvider, playerZoneActionProvider);
        states[typeof(AttackWhipState_Game)] = new AttackWhipState_Game(this, playerMoveProvider, playerAnimationProvider, loseEventProvider, gameEventsProvider, playerZoneActionProvider);
        states[typeof(PauseState_Game)] = new PauseState_Game(this, sceneRoot);
        states[typeof(WinState_Game)] = new WinState_Game(this, sceneRoot, cameraProvider, playerMoveProvider, playerAnimationProvider);
        states[typeof(LoseState_Game)] = new LoseState_Game(this, sceneRoot, cameraProvider, playerMoveProvider, playerAnimationProvider);
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
