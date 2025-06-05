using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationElementPresenter : IAnimationElementProvider
{
    private readonly AnimationElementModel _model;
    private readonly AnimationElementView _view;

    public AnimationElementPresenter(AnimationElementModel model, AnimationElementView view)
    {
        _model = model; _view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        _view.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        _view.Dispose();
    }

    private void ActivateEvents()
    {
        _model.OnActivateAnimation += _view.Animate;
    }

    private void DeactivateEvents()
    {
        _model.OnActivateAnimation -= _view.Animate;
    }

    #region Input

    public void Activate(string id)
    {
        _model.Animate(id);
    }

    #endregion
}

public interface IAnimationElementProvider
{
    public void Activate(string id);
}
