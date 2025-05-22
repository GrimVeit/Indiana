using System;
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

    public void Initialize()
    {
        buttonLevel.onClick.AddListener(() => OnChooseLevel?.Invoke(id));
    }

    public void Dispose()
    {
        buttonLevel.onClick.RemoveListener(() => OnChooseLevel?.Invoke(id));
    }

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

    #region Output

    public event Action<int> OnChooseLevel;

    #endregion
}
