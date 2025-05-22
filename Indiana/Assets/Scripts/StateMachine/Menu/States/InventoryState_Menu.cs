using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIMainMenuRoot _sceneRoot;

    public InventoryState_Menu(IGlobalStateMachineProvider machineProvider, UIMainMenuRoot sceneRoot)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OnClickToBack_Inventory += ChangeStateToMain;

        _sceneRoot.OpenInventoryPanel();
    }

    public void ExitState()
    {
        _sceneRoot.OnClickToBack_Inventory -= ChangeStateToMain;
    }

    private void ChangeStateToMain()
    {
        _machineProvider.SetState(_machineProvider.GetState<MainState_Menu>());
    }
}
