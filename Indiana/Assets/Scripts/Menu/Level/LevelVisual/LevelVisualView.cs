using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelVisualView : View
{
    [SerializeField] private List<LevelVisual> levelVisuals = new List<LevelVisual>();

    public void Open(int id)
    {
        var visual = GetLevelVisualBYId(id);

        if(visual == null)
        {
            Debug.LogError("Not found level visual with id - " + id);
            return;
        }

        visual.Open();
    }

    public void Close(int id)
    {
        var visual = GetLevelVisualBYId(id);

        if (visual == null)
        {
            Debug.LogError("Not found level visual with id - " + id);
            return;
        }

        visual.Close();
    }

    private LevelVisual GetLevelVisualBYId(int id)
    {
        return levelVisuals.FirstOrDefault(x => x.Id == id);
    }
}
