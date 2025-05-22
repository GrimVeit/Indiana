using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateMachine : IGlobalStateMachineProvider
{
    private readonly Dictionary<Type, IState> states = new();

    private IState _currentState;

    public MenuStateMachine(UIMainMenuRoot sceneRoot)
    {
        states[typeof(MainState_Menu)] = new MainState_Menu(this, sceneRoot);
        states[typeof(LeveLState_Menu)] = new LeveLState_Menu(this, sceneRoot);
        states[typeof(CollectionState_Menu)] = new CollectionState_Menu(this, sceneRoot);
        states[typeof(InventoryState_Menu)] = new InventoryState_Menu(this, sceneRoot);
    }

    public void Initialize()
    {
        SetState(GetState<MainState_Menu>());
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
