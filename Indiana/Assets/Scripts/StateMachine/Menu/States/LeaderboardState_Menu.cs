using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIMainMenuRoot _sceneRoot;

    public LeaderboardState_Menu(IGlobalStateMachineProvider machineProvider, UIMainMenuRoot sceneRoot)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OnClickToBack_Leaderboard += ChangeStateToMain;

        _sceneRoot.OpenLeaderboardPanel();
    }

    public void ExitState()
    {
        _sceneRoot.OnClickToBack_Leaderboard -= ChangeStateToMain;
    }

    private void ChangeStateToMain()
    {
        _machineProvider.SetState(_machineProvider.GetState<MainState_Menu>());
    }
}
