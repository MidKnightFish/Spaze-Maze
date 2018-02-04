using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour {

    public float nextFire = 0.0f;
    public float fireRate;
    public Rigidbody projectile;
    public float speed = 20;


    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {

        if (Time.time > nextFire)
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, speed, 0));
            nextFire = Time.time + fireRate;
        }

    }
}
