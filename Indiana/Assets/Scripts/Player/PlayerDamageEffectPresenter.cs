using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageEffectPresenter : IPlayerDamageEffectProvider
{
    private readonly PlayerDamageEffectModel _model;
    private readonly PlayerDamageEffectView _view;

    public PlayerDamageEffectPresenter(PlayerDamageEffectModel model, PlayerDamageEffectView view)
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
        _model.OnPlayEffect += _view.PlayEffect;
    }

    private void DeactivateEvents()
    {
        _model.OnPlayEffect -= _view.PlayEffect;
    }

    #region Input

    public void PlayEffect()
    {
        _model.PlayEffect();
    }

    #endregion
}

public interface IPlayerDamageEffectProvider
{
    void PlayEffect();
}
