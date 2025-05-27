using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour, ITriggerEnterAction
{
    public event Action OnTriggerEnter;

    public void Enter()
    {
        OnTriggerEnter?.Invoke();
    }
}
