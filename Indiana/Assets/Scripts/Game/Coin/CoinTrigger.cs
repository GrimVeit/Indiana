using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour, ITriggerEnterAction
{
    public event Action OnTriggerEnter;

    public void Enter()
    {
        OnTriggerEnter?.Invoke();
    }
}
