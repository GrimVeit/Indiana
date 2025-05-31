using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderModel
{
    public event Action OnActivateNormal;
    public event Action OnActivateDie;

    public void ActivateNormal()
    {
        OnActivateNormal?.Invoke();
    }

    public void ActivateDie()
    {
        OnActivateDie?.Invoke();
    }
}
