using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateMachine : IGlobalStateMachineProvider
{
    private readonly Dictionary<Type, IState> states = new();

    private IState _currentState;

    public MenuStateMachine
        (UIMainMenuRoot sceneRoot, 
        FirebaseAuthenticationPresenter firebaseAuthenticationPresenter,
        FirebaseDatabasePresenter firebaseDatabasePresenter,
        NicknameRandomPresenter nicknameRandomPresenter,
        InternetPresenter internetPresenter)
    {
        states[typeof(CheckAuthorizationState_Menu)] = new CheckAuthorizationState_Menu(this, firebaseAuthenticationPresenter);
        states[typeof(AuthorizationState_Menu)] = new AuthorizationState_Menu(this, nicknameRandomPresenter, firebaseAuthenticationPresenter, firebaseDatabasePresenter, sceneRoot, internetPresenter);

        states[typeof(NicknamePresentation1State_Menu)] = new NicknamePresentation1State_Menu(this, sceneRoot);
        states[typeof(NicknamePresentation2State_Menu)] = new NicknamePresentation2State_Menu(this, sceneRoot);
        states[typeof(Intro1State_Menu)] = new Intro1State_Menu(this, sceneRoot);
        states[typeof(Intro2State_Menu)] = new Intro2State_Menu (this, sceneRoot);

        states[typeof(StartMainState_Menu)] = new StartMainState_Menu(this, firebaseDatabasePresenter, firebaseAuthenticationPresenter);
        states[typeof(MainState_Menu)] = new MainState_Menu(this, sceneRoot);
        states[typeof(LeveLState_Menu)] = new LeveLState_Menu(this, sceneRoot);
        states[typeof(CollectionState_Menu)] = new CollectionState_Menu(this, sceneRoot);
        states[typeof(InventoryState_Menu)] = new InventoryState_Menu(this, sceneRoot);
        states[typeof(LeaderboardState_Menu)] = new LeaderboardState_Menu(this, sceneRoot);
    }

    public void Initialize()
    {
        SetState(GetState<CheckAuthorizationState_Menu>());
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
