using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightAllyWaypoints : MonoBehaviour
{
    public static Transform[] rightAllyWaypoints;

    void Awake()
    {
        rightAllyWaypoints = new Transform[transform.childCount];
        for (int i = 0; i < rightAllyWaypoints.Length; i++)
        {
            rightAllyWaypoints[i] = transform.GetChild(i);
        }
    }
}
