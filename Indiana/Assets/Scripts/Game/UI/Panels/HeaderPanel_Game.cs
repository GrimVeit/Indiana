using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderPanel_Game : MovePanel
{
    [SerializeField] private Button buttonPause;

    public override void Initialize()
    {
        base.Initialize();

        buttonPause.onClick.AddListener(() => OnClickToPause?.Invoke());
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonPause.onClick.RemoveListener(() => OnClickToPause?.Invoke());
    }

    #region Output

    public event Action OnClickToPause;

    #endregion
}
