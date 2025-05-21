using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndianaPreviewInput : MonoBehaviour, IIndianaPreviewInput
{
    public event Action<ItemClothes> OnSetItemClothes;

    public void SetData(ItemClothes item)
    {
        OnSetItemClothes?.Invoke(item);
    }
}

public interface IIndianaPreviewInput
{
    void SetData(ItemClothes item);
}
