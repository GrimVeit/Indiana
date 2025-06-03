using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreenPanel : MovePanel
{
    [SerializeField] private LazyMotionGroup lazyMotionGroup;

    [SerializeField] private List<Panel> panels = new();

    private void Awake()
    {
        OnDeactivatePanel += lazyMotionGroup.Deactivate;

        Initialize();
    }

    private void OnDestroy()
    {
        OnDeactivatePanel -= lazyMotionGroup.Deactivate;

        Dispose();
    }

    public override void Initialize()
    {
        base.Initialize();

        lazyMotionGroup.Initialize();

        panels.ForEach(data => data.Initialize());
    }

    public override void Dispose()
    {
        base.Dispose();

        lazyMotionGroup.Dispose();

        panels.ForEach(data => data.Dispose());
    }

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        lazyMotionGroup.Activate();

        panels.ForEach(data => data.ActivatePanel());
    }

    public override void DeactivatePanel()
    {
        base.DeactivatePanel();

        panels.ForEach(data => data.DeactivatePanel());
    }
}
