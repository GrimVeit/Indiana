using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelVisualModel
{
    public event Action<int> OnOpenVisual;
    public event Action<int> OnCloseVisual;

    private readonly IStoreStatusLevelEventsProvider _storeLevelEventsProvider;
    private readonly IStoreSelectLevelProvider _selectLevelProvider;

    public LevelVisualModel(IStoreStatusLevelEventsProvider storeLevelEventsProvider, IStoreSelectLevelProvider selectLevelProvider)
    {
        _storeLevelEventsProvider = storeLevelEventsProvider;
        _storeLevelEventsProvider.OnChangeStatusLevel += SetStatusLevelVisual;
        _selectLevelProvider = selectLevelProvider;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _storeLevelEventsProvider.OnChangeStatusLevel -= SetStatusLevelVisual;
    }

    public void SelectLevel(int id)
    {
        _selectLevelProvider.SelectLevel(id);
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
