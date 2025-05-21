using System;
using System.IO;
using UnityEngine;

public class StoreClothesModel
{
    public event Action<int> OnChooseDesign;

    private readonly ClothesDesignGroup clothesDesignGroup;

    private ClothesData clothesData;
    private int currentDesign;

    public readonly string FilePath = Path.Combine(Application.persistentDataPath, "Clothes.json");

    public StoreClothesModel(ClothesDesignGroup clothesDesignGroup)
    {
        this.clothesDesignGroup = clothesDesignGroup;

        if (File.Exists(FilePath))
        {
            string loadedJson = File.ReadAllText(FilePath);
            clothesData = JsonUtility.FromJson<ClothesData>(loadedJson);

            Debug.Log("Load data");
        }
        else
        {
            Debug.Log("New Data");
            clothesData = new ClothesData(0, 0);
        }

        currentDesign = clothesDesignGroup.GetDesignByData(clothesData.idHat, clothesData.idJeans);
    }

    public void Initialize()
    {
        OnChooseDesign?.Invoke(currentDesign);
    }

    public void ChooseClothes(int typeClothes, int id)
    {
        switch (typeClothes)
        {
            case 0:
                clothesData.idHat = id;
                break;
            case 1:
                clothesData.idJeans = id;
                break;
        }

        currentDesign = clothesDesignGroup.GetDesignByData(clothesData.idHat, clothesData.idJeans);
        OnChooseDesign?.Invoke(currentDesign);
    }

    public void Dispose()
    {
        string json = JsonUtility.ToJson(clothesData);
        File.WriteAllText(FilePath, json);
    }
}

public class ClothesData
{
    public int idHat;
    public int idJeans;
    public ClothesData(int idHat, int idJeans)
    {
        this.idHat = idHat;
        this.idJeans = idJeans;

    }
}
