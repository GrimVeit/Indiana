using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIMainMenuRoot _sceneRoot;

    public MainState_Menu(IGlobalStateMachineProvider machineProvider, UIMainMenuRoot sceneRoot)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {

    }

    public void ExitState()
    {

    }

    private void ChangeStateToLevel()
    {
        _machineProvider.SetState(_machineProvider.GetState<LeveLState_Menu>());
    }

    private void ChangeStateToCollection()
    {
        _machineProvider.SetState(_machineProvider.GetState<CollectionState_Menu>());
    }

    private void ChangeStateToInventory()
    {
        _machineProvider.SetState(_machineProvider.GetState<InventoryState_Menu>());
    }
}
