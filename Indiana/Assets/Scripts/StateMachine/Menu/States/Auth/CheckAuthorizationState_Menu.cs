using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAuthorizationState_Menu : IState
{
    private readonly FirebaseAuthenticationPresenter _authenticationPresenter;

    private IGlobalStateMachineProvider _stateMachineProvider;

    public CheckAuthorizationState_Menu(IGlobalStateMachineProvider stateMachineProvider, FirebaseAuthenticationPresenter authenticationPresenter)
    {
        _stateMachineProvider = stateMachineProvider;
        _authenticationPresenter = authenticationPresenter;
    }

    public void EnterState()
    {
        if (_authenticationPresenter.IsAuthorization())
            ChangeStateToStartMain();
        else
            ChangeStateToAuthorization();
    }

    public void ExitState()
    {

    }

    private void ChangeStateToStartMain()
    {
        _stateMachineProvider.SetState(_stateMachineProvider.GetState<StartMainState_Menu>());
    }

    private void ChangeStateToAuthorization()
    {
        _stateMachineProvider.SetState(_stateMachineProvider.GetState<AuthorizationState_Menu>());
    }
}
