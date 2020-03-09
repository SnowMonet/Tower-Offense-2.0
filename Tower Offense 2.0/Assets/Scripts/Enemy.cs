using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    private Transform target;
    private int wavepointIndex = 0;
    public string pickPath;

    
    void Start()
    {
        string[] paths = new string[] { "Center", "Right", "Left" };

        System.Random randomPath = new System.Random();
        int usePath = randomPath.Next(paths.Length);
        pickPath = paths[usePath];

        if (pickPath == "Center")
        {
            target = CenterWaypoints.centerWaypoints[0];
        }

        else if (pickPath == "Right")
        {
            target = RightWaypoints.rightWaypoints[0];
        }

        else if (pickPath == "Left")
        {
            target = LeftWaypoints.leftWaypoints[0];
        }
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (pickPath == "Center")
        {
            if (wavepointIndex >= CenterWaypoints.centerWaypoints.Length - 1)
            {
                Destroy(gameObject);
                return;
            }

            wavepointIndex++;
            target = CenterWaypoints.centerWaypoints[wavepointIndex];
        }

        else if (pickPath == "Right")
        {
            if (wavepointIndex >= RightWaypoints.rightWaypoints.Length - 1)
            {
                Destroy(gameObject);
                return;
            }

            wavepointIndex++;
            target = RightWaypoints.rightWaypoints[wavepointIndex];
        }

        else if (pickPath == "Left")
        {
            if (wavepointIndex >= LeftWaypoints.leftWaypoints.Length - 1)
            {
                Destroy(gameObject);
                return;
            }

            wavepointIndex++;
            target = LeftWaypoints.leftWaypoints[wavepointIndex];
        }
    }
}
