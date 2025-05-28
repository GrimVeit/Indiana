using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private ZoneTrigger trigger;

    public void Initialize()
    {
        trigger.OnTriggerEnter += Enter;
    }

    public void Dispose()
    {
        trigger.OnTriggerEnter -= Enter;
    }

    private void Enter()
    {
        OnSendDeadZone?.Invoke();
    }

    #region Input

    public event Action OnSendDeadZone;

    #endregion
}
