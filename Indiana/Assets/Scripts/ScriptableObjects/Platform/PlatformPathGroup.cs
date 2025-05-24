using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlatformPathGroup", menuName = "Game/Platform/Group")]
public class PlatformPathGroup : ScriptableObject
{
    [SerializeField] private List<PlatformPath> platformPaths = new List<PlatformPath>();

    public PlatformPath GetPlatformPathRandom()
    {
        return platformPaths[Random.Range(0, platformPaths.Count)];
    }
}
