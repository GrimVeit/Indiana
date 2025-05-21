using System;
using UnityEngine;

public class ClothesDragModel
{
    public event Action OnUngrabCurrentClothesItem;
    public event Action<ClothesDrag> OnGrabClothesItem;
    //public event Action<ChipData, ICell, Vector2> OnSpawnChip;

    public event Action OnStartMove;
    public event Action<Vector2> OnMove;
    public event Action OnEndMove;
    public event Action OnTeleporting;

    private bool isActive = true;

    private ISoundProvider _soundProvider;

    public ClothesDragModel(ISoundProvider soundProvider)
    {
        _soundProvider = soundProvider;
    }

    public void GrabPseudoChip(ClothesDrag pseudoChip)
    {
        OnUngrabCurrentClothesItem?.Invoke();

        OnGrabClothesItem?.Invoke(pseudoChip);
    }

    public void StartMove()
    {
        if (!isActive) return;

        OnStartMove?.Invoke();
    }

    public void Move(Vector2 vector)
    {
        if (!isActive) return;

        OnMove?.Invoke(vector);
    }

    public void EndMove(ItemClothes itemClothes)
    {
        OnEndMove?.Invoke();
    }

    public void Teleport()
    {
        OnTeleporting?.Invoke();
    }

    public void Activate()
    {
        isActive = true;
    }


    public void Deactivate()
    {
        isActive = false;
    }
}
