using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZoneActionView : View
{
    [SerializeField] private PlayerZoneAction playerZoneAction;

    [SerializeField] private float smallRadius;
    [SerializeField] private float middleRadius;
    [SerializeField] private float bigRadius;

    public void ActivateSmallZone()
    {
        playerZoneAction.ZoneAttack(smallRadius);
    }

    public void ActivateMiddleZone()
    {
        playerZoneAction.ZoneAttack(middleRadius);
    }

    public void ActivateBigZone()
    {
        playerZoneAction.ZoneAttack(bigRadius);
    }
}
