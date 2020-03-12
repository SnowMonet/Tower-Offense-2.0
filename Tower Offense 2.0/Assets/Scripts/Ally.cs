using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
{
    public float allySpeed;
    public int allyHealth = 80;

    private Transform target;
    private int wavepointIndex = 0;
    public string allyPath;

    // Start is called before the first frame update
    void Start()
    {
        if (allyPath == "Center")
        {
            target = CenterAllyWaypoints.centerAllyWaypoints[0];
        }

        else if (allyPath == "Right")
        {
            target = RightAllyWaypoints.rightAllyWaypoints[0];
        }

        else if (allyPath == "Left")
        {
            target = LeftAllyWaypoints.leftAllyWaypoints[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * allySpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (allyPath == "Center")
        {
            if (wavepointIndex >= CenterAllyWaypoints.centerAllyWaypoints.Length - 1)
            {
                Destroy(gameObject);
                return;
            }

            wavepointIndex++;
            target = CenterAllyWaypoints.centerAllyWaypoints[wavepointIndex];
        }

        else if (allyPath == "Right")
        {
            if (wavepointIndex >= RightAllyWaypoints.rightAllyWaypoints.Length - 1)
            {
                Destroy(gameObject);
                return;
            }

            wavepointIndex++;
            target = RightAllyWaypoints.rightAllyWaypoints[wavepointIndex];
        }

        else if (allyPath == "Left")
        {
            if (wavepointIndex >= LeftAllyWaypoints.leftAllyWaypoints.Length - 1)
            {
                Destroy(gameObject);
                return;
            }

            wavepointIndex++;
            target = LeftAllyWaypoints.leftAllyWaypoints[wavepointIndex];
        }
    }
}
