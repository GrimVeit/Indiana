using System;

public class CollectionVisualModel
{
    public event Action<int, int> OnChangeCountItem;

    private IItemCollectionEventsProvider _itemCollectionEvents;  

    public CollectionVisualModel(IItemCollectionEventsProvider itemCollectionEvents)
    {
        _itemCollectionEvents = itemCollectionEvents;
        _itemCollectionEvents.OnChangeCountItem += ChangeItemCollectionCount;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _itemCollectionEvents.OnChangeCountItem -= ChangeItemCollectionCount;
    }

    private void ChangeItemCollectionCount(ItemCollection item, int count)
    {
        OnChangeCountItem?.Invoke(item.Id, count);
    }
}
