using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimationView : View
{
    [SerializeField] private SpriteRenderer imagePlayer;

    public void SetSprite(Sprite sprite)
    {
        imagePlayer.sprite = sprite;
    }
}
