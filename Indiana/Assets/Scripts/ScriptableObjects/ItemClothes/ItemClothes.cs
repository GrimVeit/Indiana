using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemClothes", menuName = "Game/Clothes/Item")]
public class ItemClothes : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private int clothesTypeId;
}
