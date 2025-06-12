using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardPanel_Menu : Panel
{
    [SerializeField] private Button buttonBack;

    [SerializeField] private List<Panel> panels = new();

    public override void Initialize()
    {
        base.Initialize();

        buttonBack.onClick.AddListener(() => OnClickToBack?.Invoke());

        panels.ForEach(data => data.Initialize());
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonBack.onClick.RemoveListener(() => OnClickToBack?.Invoke());

        panels.ForEach(data => data.Dispose());
    }

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        panels.ForEach(data => data.ActivatePanel());
    }

    public override void DeactivatePanel()
    {
        base.DeactivatePanel();

        panels.ForEach(data => data.DeactivatePanel());
    }

    #region Output

    public event Action OnClickToBack;

    #endregion
}
