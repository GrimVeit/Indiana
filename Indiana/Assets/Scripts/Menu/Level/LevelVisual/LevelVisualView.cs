using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelVisualView : View
{
    [SerializeField] private List<LevelVisual> levelVisuals = new List<LevelVisual>();

    public void Initialize()
    {
        levelVisuals.ForEach(data =>
        {
            data.OnChooseLevel += HandleChooseLevel;
            data.Initialize();
        });
    }

    public void Dispose()
    {
        levelVisuals.ForEach(data =>
        {
            data.OnChooseLevel += HandleChooseLevel;
            data.Dispose();
        });
    }

    public void Open(int id)
    {
        var visual = GetLevelVisualById(id);

        if(visual == null)
        {
            Debug.LogError("Not found level visual with id - " + id);
            return;
        }

        visual.Open();
    }

    public void Close(int id)
    {
        var visual = GetLevelVisualById(id);

        if (visual == null)
        {
            Debug.LogError("Not found level visual with id - " + id);
            return;
        }

        visual.Close();
    }

    private LevelVisual GetLevelVisualById(int id)
    {
        return levelVisuals.FirstOrDefault(x => x.Id == id);
    }

    #region Output

    public event Action<int> OnChooseLevel;

    private void HandleChooseLevel(int id)
    {
        OnChooseLevel?.Invoke(id);
    }

    #endregion
}
