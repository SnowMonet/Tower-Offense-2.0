using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : MonoBehaviour
{
    private Transform target;

    public float iceBulletSpeed = 70f;
    public GameObject iceBulletImpactEffect;

    public int damage = 20;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = iceBulletSpeed * Time.deltaTime;

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
        
        GameObject effectIns = (GameObject)Instantiate(iceBulletImpactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 1f);

        //Destroy(target.gameObject);
        Damage(target);
        Destroy(gameObject);
    }

    void Damage (Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e.tag == "EnemyWater")
        {
            e.TakeDamage(damage * 2);
            Debug.Log("CRIT!");
        }
        else if (e.tag == "EnemyWind" || e.tag == "EnemyEarth")
        {
            e.TakeDamage(damage);
            Debug.Log("Hit!");
        }
    }
}
