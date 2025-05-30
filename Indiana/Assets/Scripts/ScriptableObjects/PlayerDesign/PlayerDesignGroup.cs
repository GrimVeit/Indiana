using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "DesignGroup", menuName = "Game/Clothes/DesignGroup")]
public class PlayerDesignGroup : ScriptableObject
{
    [SerializeField] private List<PlayerDesign> playerDesigns = new List<PlayerDesign>();

    public PlayerDesign GetPlayerDesignGroupById(int id)
    {
        return playerDesigns.FirstOrDefault(data => data.ID == id);
    }
}
