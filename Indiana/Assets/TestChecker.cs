using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChecker : MonoBehaviour
{
    public bool isGrounded;
    [SerializeField] private Transform player;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerMask;

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(player.transform.position, radius, layerMask);
    }
}
