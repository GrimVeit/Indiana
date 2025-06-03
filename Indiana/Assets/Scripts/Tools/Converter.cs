using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Converter
{
    public static Vector3 ToUnityVector3(this System.Numerics.Vector3 vector)
    {
        return new Vector3(vector.X, vector.Y, vector.Z);
    }

    public static System.Numerics.Vector3 ToSystemVector3(this Vector3 vector)
    {
        return new System.Numerics.Vector3(vector.x, vector.y, vector.z);
    }



    private static readonly System.Random rng = new System.Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;

        while(n > 0)
        {
            n--;
            int k = rng.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }
}
