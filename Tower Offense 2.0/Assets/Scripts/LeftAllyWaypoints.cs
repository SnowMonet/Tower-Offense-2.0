using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAllyWaypoints : MonoBehaviour
{
    public static Transform[] leftAllyWaypoints;

    void Awake()
    {
        leftAllyWaypoints = new Transform[transform.childCount];
        for (int i = 0; i < leftAllyWaypoints.Length; i++)
        {
            leftAllyWaypoints[i] = transform.GetChild(i);
        }
    }
}
