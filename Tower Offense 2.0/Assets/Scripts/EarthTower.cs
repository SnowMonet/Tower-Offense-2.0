using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthTower : MonoBehaviour
{
    public Transform target;

    public GameObject playerBase;

    [Header("Tower Stats")]

    public float earthTowerHealth = 8f;

    public float earthTowerRange;
    public float earthTowerFireRate = 1f;
    public float earthTowerFireCountdown = 0f;

    public float rotateSpeed = 10f;

    public GameObject rockBulletPrefab;
    public GameObject rockBulletSpawn;

    string[] enemyTags = { "EnemyWater", "EnemyWind", "EnemyEarth" };

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        foreach (string tag in enemyTags)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            if (nearestEnemy != null && shortestDistance <= earthTowerRange)
            {
                target = nearestEnemy.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        earthTowerHealth -= Time.deltaTime;

        if(earthTowerHealth <= 0f)
        {
            Destroy(gameObject);
        }

        earthTowerFireCountdown -= Time.deltaTime;

        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (earthTowerFireCountdown <= 0f)
        {
            Shoot();
            earthTowerFireCountdown = 1f / earthTowerFireRate;
        }
    }

    void Shoot()
    {
        //Debug.Log("FIRING!");

        GameObject rockBulletGO = (GameObject)Instantiate(rockBulletPrefab, rockBulletSpawn.transform.position, rockBulletSpawn.transform.rotation);
        RockBullet rockBullet = rockBulletGO.GetComponent<RockBullet>();

        if (rockBullet != null)
        {
            rockBullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, earthTowerRange);
    }
}
