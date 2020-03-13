using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowers : MonoBehaviour
{
    public Transform target;

    public float enemyTowerRange;
    public float enemyTowerFireRate;
    public float enemyTowerFireCountdown;

    public GameObject enemyBulletPrefab;
    public GameObject enemyBulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void UpdateTarget()
    {
        GameObject[] allies = GameObject.FindGameObjectsWithTag("Ally");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestAlly = null;

        foreach(GameObject ally in allies)
        {
            float distanceToAlly = Vector3.Distance(transform.position, ally.transform.position);
            if(distanceToAlly < shortestDistance)
            {
                shortestDistance = distanceToAlly;
                nearestAlly = ally;
            }
        }

        if(nearestAlly != null && shortestDistance <= enemyTowerRange)
        {
            target = nearestAlly.transform;
        }
    }

    void Update()
    {
        enemyTowerFireCountdown -= Time.deltaTime;

        if(target == null)
        {
            return;
        }

        if(enemyTowerFireCountdown <= 0)
        {
            Shoot();
            enemyTowerFireCountdown = 1f / enemyTowerFireRate;
        }
    }

    void Shoot()
    {
        GameObject enemyBulletGO = (GameObject)Instantiate(enemyBulletPrefab, enemyBulletSpawn.transform.position, enemyBulletSpawn.transform.rotation);
        EnemyBullet enemyBullet = enemyBulletGO.GetComponent<EnemyBullet>();

        if(enemyBullet != null)
        {
            enemyBullet.EnemySeek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyTowerRange);
    }
}
