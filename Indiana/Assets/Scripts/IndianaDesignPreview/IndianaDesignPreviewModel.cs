using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndianaDesignPreviewModel
{
    public event Action<Sprite> OnChooseDesign; 

    private readonly DesignIndianaPreviewGroup _group;
    private readonly IStoreClothesEventsProvider _clothesEventsProvider;

    public IndianaDesignPreviewModel(DesignIndianaPreviewGroup group, IStoreClothesEventsProvider clothesEventsProvider)
    {
        _group = group;
        _clothesEventsProvider = clothesEventsProvider;
        _clothesEventsProvider.OnChooseDesign += ChooseDesign;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _clothesEventsProvider.OnChooseDesign -= ChooseDesign;
    }

    private void ChooseDesign(int id)
    {
        var design = _group.GetDesignById(id);

        if(design == null)
        {
            Debug.LogWarning("Not found indiana preview design with id - " + id);
            return;
        }

        OnChooseDesign?.Invoke(design.SpriteDesign);
    }
}
