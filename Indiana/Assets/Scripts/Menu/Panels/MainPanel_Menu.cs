using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel_Menu : MovePanel
{
    [SerializeField] private Button buttonLevel;

    public override void Initialize()
    {
        base.Initialize();

        buttonLevel.onClick.AddListener(() => OnClickToLevel?.Invoke());
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonLevel.onClick.RemoveListener(() => OnClickToLevel?.Invoke());
    }

    #region Output

    public event Action OnClickToLevel;
    public event Action OnClickToCollection;
    public event Action OnClickToInventory;

    #endregion
}
