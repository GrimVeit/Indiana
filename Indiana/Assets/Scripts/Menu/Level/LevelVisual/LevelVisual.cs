using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelVisual : MonoBehaviour
{
    public int Id => id;

    [SerializeField] private int id;
    [SerializeField] private Button buttonLevel;
    [SerializeField] private Image imageLevel;
    [SerializeField] private Sprite spriteOpen;
    [SerializeField] private Sprite spriteClose;

    public void Open()
    {
        buttonLevel.enabled = true;
        imageLevel.sprite = spriteOpen;
    }

    public void Close()
    {
        buttonLevel.enabled = false;
        imageLevel.sprite = spriteClose;
    }
}
