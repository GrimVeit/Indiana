using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro2State_Menu : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIMainMenuRoot _sceneRoot;

    private IEnumerator timer;
    
    public Intro2State_Menu(IGlobalStateMachineProvider machineProvider, UIMainMenuRoot sceneRoot)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OpenIntro2Panel();

        if (timer != null) Coroutines.Stop(timer);

        timer = Timer(2);
        Coroutines.Start(timer);
    }

    public void ExitState()
    {
        _sceneRoot.CloseIntro2Panel();

        if (timer != null) Coroutines.Stop(timer);
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);

        ChangeStateToStartMenu();
    }

    private void ChangeStateToStartMenu()
    {
        _machineProvider.SetState(_machineProvider.GetState<StartMainState_Menu>());
    }
}
