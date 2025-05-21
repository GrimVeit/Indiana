using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ClothesDesignGroup", menuName = "Game/Clothes/DesignGroup")]
public class ClothesDesignGroup : ScriptableObject
{
    [SerializeField] private List<ClothesDesign> clothesDesigns = new();
    public int GetDesignByData(int idHat, int idJeans)
    {
        return clothesDesigns.FirstOrDefault(data => data.IdHat == idHat && data.IdJeans == idJeans).IdDesign;
    }
}
