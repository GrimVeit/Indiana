using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponGameVisualView : View
{
    [SerializeField] private List<WeaponGameVisual> weaponVisuals = new();

    public void SetData(int id, int count)
    {
        var visual = GetWeaponVisual(id);

        if (visual == null)
        {
            Debug.LogError("Not found weapon visual with id - " + id);
            return;
        }

        visual.AddWeapon(count);
    }

    private WeaponGameVisual GetWeaponVisual(int id)
    {
        return weaponVisuals.FirstOrDefault(data => data.Id == id);
    }
}
