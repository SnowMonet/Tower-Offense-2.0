using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBullet : MonoBehaviour
{
    private Transform target;

    public float airBulletSpeed = 70f;
    public GameObject airBulletImpactEffect;

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

        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
