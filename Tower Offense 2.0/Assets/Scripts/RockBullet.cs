using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBullet : MonoBehaviour
{
    private Transform target;

    public float rockBulletSpeed = 70f;
    public GameObject rockBulletImpactEffect;

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
        float distanceThisFrame = rockBulletSpeed * Time.deltaTime;

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

        GameObject effectIns = (GameObject)Instantiate(rockBulletImpactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 1f);

        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
