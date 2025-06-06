using System;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel_Game : MoveRotatePanel
{
    [SerializeField] private Button buttonExit;

    public override void Initialize()
    {
        base.Initialize();

        buttonExit.onClick.AddListener(() => OnClickToExit?.Invoke());
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonExit.onClick.RemoveListener(() => OnClickToExit?.Invoke());
    }

    #region Output

    public event Action OnClickToExit;

    #endregion
}
