using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClothesDesign", menuName = "Game/Clothes/Design")]
public class ClothesDesign : ScriptableObject
{
    public int IdDesign => idDesign;
    public int IdHat => idHat;
    public int IdJeans => idJeans;

    [SerializeField] private int idDesign;
    [SerializeField] private int idHat;
    [SerializeField] private int idJeans;
}
