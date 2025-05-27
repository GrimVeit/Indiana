using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageEffectModel
{
    public event Action OnPlayEffect;
    public void PlayEffect()
    {
        OnPlayEffect?.Invoke();
    }
}
