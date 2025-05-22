using System;

public class StoreLevelPresenter : IStoreOpenLevelProvider, IStoreSelectLevelProvider, IStoreStatusLevelEventsProvider, IStoreSelectLevelEventsProvider
{
    private readonly StoreLevelModel _model;

    public StoreLevelPresenter(StoreLevelModel model)
    {
        _model = model;
    }

    public void Initialize()
    {
        _model.Initialize();
    }

    public void Dispose()
    {
        _model.Dispose();
    }



    #region Output

    public event Action<int, bool> OnChangeStatusLevel
    {
        add => _model.OnChangeStatusLevel += value;
        remove => _model.OnChangeStatusLevel -= value;
    }

    public event Action<int> OnSelectLevel
    {
        add => _model.OnSelectLevel += value;
        remove => _model.OnSelectLevel -= value;
    }

    #endregion



    #region Input

    public void OpenLevel(int id)
    {
        _model.OpenLevel(id);
    }

    public void SelectLevel(int id)
    {
        _model.SelectLevel(id);
    }

    #endregion
}

public interface IStoreOpenLevelProvider
{
    void OpenLevel(int id);
}

public interface IStoreSelectLevelProvider
{
    void SelectLevel(int id);
}

public interface IStoreStatusLevelEventsProvider
{
    public event Action<int, bool> OnChangeStatusLevel;
}

public interface IStoreSelectLevelEventsProvider
{
    public event Action<int> OnSelectLevel;
}
