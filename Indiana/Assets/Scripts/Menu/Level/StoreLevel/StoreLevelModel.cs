using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class StoreLevelModel
{
    public event Action<int, bool> OnChangeStatusLevel;

    private readonly List<LevelData> levelDatas = new();

    public readonly string FilePath = Path.Combine(Application.persistentDataPath, "Levels.json");

    public StoreLevelModel()
    {
        if (File.Exists(FilePath))
        {
            string loadedJson = File.ReadAllText(FilePath);
            LevelDatas levelDatas = JsonUtility.FromJson<LevelDatas>(loadedJson);

            Debug.Log("Load data");

            this.levelDatas = levelDatas.Datas.ToList();
        }
        else
        {
            Debug.Log("New Data");

            levelDatas = new List<LevelData>();

            for (int i = 0; i < 4; i++)
            {
                if(i == 0)
                {
                    levelDatas.Add(new LevelData(true, i));
                }
                else
                {
                    levelDatas.Add(new LevelData(false, i));
                }
            }
        }
    }

    public void Initialize()
    {
        for (int i = 0; i < levelDatas.Count; i++)
        {
            OnChangeStatusLevel?.Invoke(levelDatas[i].IdLevel, levelDatas[i].IsOpen);
        }
    }

    public void Dispose()
    {
        string json = JsonUtility.ToJson(new LevelDatas(levelDatas.ToArray()));
        File.WriteAllText(FilePath, json);
    }

    public void OpenLevel(int id)
    {
        var level = GetLevelDataById(id);

        if(level == null)
        {
            Debug.LogError("Not found level with id - " + id);
            return;
        }

        level.IsOpen = true;
        OnChangeStatusLevel?.Invoke(level.IdLevel, level.IsOpen);
    }

    private LevelData GetLevelDataById(int id)
    {
        return levelDatas.FirstOrDefault(x => x.IdLevel == id);
    }
}

[Serializable]
public class LevelDatas
{
    public LevelData[] Datas;

    public LevelDatas(LevelData[] datas)
    {
        Datas = datas;
    }
}

[Serializable]
public class LevelData
{
    public int IdLevel;
    public bool IsOpen;

    public LevelData(bool isOpen, int id)
    {
        IsOpen = isOpen;
        IdLevel = id;

    }
}
