/*
 *      ###projectile  receives turret rotation###
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviourScript : EnemyBase
{
 //var declaration
    [SerializeField] protected float bulletSpeed = 2.0f, bulletLifetime = 4.0f;
    [SerializeField] protected Rigidbody projectile;
    [SerializeField] protected float fireRate = 1.0f;

    protected Transform bulletSpawn;
    protected float nextFire;
    protected Vector3 turretPos;



 //var definition
        new protected void Start()
        {
            base.Start();
            turretPos = transform.position;
            bulletSpawn = transform.Find("bulletspawn");
            if(bulletSpawn == null)
            {
                Debug.Log("ERR_SETUP_BULLETSPAWN_NULL");

            }
            nextFire = Time.time;

        }


 //funct definition
    protected void Fire()
    {
        if(active && nextFire < Time.time)
        {            
            var clone = Instantiate(projectile, bulletSpawn.position, GetComponent<Transform>().rotation);
            clone.velocity = (bulletSpawn.position - turretPos) * bulletSpeed * Time.deltaTime * 100;
            Destroy(clone.gameObject, bulletLifetime);
            nextFire = Time.time + fireRate;

        }

    }
        


 //unity calls
    private void Update()
    {
        Fire();

    }
    

}
