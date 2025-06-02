using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderPanel_Game : MovePanel
{
    [SerializeField] private Button buttonPause;
    [SerializeField] private Button buttonExit;

    public override void Initialize()
    {
        base.Initialize();

        buttonPause.onClick.AddListener(() => OnClickToPause?.Invoke());
        buttonExit.onClick.AddListener(() => OnClickToExit?.Invoke());

    }

    public override void Dispose()
    {
        base.Dispose();

        buttonPause.onClick.RemoveListener(() => OnClickToPause?.Invoke());
        buttonExit.onClick.RemoveListener(() => OnClickToExit?.Invoke());
    }

    #region Output

    public event Action OnClickToPause;
    public event Action OnClickToExit;

    #endregion
}
