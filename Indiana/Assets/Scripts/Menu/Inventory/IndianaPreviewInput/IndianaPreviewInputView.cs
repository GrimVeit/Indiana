using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndianaPreviewInputView : View
{
    [SerializeField] private IndianaPreviewInput previewInput;

    public void Initialize()
    {
        previewInput.OnSetItemClothes += SetItem; 
    }

    public void Dispose()
    {
        previewInput.OnSetItemClothes -= SetItem;
    }

    #region Output

    public event Action<ItemClothes> OnSetItem;

    private void SetItem(ItemClothes item)
    {
        OnSetItem?.Invoke(item);
    }

    #endregion Output
}
