using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState_Game : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameSceneRoot_Game _sceneRoot;

    public PauseState_Game(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Game sceneRoot)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
    }
    
    public void EnterState()
    {
        Debug.Log("<color=red>ACTIVATE STATE - PAUSE STATE / GAME</color>");

        _sceneRoot.OnClickToResume_Pause += ChangeStateToMain;

        _sceneRoot.OpenPausePanel();
    }

    public void ExitState()
    {
        _sceneRoot.OnClickToResume_Pause -= ChangeStateToMain;

        _sceneRoot.ClosePausePanel();
    }

    private void ChangeStateToMain()
    {
        _machineProvider.SetState(_machineProvider.GetState<MainState_Game>());
    }
}
