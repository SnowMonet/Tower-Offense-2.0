using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    public int health = 80;

    private Transform target;
    private int wavepointIndex = 0;
    public string enemyPath;
    
    void Start()
    {
        /*string[] paths = new string[] { "Center", "Right", "Left" };

        System.Random randomPath = new System.Random();
        int usePath = randomPath.Next(paths.Length);
        pickPath = paths[usePath];*/

        if (enemyPath == "Center")
        {
            target = CenterWaypoints.centerWaypoints[0];
        }

        else if (enemyPath == "Right")
        {
            target = RightWaypoints.rightWaypoints[0];
        }

        else if (enemyPath == "Left")
        {
            target = LeftWaypoints.leftWaypoints[0];
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Kill();
        }
    }

    void Kill()
    {
        Destroy(gameObject);
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
        if (enemyPath == "Center")
        {
            if (wavepointIndex >= CenterWaypoints.centerWaypoints.Length - 1)
            {
                PlayerHealth.playerHealthValue--;
                Destroy(gameObject);
                return;
            }

            wavepointIndex++;
            target = CenterWaypoints.centerWaypoints[wavepointIndex];
        }

        else if (enemyPath == "Right")
        {
            if (wavepointIndex >= RightWaypoints.rightWaypoints.Length - 1)
            {
                PlayerHealth.playerHealthValue--;
                Destroy(gameObject);
                return;
            }

            wavepointIndex++;
            target = RightWaypoints.rightWaypoints[wavepointIndex];
        }

        else if (enemyPath == "Left")
        {
            if (wavepointIndex >= LeftWaypoints.leftWaypoints.Length - 1)
            {
                PlayerHealth.playerHealthValue--;
                Destroy(gameObject);
                return;
            }

            wavepointIndex++;
            target = LeftWaypoints.leftWaypoints[wavepointIndex];
        }
    }
}
