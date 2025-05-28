using System;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel_Game : MovePanel
{
    [SerializeField] private Button buttonResume;

    public override void Initialize()
    {
        base.Initialize();

        buttonResume.onClick.AddListener(() => OnClickToResume?.Invoke());
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonResume.onClick.RemoveListener(() => OnClickToResume?.Invoke());
    }

    #region Output

    public event Action OnClickToResume;

    #endregion
}
