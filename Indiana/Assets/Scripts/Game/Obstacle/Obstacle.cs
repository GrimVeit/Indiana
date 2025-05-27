using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public virtual void Activate() { }
    public virtual void Deactivate() { }


    public Action<int> OnSendObstacle;
}
