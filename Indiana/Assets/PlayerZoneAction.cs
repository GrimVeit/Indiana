using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZoneAction : MonoBehaviour
{
    public void ZoneAttack(float radius)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D hit in hits)
        {
            if(hit.TryGetComponent(out IZoneAction zoneAction))
            {
                zoneAction.DoAction();
            }
        }
    }
}
