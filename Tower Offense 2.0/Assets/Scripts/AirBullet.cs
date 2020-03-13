using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBullet : MonoBehaviour
{
    private Transform target;

    public float airBulletSpeed = 70f;
    public GameObject airBulletImpactEffect;

    public int damage = 20;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = airBulletSpeed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        //Debug.Log("Target Hit");

        GameObject effectIns = (GameObject)Instantiate(airBulletImpactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 1f);

        //Destroy(target.gameObject);
        Damage(target);
        Destroy(gameObject);
    }

    void Damage (Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e.tag == "EnemyWind")
        {
            e.TakeDamage(damage * 2);
            //Debug.Log("CRIT!");
        }
        else if (e.tag == "EnemyWater" || e.tag == "EnemyEarth")
        {
            e.TakeDamage(damage);
            //Debug.Log("Hit!");
        }
    }
}
