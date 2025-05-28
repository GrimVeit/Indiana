using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneModel
{
    private readonly IHealthRemoveProvider _healthRemoveProvider;

    public DeadZoneModel(IHealthRemoveProvider healthRemoveProvider)
    {
        _healthRemoveProvider = healthRemoveProvider;
    }

    public void SendDeadZone()
    {
        _healthRemoveProvider.RemoveHealth(int.MaxValue);
    }
}
