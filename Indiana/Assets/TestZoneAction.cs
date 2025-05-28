using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestZoneAction : MonoBehaviour, IZoneAction
{
    public void DoAction()
    {
        Debug.Log("FIRE");
    }
}
