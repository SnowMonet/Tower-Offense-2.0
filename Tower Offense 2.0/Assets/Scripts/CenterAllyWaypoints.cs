using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterAllyWaypoints : MonoBehaviour
{
    public static Transform[] centerAllyWaypoints;

    void Awake()
    {
        centerAllyWaypoints = new Transform[transform.childCount];
        for (int i = 0; i < centerAllyWaypoints.Length; i++)
        {
            centerAllyWaypoints[i] = transform.GetChild(i);
        }
    }
}
