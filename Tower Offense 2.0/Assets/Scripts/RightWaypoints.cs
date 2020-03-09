using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWaypoints : MonoBehaviour
{
    public static Transform[] rightWaypoints;

    void Awake()
    {
        rightWaypoints = new Transform[transform.childCount];
        for (int i = 0; i < rightWaypoints.Length; i++)
        {
            rightWaypoints[i] = transform.GetChild(i);
        }
    }
}
