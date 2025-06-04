using System.Collections;
using System.Collections.Generic;
using System.Numerics;

public class WeaponSpawnerPresenter : IWeaponSpawnerProvider
{
    private readonly WeaponSpawnerModel _model;
    private readonly WeaponSpawnerView _view;

    public WeaponSpawnerPresenter(WeaponSpawnerModel model, WeaponSpawnerView view)
    {
        _model = model;
        _view = view;
    }

    public void Initialize()
    {
        ActivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();
    }

    private void ActivateEvents()
    {
        _view.OnSendWeapon += _model.SendWeapon;

        _model.OnSpawnWeapon += _view.SpawnWeapon;
    }

    private void DeactivateEvents()
    {
        _view.OnSendWeapon -= _model.SendWeapon;

        _model.OnSpawnWeapon -= _view.SpawnWeapon;
    }


    #region Input

    public void SpawnWeapon(WeaponChances obstacleChances, Vector3 spawnPosition)
    {
        _model.SpawnWeapon(obstacleChances, spawnPosition);
    }

    #endregion
}

public interface IWeaponSpawnerProvider
{
    void SpawnWeapon(WeaponChances obstacleChances, Vector3 spawnPosition);
}
