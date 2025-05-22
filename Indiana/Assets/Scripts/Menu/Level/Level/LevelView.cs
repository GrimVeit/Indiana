using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelView : View
{
    [SerializeField] private List<Button> buttonsLevels = new();

    public void Initialize()
    {
        buttonsLevels.ForEach(bt => bt.onClick.AddListener(HandleActivateLevel));
    }

    public void Dispose()
    {
        buttonsLevels.ForEach(bt => bt.onClick.RemoveListener(HandleActivateLevel));
    }

    #region Output

    public event Action OnActivateLevel;

    private void HandleActivateLevel()
    {
        OnActivateLevel?.Invoke();
    }

    #endregion
}
