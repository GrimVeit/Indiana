using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollectionVisualView : View
{
    [SerializeField] private List<CollectionVisual> collectionVisuals = new List<CollectionVisual>();

    public void SetData(int id, int count)
    {
        var visual = GetCollectionVisual(id);

        if(visual == null)
        {
            Debug.LogError("Not found collection visual with id - " + id);
            return;
        }

        visual.AddItem(count);
    }

    private CollectionVisual GetCollectionVisual(int id)
    {
        return collectionVisuals.FirstOrDefault(data => data.Id == id);
    }
}
