using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Transform target;

    public float enemyBulletSpeed = 70f;
    public GameObject enemyBulletImpactEffect;

    public int damage = 20;

    public void EnemySeek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = enemyBulletSpeed * Time.deltaTime;

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

        GameObject effectIns = (GameObject)Instantiate(enemyBulletImpactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 1f);

        //Destroy(target.gameObject);
        Damage(target);
        Destroy(gameObject);
    }

    void Damage(Transform ally)
    {
        Ally a = ally.GetComponent<Ally>();

        a.TakeDamage(damage);
        //Debug.Log("Ally Hit!");
    }
}
