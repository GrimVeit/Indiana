using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthorizationState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _globalStateMachineProvider;

    private readonly NicknameRandomPresenter _nicknameRandomPresenter;
    private readonly FirebaseAuthenticationPresenter _firebaseAuthenticationPresenter;
    private readonly FirebaseDatabasePresenter _firebaseDatabaseRealtimePresenter;
    private readonly InternetPresenter _internetPresenter;
    private readonly UIMainMenuRoot _sceneRoot;

    public AuthorizationState_Menu(IGlobalStateMachineProvider globalStateMachineProvider, NicknameRandomPresenter nicknameRandomPresenter, FirebaseAuthenticationPresenter firebaseAuthenticationPresenter, FirebaseDatabasePresenter firebaseDatabaseRealtimePresenter, UIMainMenuRoot sceneRoot, InternetPresenter internetPresenter)
    {
        _globalStateMachineProvider = globalStateMachineProvider;
        _nicknameRandomPresenter = nicknameRandomPresenter;
        _firebaseAuthenticationPresenter = firebaseAuthenticationPresenter;
        _firebaseDatabaseRealtimePresenter = firebaseDatabaseRealtimePresenter;
        _sceneRoot = sceneRoot;
        _internetPresenter = internetPresenter;
    }

    public void EnterState()
    {
        Debug.Log("<color=red>ACTIVATE STATE - AUTHORIZATION STATE / MENU</color>");

        _internetPresenter.OnInternetAvailable += CreateRandomNickname;

        _nicknameRandomPresenter.OnFailure += CreateRandomNickname;
        _nicknameRandomPresenter.OnSuccess += _firebaseAuthenticationPresenter.SignUp;

        _nicknameRandomPresenter.OnCreateNickname += _firebaseAuthenticationPresenter.SetNickname;
        _nicknameRandomPresenter.OnCreateNickname += _firebaseDatabaseRealtimePresenter.SetNickname;

        _firebaseAuthenticationPresenter.OnSignUpError += CreateRandomNickname;
        _firebaseAuthenticationPresenter.OnSignUp += _firebaseDatabaseRealtimePresenter.CreateEmptyDataToServer;
        _firebaseAuthenticationPresenter.OnSignUp += ChangeStateToNicknamePresentation1;

        _sceneRoot.OpenAuthorizationPanel();

        _internetPresenter.StartCheckConnection();
    }

    public void ExitState()
    {
        _internetPresenter.OnInternetAvailable -= CreateRandomNickname;

        _nicknameRandomPresenter.OnFailure -= CreateRandomNickname;
        _nicknameRandomPresenter.OnSuccess -= _firebaseAuthenticationPresenter.SignUp;

        _nicknameRandomPresenter.OnCreateNickname -= _firebaseAuthenticationPresenter.SetNickname;
        _nicknameRandomPresenter.OnCreateNickname -= _firebaseDatabaseRealtimePresenter.SetNickname;

        _firebaseAuthenticationPresenter.OnSignUpError -= CreateRandomNickname;
        _firebaseAuthenticationPresenter.OnSignUp -= _firebaseDatabaseRealtimePresenter.CreateEmptyDataToServer;
        _firebaseAuthenticationPresenter.OnSignUp -= ChangeStateToNicknamePresentation1;
    }

    private void CreateRandomNickname()
    {
        _nicknameRandomPresenter.CreateRandomNickname(5, 17);
    }

    private void ChangeStateToNicknamePresentation1()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<NicknamePresentation1State_Menu>());
    }
}
