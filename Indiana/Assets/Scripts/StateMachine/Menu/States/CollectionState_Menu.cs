using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIMainMenuRoot _sceneRoot;

    public CollectionState_Menu(IGlobalStateMachineProvider machineProvider, UIMainMenuRoot sceneRoot)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OnClickToBack_Collection += ChangeStateToMain;

        _sceneRoot.OpenCollectionPanel();
    }

    public void ExitState()
    {
        _sceneRoot.OnClickToBack_Collection -= ChangeStateToMain;
    }

    private void ChangeStateToMain()
    {
        _machineProvider.SetState(_machineProvider.GetState<MainState_Menu>());
    }
}
