using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NicknamePresentation2State_Menu : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIMainMenuRoot _sceneRoot;

    private IEnumerator timer;

    public NicknamePresentation2State_Menu(IGlobalStateMachineProvider machineProvider, UIMainMenuRoot sceneRoot)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OpenNicknamePresentation2Panel();

        if (timer != null) Coroutines.Stop(timer);

        timer = Timer(3);
        Coroutines.Start(timer);
    }

    public void ExitState()
    {
        if (timer != null) Coroutines.Stop(timer);
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);

        ChangeStateToIntro1();
    }

    private void ChangeStateToIntro1()
    {
        _machineProvider.SetState(_machineProvider.GetState<Intro1State_Menu>());
    }
}
