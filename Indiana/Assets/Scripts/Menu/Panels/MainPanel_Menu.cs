using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel_Menu : Panel
{
    [SerializeField] private Button buttonLevel;
    [SerializeField] private Button buttonCollection;
    [SerializeField] private Button buttonInventory;
    [SerializeField] private Button buttonLeaderboard;

    [SerializeField] private List<Panel> panelsChildren = new();

    public override void Initialize()
    {
        base.Initialize();

        buttonLevel.onClick.AddListener(() => OnClickToLevel?.Invoke());
        buttonCollection.onClick.AddListener(() => OnClickToCollection?.Invoke());
        buttonInventory.onClick.AddListener(() => OnClickToInventory?.Invoke());
        buttonLeaderboard.onClick.AddListener(() => OnClickToLeaderboard?.Invoke());

        panelsChildren.ForEach(data => data.Initialize());
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonLevel.onClick.RemoveListener(() => OnClickToLevel?.Invoke());
        buttonCollection.onClick.RemoveListener(() => OnClickToCollection?.Invoke());
        buttonInventory.onClick.RemoveListener(() => OnClickToInventory?.Invoke());
        buttonLeaderboard.onClick.RemoveListener(() => OnClickToLeaderboard?.Invoke());

        panelsChildren.ForEach(data => data.Dispose());
    }

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        panelsChildren.ForEach(data => data.ActivatePanel());
    }

    public override void DeactivatePanel()
    {
        base.DeactivatePanel();

        panelsChildren.ForEach(data => data.DeactivatePanel());
    }

    #region Output

    public event Action OnClickToLevel;
    public event Action OnClickToCollection;
    public event Action OnClickToInventory;
    public event Action OnClickToLeaderboard;

    #endregion
}
