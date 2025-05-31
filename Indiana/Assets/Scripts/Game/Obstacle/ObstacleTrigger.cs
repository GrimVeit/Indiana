using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour, ITriggerEnterAction, IZoneAction
{
    public event Action OnTriggerEnter;
    public event Action OnZoneAction;

    public void DoAction()
    {
        OnZoneAction?.Invoke();
    }

    public void Enter()
    {
        OnTriggerEnter?.Invoke();
    }
}
