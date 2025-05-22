using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModel
{ 
    private readonly IStoreSelectLevelEventsProvider _eventsProvider;

    private int _levelId;

    public LevelModel(IStoreSelectLevelEventsProvider eventsProvider)
    {
        _eventsProvider = eventsProvider;
        _eventsProvider.OnSelectLevel += SelectLevel;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _eventsProvider.OnSelectLevel -= SelectLevel;
    }

    public void ActivateLevel()
    {
        Debug.Log("Select level: " + _levelId);
    }

    private void SelectLevel(int id)
    {
        _levelId = id;
    }
}
