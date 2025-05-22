using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelVisualModel
{
    public event Action<int> OnOpenVisual;
    public event Action<int> OnCloseVisual;

    private readonly IStoreLevelEventsProvider _storeLevelEventsProvider;

    public LevelVisualModel(IStoreLevelEventsProvider storeLevelEventsProvider)
    {
        _storeLevelEventsProvider = storeLevelEventsProvider;
        _storeLevelEventsProvider.OnChangeStatusLevel += SetStatusLevelVisual;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _storeLevelEventsProvider.OnChangeStatusLevel -= SetStatusLevelVisual;
    }

    private void SetStatusLevelVisual(int id, bool isOpen)
    {
        if (isOpen)
        {
            OnOpenVisual?.Invoke(id);
        }
        else
        {
            OnCloseVisual?.Invoke(id);
        }
    }
}
