using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlatformPath", menuName = "Game/Platform/Path")]
public class PlatformPath : ScriptableObject
{
    public List<PlatformUnit> platformsUnit = new();
}

[Serializable]
public class PlatformUnit
{
    public Platform Platform => platform;
    public PathLevel HighLevel => highLevel;

    [SerializeField] private Platform platform;
    [SerializeField] private PathLevel highLevel;
}

public enum PathLevel
{
    Low, Middle, High
}
