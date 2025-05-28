using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : MonoBehaviour, ITriggerEnterAction
{
    public event Action OnTriggerEnter;

    public void Enter()
    {
        OnTriggerEnter?.Invoke();
    }
}
