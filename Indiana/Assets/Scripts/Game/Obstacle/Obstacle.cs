using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public virtual void Activate() { }
    public virtual void Deactivate() { }
    public virtual void Pause() { }
    public virtual void Resume() { }


    public Action<int> OnSendObstacle;
    public Action<Obstacle> OnSendZoneAction;
}
