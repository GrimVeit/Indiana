using System;

public class LevelModel
{ 
    private readonly IStoreSelectLevelEventsProvider _eventsProvider;
    private readonly ISoundProvider _soundProvider;

    private int _levelId = 0;

    public LevelModel(IStoreSelectLevelEventsProvider eventsProvider, ISoundProvider soundProvider)
    {
        _eventsProvider = eventsProvider;
        _eventsProvider.OnSelectLevel += SelectLevel;
        _soundProvider = soundProvider;

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
        UnityEngine.Debug.Log(_levelId);

        switch (_levelId)
        {
            case 0:
                OnActivate1Level?.Invoke();
                break;
            case 1:
                OnActivate2Level?.Invoke();
                break;
            case 2:
                OnActivate3Level?.Invoke();
                break;
            case 3:
                OnActivate4Level?.Invoke();
                break;
        }

        _soundProvider.PlayOneShot("Click");
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
