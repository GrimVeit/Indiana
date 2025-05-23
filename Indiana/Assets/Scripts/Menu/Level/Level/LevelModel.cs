using System;

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
        switch (_levelId)
        {
            case 0:
                OnActivate1Level?.Invoke();
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }

    private void SelectLevel(int id)
    {
        _levelId = id;
    }

    #region Output

    public event Action OnActivate1Level;
    public event Action OnActivate2Level;
    public event Action OnActivate3Level;
    public event Action OnActivate4Level;

    #endregion
}
