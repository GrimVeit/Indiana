using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectionVisual : MonoBehaviour
{
    public int Id => id;

    [SerializeField] private int id;
    [SerializeField] private Image imageItem;
    [SerializeField] private Color colorZero;
    [SerializeField] private Color colorItem;
    [SerializeField] private TextMeshProUGUI textCount;

    public void AddItem(int count)
    {
        if (count == 0)
        {
            imageItem.color = colorZero;
        }
        else
        {
            imageItem.color = colorItem;
        }

        textCount.text = count.ToString();
    }
}
