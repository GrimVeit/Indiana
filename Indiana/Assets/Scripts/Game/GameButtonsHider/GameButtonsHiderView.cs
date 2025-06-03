using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonsHiderView : View
{
    [SerializeField]
    private List<GameObject> buttons = new();

    public void Show()
    {
        buttons.ForEach(data => data.SetActive(true));
    }

    public void Hide()
    {
        buttons.ForEach(data => data.SetActive(false));
    }
}
