using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public ZoneType ZoneType => zoneType;

    [SerializeField] private ZoneType zoneType;
    [SerializeField] private ZoneTrigger trigger;

    private void Awake()
    {
        trigger.OnTriggerEnter += Enter;
    }

    private void OnDestroy()
    {
        trigger.OnTriggerEnter -= Enter;
    }
    
    private void Enter()
    {
        OnSendZone?.Invoke(zoneType);
    }

    #region Output

    public event Action<ZoneType> OnSendZone;

    #endregion
}
