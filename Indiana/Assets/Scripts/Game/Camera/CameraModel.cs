using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModel
{
    public event Action OnActivateLookAt;
    public event Action OnDeactivateLookAt;

    public void ActivateLookAt()
    {
        OnActivateLookAt?.Invoke();
    }

    public void DeactivateLookAt()
    {
        OnDeactivateLookAt?.Invoke();
    }
}
