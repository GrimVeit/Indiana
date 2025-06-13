using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro1State_Menu : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIMainMenuRoot _sceneRoot;

    private IEnumerator timer;

    public Intro1State_Menu(IGlobalStateMachineProvider machineProvider, UIMainMenuRoot sceneRoot)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OpenIntro1Panel();

        if (timer != null) Coroutines.Stop(timer);

        timer = Timer(2);
        Coroutines.Start(timer);
    }

    public void ExitState()
    {
        if (timer != null) Coroutines.Stop(timer);
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);

        ChangeStateToIntro2();
    }

    private void ChangeStateToIntro2()
    {
        _machineProvider.SetState(_machineProvider.GetState<Intro2State_Menu>());
    }
}
