using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderView : View
{
    [SerializeField] private BoxCollider2D boxCollider;

    [SerializeField] private Vector2 sizeNormal;
    [SerializeField] private Vector2 sizeDie;

    public void ActivateNormal()
    {
        boxCollider.size = sizeNormal;
    }

    public void ActivateDie()
    {
        boxCollider.size = sizeDie;
    }
}
