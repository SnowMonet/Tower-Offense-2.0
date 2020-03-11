using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTower : MonoBehaviour
{
    public Transform target;

    public GameObject playerBase;

    [Header("Tower Stats")]

    public float windTowerHealth = 8f;

    public float windTowerRange;
    public float windTowerFireRate = 1f;
    public float windTowerFireCountdown = 0f;

    public float rotateSpeed = 10f;

    public GameObject airBulletPrefab;
    public GameObject airBulletSpawn;

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

            if (nearestEnemy != null && shortestDistance <= windTowerRange)
            {
                target = nearestEnemy.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        windTowerHealth -= Time.deltaTime;

        if(windTowerHealth <= 0f)
        {
            Destroy(gameObject);
        }

        windTowerFireCountdown -= Time.deltaTime;

        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (windTowerFireCountdown <= 0f)
        {
            Shoot();
            windTowerFireCountdown = 1f / windTowerFireRate;
        }
    }

    void Shoot()
    {
        //Debug.Log("FIRING!");

        GameObject airBulletGO = (GameObject)Instantiate(airBulletPrefab, airBulletSpawn.transform.position, airBulletSpawn.transform.rotation);
        AirBullet airBullet = airBulletGO.GetComponent<AirBullet>();

        if (airBullet != null)
        {
            airBullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, windTowerRange);
    }
}
