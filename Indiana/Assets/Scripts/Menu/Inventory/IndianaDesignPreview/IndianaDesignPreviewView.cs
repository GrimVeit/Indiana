using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndianaDesignPreviewView : View
{
    [SerializeField] private Image imageIndiana;

    public void SetData(Sprite sprite)
    {
        imageIndiana.sprite = sprite;
    }
}
