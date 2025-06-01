using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMenuVisualPresenter
{
    private readonly WeaponMenuVisualModel _model;
    private readonly WeaponMenuVisualView _view;

    public WeaponMenuVisualPresenter(WeaponMenuVisualModel model, WeaponMenuVisualView view)
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
