using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Group", menuName = "Game/Clothes/Preview/Group")]
public class DesignIndianaPreviewGroup : ScriptableObject
{
    [SerializeField] private List<DesignIndianaPreview> designIndianaPreviews = new List<DesignIndianaPreview>();

    public DesignIndianaPreview GetDesignById(int id)
    {
        return designIndianaPreviews.FirstOrDefault(data => data.Id == id);
    }
}
