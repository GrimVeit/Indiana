using System;

public class LevelPresenter
{
    private readonly LevelModel _model;
    private readonly LevelView _view;

    public LevelPresenter(LevelModel model, LevelView view)
    {
        _model = model; _view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        _model.Initialize();
        _view.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        _model.Dispose();
        _view.Dispose();
    }

    private void ActivateEvents()
    {
        _view.OnActivateLevel += _model.ActivateLevel;
    }

    private void DeactivateEvents()
    {
        _view.OnActivateLevel -= _model.ActivateLevel;
    }

    #region Output

    public event Action OnActivate1Level
    {
        add => _model.OnActivate1Level += value;
        remove => _model.OnActivate1Level -= value;
    }

    public event Action OnActivate2Level
    {
        add => _model.OnActivate2Level += value;
        remove => _model.OnActivate2Level -= value;
    }

    public event Action OnActivate3Level
    {
        add => _model.OnActivate3Level += value;
        remove => _model.OnActivate3Level -= value;
    }

    public event Action OnActivate4Level
    {
        add => _model.OnActivate4Level += value;
        remove => _model.OnActivate4Level -= value;
    }

    #endregion
}
