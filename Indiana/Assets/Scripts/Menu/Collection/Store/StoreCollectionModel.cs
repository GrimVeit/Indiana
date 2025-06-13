using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class StoreCollectionModel
{
    public event Action<ItemCollection, int> OnChangeCountItem;

    private readonly ItemCollectionGroup itemGroup;

    private List<ItemCollectionData> itemCollectionDatas = new List<ItemCollectionData>();

    public readonly string FilePath = Path.Combine(Application.persistentDataPath, "ItemCollections.json");

    private readonly string KEY;

    public StoreCollectionModel(ItemCollectionGroup itemCollectionGroup, string KEY)
    {
        itemGroup = itemCollectionGroup;

        this.KEY = KEY;

        if (File.Exists(FilePath))
        {
            string loadedJson = File.ReadAllText(FilePath);
            ItemCollectionDatas itemCollectionDatas = JsonUtility.FromJson<ItemCollectionDatas>(loadedJson);

            Debug.Log("Load data");

            this.itemCollectionDatas = itemCollectionDatas.Datas.ToList();
        }
        else
        {
            Debug.Log("New Data");

            itemCollectionDatas = new List<ItemCollectionData>();

            for (int i = 0; i < itemCollectionGroup.itemCollections.Count; i++)
            {
                itemCollectionDatas.Add(new ItemCollectionData(0));
            }
        }

        for (int i = 0; i < itemCollectionGroup.itemCollections.Count; i++)
        {
            itemCollectionGroup.itemCollections[i].SetData(itemCollectionDatas[i]);
        }
    }

    public void Initialize()
    {
        for (int i = 0; i < itemGroup.itemCollections.Count; i++)
        {
            OnChangeCountItem?.Invoke(itemGroup.itemCollections[i], itemGroup.itemCollections[i].Data.Count);
        }
    }

    public void Dispose()
    {
        string json = JsonUtility.ToJson(new ItemCollectionDatas(itemCollectionDatas.ToArray()));
        File.WriteAllText(FilePath, json);

        PlayerPrefs.SetInt(KEY, CurrentCountCollection());
    }

    public void AddItemCollection(int id)
    {
        var itemCollection = itemGroup.GetItemCollectionById(id);

        if (itemCollection == null)
        {
            Debug.LogError($"Not found item collection by id - {id}");
            return;
        }

        itemCollection.Data.AddItem(1);
        OnChangeCountItem?.Invoke(itemCollection, itemCollection.Data.Count);
    }

    private int CurrentCountCollection()
    {
        int count = 0;

        for (int i = 0; i < itemCollectionDatas.Count; i++)
        {
            count += itemCollectionDatas[i].Count;
        }

        return count;
    }
}

[Serializable]
public class ItemCollectionDatas
{
    public ItemCollectionData[] Datas;

    public ItemCollectionDatas(ItemCollectionData[] datas)
    {
        Datas = datas;
    }
}

[Serializable]
public class ItemCollectionData
{
    public int Count;

    public ItemCollectionData(int count)
    {
        Count = count;
    }

    public void AddItem(int count)
    {
        Count += count;
    }
}
