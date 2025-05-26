using System.Collections;
using System.Collections.Generic;

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

    }

    public void ExitState()
    {

    }

    private void ChangeStateToWin()
    {
        _machineProvider.SetState(_machineProvider.GetState<MainState_Menu>());
    }
}
