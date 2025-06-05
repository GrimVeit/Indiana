using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationElementModel
{
    public event Action<string> OnActivateAnimation;

    public void Animate(string id)
    {
        OnActivateAnimation?.Invoke(id);    
    }
}
