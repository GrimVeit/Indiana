using System.Numerics;

public class CoinSpawnerPresenter : ICoinSpawnerProvider
{
    private readonly CoinSpawnerModel _model;
    private readonly CoinSpawnerView _view;

    public CoinSpawnerPresenter(CoinSpawnerModel model, CoinSpawnerView view)
    {
        _model = model;
        _view = view;
    }

    public void Initialize()
    {
        AcvtivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();
    }

    private void AcvtivateEvents()
    {
        _view.OnSendCoins += _model.SendCoins;

        _model.OnSpawnCoins += _view.SpawnCoinsGroup;
    }

    private void DeactivateEvents()
    {
        _view.OnSendCoins -= _model.SendCoins;

        _model.OnSpawnCoins -= _view.SpawnCoinsGroup;
    }

    #region Input

    public void SpawnCoins(CoinsChances coinsChances, Vector3 spawnPosition)
    {
        _model.SpawnCoins(coinsChances, spawnPosition);
    }

    #endregion
}

public interface ICoinSpawnerProvider
{
    void SpawnCoins(CoinsChances coinsChances, Vector3 spawnPosition);
}
