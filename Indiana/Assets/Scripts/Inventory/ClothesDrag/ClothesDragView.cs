using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesDragView : View
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private List<ClothesDrag> clothesDrags = new List<ClothesDrag>();

    [SerializeField] private ClothesDrag currentClothesDrag;

    public void Initialize()
    {
        for (int i = 0; i < clothesDrags.Count; i++)
        {
            clothesDrags[i].OnGrabbing += OnGrabClothesItem;
            clothesDrags[i].Initialize();
        }
    }

    public void Dispose()
    {
        for (int i = 0; i < clothesDrags.Count; i++)
        {
            clothesDrags[i].OnGrabbing -= OnGrabClothesItem;
            clothesDrags[i].Dispose();
        }
    }

    public void GrabPseudoChip(ClothesDrag chip)
    {
        UngrabCurrentPseudoChip();

        currentClothesDrag = chip;

        currentClothesDrag.OnStartMove += OnStartMove;
        currentClothesDrag.OnMove += OnMove;
        currentClothesDrag.OnEndMove += OnEndMove;
    }

    public void UngrabCurrentPseudoChip()
    {
        if (currentClothesDrag != null)
        {
            currentClothesDrag.OnStartMove -= OnStartMove;
            currentClothesDrag.OnMove -= OnMove;
            currentClothesDrag.OnEndMove -= OnEndMove;

            Teleport();
        }
    }

    public void Teleport()
    {
        currentClothesDrag.Teleport();
    }

    public void StartMove()
    {
        currentClothesDrag.StartMove();
    }

    public void EndMove()
    {
        currentClothesDrag.EndMove();
    }

    public void Move(Vector2 vector)
    {
        currentClothesDrag.Move(vector);
    }

    #region Input

    public void OnGrabClothesItem(ClothesDrag pseudoChip)
    {
        OnGrabClothesItem_Action?.Invoke(pseudoChip);
    }

    private void OnMove(Vector2 vector)
    {
        OnMove_Action?.Invoke(vector / canvas.scaleFactor);
    }

    private void OnStartMove()
    {
        OnStartMove_Action?.Invoke();
    }

    private void OnEndMove(ItemClothes item)
    {
        OnEndMove_Action?.Invoke(item);
    }

    public event Action<ClothesDrag> OnGrabClothesItem_Action;

    public event Action<Vector2> OnMove_Action;

    public event Action OnStartMove_Action;

    public event Action<ItemClothes> OnEndMove_Action;

    #endregion
}
