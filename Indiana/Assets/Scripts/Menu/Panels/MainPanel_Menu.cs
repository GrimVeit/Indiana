using System;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel_Menu : MovePanel
{
    [SerializeField] private Button buttonLevel;
    [SerializeField] private Button buttonCollection;
    [SerializeField] private Button buttonInventory;

    public override void Initialize()
    {
        base.Initialize();

        buttonLevel.onClick.AddListener(() => OnClickToLevel?.Invoke());
        buttonCollection.onClick.AddListener(() => OnClickToCollection?.Invoke());
        buttonInventory.onClick.AddListener(() => OnClickToInventory?.Invoke());
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonLevel.onClick.RemoveListener(() => OnClickToLevel?.Invoke());
        buttonCollection.onClick.RemoveListener(() => OnClickToCollection?.Invoke());
        buttonInventory.onClick.RemoveListener(() => OnClickToInventory?.Invoke());
    }

    #region Output

    public event Action OnClickToLevel;
    public event Action OnClickToCollection;
    public event Action OnClickToInventory;

    #endregion
}
