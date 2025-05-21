using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Game/Collection/Group")]
public class ItemCollectionGroup : ScriptableObject
{
    public List<ItemCollection> itemCollections = new();

    public ItemCollection GetItemCollectionById(int id)
    {
        return itemCollections.FirstOrDefault(data => data.Id == id);
    }
}
