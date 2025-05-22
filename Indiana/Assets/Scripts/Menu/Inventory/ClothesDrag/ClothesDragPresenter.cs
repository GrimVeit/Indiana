using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClothesDragPresenter : IPseudoChipActivatorProvider
{
    private readonly ClothesDragModel _model;
    private readonly ClothesDragView _view;

    public ClothesDragPresenter(ClothesDragModel pseudoChipModel, ClothesDragView pseudoChipView)
    {
        this._model = pseudoChipModel;
        this._view = pseudoChipView;
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
        _view.OnGrabClothesItem_Action += _model.GrabPseudoChip;
        _view.OnStartMove_Action += _model.StartMove;
        _view.OnMove_Action += _model.Move;
        _view.OnEndMove_Action += _model.EndMove;

        _model.OnGrabClothesItem += _view.GrabPseudoChip;
        _model.OnUngrabCurrentClothesItem += _view.UngrabCurrentPseudoChip;
        _model.OnStartMove += _view.StartMove;
        _model.OnMove += _view.Move;
        _model.OnEndMove += _view.EndMove;
        _model.OnTeleporting += _view.Teleport;
    }

    private void DeactivateEvents()
    {
        _view.OnGrabClothesItem_Action -= _model.GrabPseudoChip;
        _view.OnStartMove_Action -= _model.StartMove;
        _view.OnMove_Action -= _model.Move;
        _view.OnEndMove_Action -= _model.EndMove;

        _model.OnGrabClothesItem -= _view.GrabPseudoChip;
        _model.OnUngrabCurrentClothesItem -= _view.UngrabCurrentPseudoChip;
        _model.OnStartMove -= _view.StartMove;
        _model.OnMove -= _view.Move;
        _model.OnEndMove -= _view.EndMove;
        _model.OnTeleporting -= _view.Teleport;
    }

    #region Input

    public void Activate()
    {
        _model.Activate();
    }

    public void Deactivate()
    {
        _model.Deactivate();
    }

    #endregion
}

public interface IPseudoChipActivatorProvider
{
    void Activate();
    void Deactivate();
}
