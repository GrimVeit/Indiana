using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeveLState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIMainMenuRoot _sceneRoot;

    public LeveLState_Menu(IGlobalStateMachineProvider machineProvider, UIMainMenuRoot sceneRoot)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OnClickToBack_Level += ChangeStateToMain;

        _sceneRoot.OpenLevelPanel();
    }

    public void ExitState()
    {
        _sceneRoot.OnClickToBack_Level -= ChangeStateToMain;
    }

    private void ChangeStateToMain()
    {
        _machineProvider.SetState(_machineProvider.GetState<MainState_Menu>());
    }
}
