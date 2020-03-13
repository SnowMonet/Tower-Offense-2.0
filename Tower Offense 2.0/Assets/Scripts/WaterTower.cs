using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterTower : MonoBehaviour
{
    public Transform target;

    public GameObject playerBase;

    [Header("Tower Stats")]

    public float waterTowerStartHealth = 8f;
    public float waterTowerHealthValue;

    public float waterTowerRange;
    public float waterTowerFireRate = 1f;
    public float waterTowerFireCountdown = 0f;

    public int waterTowerCost;

    public float rotateSpeed = 10f;

    public GameObject iceBulletPrefab;
    public GameObject iceBulletSpawn;

    [Header("Unity Stuff")]
    public Image healthBar;

    string[] enemyTags = { "EnemyWater", "EnemyWind", "EnemyEarth" };

    // Start is called before the first frame update
    void Start()
    {
        waterTowerHealthValue = waterTowerStartHealth;

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
                if(distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            if(nearestEnemy != null && shortestDistance <= waterTowerRange)
            {
                target = nearestEnemy.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        waterTowerHealthValue -= Time.deltaTime;

        healthBar.fillAmount = waterTowerHealthValue / waterTowerStartHealth;

        if (waterTowerHealthValue <= 0f)
        {
            Destroy(gameObject);
        }

        waterTowerFireCountdown -= Time.deltaTime;

        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(waterTowerFireCountdown <= 0f)
        {
            Shoot();
            waterTowerFireCountdown = 1f / waterTowerFireRate;
        }
    }

    void Shoot()
    {
        //Debug.Log("FIRING!");

        GameObject iceBulletGO = (GameObject)Instantiate(iceBulletPrefab, iceBulletSpawn.transform.position, iceBulletSpawn.transform.rotation);
        IceBullet iceBullet = iceBulletGO.GetComponent<IceBullet>();

        if(iceBullet != null)
        {
            iceBullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, waterTowerRange);
    }
}
