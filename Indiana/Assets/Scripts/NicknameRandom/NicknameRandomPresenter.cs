using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NicknameRandomPresenter
{
    private readonly NicknameRandomModel _model;
    private readonly NicknameRandomView _view;

    public NicknameRandomPresenter(NicknameRandomModel model, NicknameRandomView view)
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
        _model.OnCreateNickname += _view.SetNickname;
    }

    private void DeactivateEvents()
    {
        _model.OnCreateNickname -= _view.SetNickname;
    }

    #region Input

    public void CreateRandomNickname(int minLength, int maxLength)
    {
        _model.CreateRandomNickname(minLength, maxLength);
    }

    #endregion

    #region Output

    public event Action OnSuccess
    {
        add => _model.OnSuccess += value;
        remove => _model.OnSuccess -= value;
    }

    public event Action OnFailure
    {
        add => _model.OnFailure += value;
        remove => _model.OnFailure -= value;
    }

    public event Action<string> OnCreateNickname
    {
        add => _model.OnCreateNickname += value;
        remove => _model.OnCreateNickname -= value;
    }

    #endregion
}
