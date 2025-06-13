using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NicknamePresentation1State_Menu : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIMainMenuRoot _sceneRoot;

    private IEnumerator timer;
    
    public NicknamePresentation1State_Menu(IGlobalStateMachineProvider machineProvider, UIMainMenuRoot sceneRoot)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OpenNicknamePresentation1Panel();

        if(timer != null) Coroutines.Stop(timer);

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

        ChangeStateToNicknamePresentation2();
    }

    private void ChangeStateToNicknamePresentation2()
    {
        _machineProvider.SetState(_machineProvider.GetState<NicknamePresentation2State_Menu>());
    }
}
