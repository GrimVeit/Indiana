using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndianaPreviewInputModel
{
    private IStoreClothesProvider _storeClothesProvider;

    public IndianaPreviewInputModel(IStoreClothesProvider storeClothesProvider)
    {
        _storeClothesProvider = storeClothesProvider;
    }

    public void ChooseClothes(ItemClothes item)
    {
        _storeClothesProvider.ChooseClothes(item.ClothesTypeId, item.Id);
    }
}
