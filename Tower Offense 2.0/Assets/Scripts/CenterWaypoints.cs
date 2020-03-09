using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterWaypoints : MonoBehaviour
{
    public static Transform[] centerWaypoints;

    void Awake()
    {
        centerWaypoints = new Transform[transform.childCount];
        for (int i = 0; i < centerWaypoints.Length; i++)
        {
            centerWaypoints[i] = transform.GetChild(i);
        }
    }
}
