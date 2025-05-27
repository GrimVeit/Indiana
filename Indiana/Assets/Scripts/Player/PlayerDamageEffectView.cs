using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerDamageEffectView : View
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color originalColor;
    [SerializeField] private Color damageColor;
    [SerializeField] private float durationEffect;

    public void PlayEffect()
    {
        spriteRenderer.color = damageColor;
        spriteRenderer.DOColor(originalColor, durationEffect);
    }
}
