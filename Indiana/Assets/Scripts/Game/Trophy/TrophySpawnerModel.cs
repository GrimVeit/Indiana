using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

public class TrophySpawnerModel
{
    public event Action<int, Vector3> OnSpawnTrophy;

    public void SpawnTrophy(TrophyChances trophyChances, Vector3 position)
    {
        var index = trophyChances.GetRandomIndexTrophy();

        if (index < 0)
        {
            UnityEngine.Debug.Log("Not found trophy with index - " + index);
            return;
        }

        OnSpawnTrophy?.Invoke(index, position);
    }
}
