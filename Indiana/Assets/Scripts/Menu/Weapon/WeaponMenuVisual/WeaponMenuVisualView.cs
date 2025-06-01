using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponMenuVisualView : View
{
    [SerializeField] private List<WeaponMenuVisual> weaponVisuals = new List<WeaponMenuVisual>();

    public void SetData(int id, int count)
    {
        var visual = GetWeaponVisual(id);

        if (visual == null)
        {
            Debug.LogError("Not found wePON visual with id - " + id);
            return;
        }

        visual.AddWeapon(count);
    }

    private WeaponMenuVisual GetWeaponVisual(int id)
    {
        return weaponVisuals.FirstOrDefault(data => data.Id == id);
    }
}
