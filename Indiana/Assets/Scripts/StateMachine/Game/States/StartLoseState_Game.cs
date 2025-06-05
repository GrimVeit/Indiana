using System.Collections;
using UnityEngine;

public class StartLoseState_Game : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameSceneRoot_Game _sceneRoot;
    private readonly IAnimationElementProvider _animationElementProvider;

    private IEnumerator timer;

    public StartLoseState_Game(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Game sceneRoot, IAnimationElementProvider animationElementProvider)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
        _animationElementProvider = animationElementProvider;
    }

    public void EnterState()
    {
        Debug.Log("<color=red>ACTIVATE STATE - LOSE STATE / GAME</color>");

        _sceneRoot.OpenBlackBackgroundPanel();
        _sceneRoot.OpenStartLosePanel();
        _animationElementProvider.Activate("BirdLose");

        if(timer != null) Coroutines.Stop(timer);

        timer = Timer(1);

        Coroutines.Start(timer);
    }

    public void ExitState()
    {
        if (timer != null) Coroutines.Stop(timer);
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);

        ChangeStateToFinishLoseState();
    }

    private void ChangeStateToFinishLoseState()
    {
        _machineProvider.SetState(_machineProvider.GetState<FinishLoseState_Game>());
    }
}
