using System;
using UnityEngine;

public class StorePlayerModel
{
    public event Action<PlayerDesign> OnChooseDesign;

    private readonly IStoreClothesEventsProvider _storeClothesEventsProvider;
    private readonly PlayerDesignGroup _playerDesignGroup;

    public StorePlayerModel(IStoreClothesEventsProvider storeClothesEventsProvider, PlayerDesignGroup playerDesignGroup)
    {
        _storeClothesEventsProvider = storeClothesEventsProvider;
        _playerDesignGroup = playerDesignGroup;

        _storeClothesEventsProvider.OnChooseDesign += ChooseDesign;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _storeClothesEventsProvider.OnChooseDesign -= ChooseDesign;
    }

    private void ChooseDesign(int id)
    {
        var design = _playerDesignGroup.GetPlayerDesignGroupById(id);

        if (design == null)
        {
            Debug.LogWarning("Not found indiana preview design with id - " + id);
            return;
        }

        OnChooseDesign?.Invoke(design);
    }
}
