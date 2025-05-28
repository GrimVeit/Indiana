using System;
using System.Collections;
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
        ICameraProvider cameraProvider)
    {
        states[typeof(IntroState_Game)] = new IntroState_Game(this, gameEventsProvider);
        states[typeof(MainState_Game)] = new MainState_Game(this, sceneRoot, loseEventProvider, gameEventsProvider);
        states[typeof(PauseState_Game)] = new PauseState_Game(this, sceneRoot);
        states[typeof(WinState_Game)] = new WinState_Game(this, sceneRoot, cameraProvider);
        states[typeof(LoseState_Game)] = new LoseState_Game(this, sceneRoot, cameraProvider);
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
