using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Game/Collection/Item")]
public class ItemCollection : ScriptableObject
{
    public int Id => id;
    public string NameItem => nameItem;
    public Sprite SpriteItem => spriteItem;
    public ItemCollectionData Data => data;

    [SerializeField] private int id;
    [SerializeField] private string nameItem;
    [SerializeField] private Sprite spriteItem;
    private ItemCollectionData data;

    public void SetData(ItemCollectionData data)
    {
        this.data = data;
    }
}
