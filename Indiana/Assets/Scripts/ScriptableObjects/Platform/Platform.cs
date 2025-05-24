using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Platform", menuName = "Game/Platform/New")]
public class Platform : ScriptableObject
{
    public int Id => id;
    public float Width => width;

    [SerializeField] private int id;
    [SerializeField] private float width;
}
