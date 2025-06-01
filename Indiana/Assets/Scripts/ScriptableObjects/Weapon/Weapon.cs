using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Game/Weapon/New")]
public class Weapon : ScriptableObject
{
    public int Id => id;
    public string NameItem => nameItem;
    public Sprite SpriteItem => spriteItem;
    public ItemWeaponData Data => data;

    [SerializeField] private int id;
    [SerializeField] private string nameItem;
    [SerializeField] private Sprite spriteItem;
    private ItemWeaponData data;

    public void SetData(ItemWeaponData data)
    {
        this.data = data;
    }
}
