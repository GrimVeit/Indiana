using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponGroup", menuName = "Game/Weapon/Group")]
public class WeaponGroup : ScriptableObject
{
    public List<Weapon> weapons = new();

    public Weapon GetWeaponById(int id)
    {
        return weapons.FirstOrDefault(data => data.Id == id);
    }
}
