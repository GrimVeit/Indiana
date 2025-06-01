using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGameVisualPresenter
{
    private readonly WeaponGameVisualModel _model;
    private readonly WeaponGameVisualView _view;

    public WeaponGameVisualPresenter(WeaponGameVisualModel model, WeaponGameVisualView view)
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
        _model.OnChangeCountWeapon += _view.SetData;
    }

    private void DeactivateEvents()
    {
        _model.OnChangeCountWeapon -= _view.SetData;
    }
}
