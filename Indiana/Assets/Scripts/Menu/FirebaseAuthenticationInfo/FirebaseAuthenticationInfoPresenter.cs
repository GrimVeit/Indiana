using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseAuthenticationInfoPresenter
{
    private readonly FirebaseAuthenticationInfoModel _model;
    private readonly FirebaseAuthenticationInfoView _view;

    public FirebaseAuthenticationInfoPresenter(FirebaseAuthenticationInfoModel model, FirebaseAuthenticationInfoView view)
    {
        _model = model;
        _view = view;
    }


    public void Initialize()
    {
        ActivateEvents();

        _model.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        _model.Dispose();
    }

    private void ActivateEvents()
    {
        _model.OnSetMessage += _view.SetMessgae;
    }

    private void DeactivateEvents()
    {
        _model.OnSetMessage -= _view.SetMessgae;
    }
}
