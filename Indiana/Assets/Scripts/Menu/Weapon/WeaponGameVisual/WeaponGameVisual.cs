using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponGameVisual : MonoBehaviour
{
    public int Id => id;

    [SerializeField] private int id;
    [SerializeField] private TextMeshProUGUI textCount;
    [SerializeField] private Button buttonWeapon;

    public void AddWeapon(int count)
    {
        if (count == 0)
        {
            buttonWeapon.enabled = false;
        }
        else
        {
            buttonWeapon.enabled = true;
        }

        textCount.text = count.ToString();
    }
}
