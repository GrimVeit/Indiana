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
        _sceneRoot.OnClickToLevel_Main += ChangeStateToLevel;
        _sceneRoot.OnClickToCollection_Main += ChangeStateToCollection;
        _sceneRoot.OnClickToInventory_Main += ChangeStateToInventory;
        _sceneRoot.OnClickToLeaderboard_Main += ChangeStateToLeaderboard;

        _sceneRoot.OpenMainPanel();
    }

    public void ExitState()
    {
        _sceneRoot.OnClickToLevel_Main -= ChangeStateToLevel;
        _sceneRoot.OnClickToCollection_Main -= ChangeStateToCollection;
        _sceneRoot.OnClickToInventory_Main -= ChangeStateToInventory;
        _sceneRoot.OnClickToLeaderboard_Main -= ChangeStateToLeaderboard;
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

    private void ChangeStateToLeaderboard()
    {
        _machineProvider.SetState(_machineProvider.GetState<LeaderboardState_Menu>());
    }
}
