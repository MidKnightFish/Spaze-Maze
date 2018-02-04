using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviourScript : EnemyBase
{
    //var dec
    [SerializeField] protected float movementRadius, fireRate = 1f, bulletSpeed = 2f, bulletLifetime = 4f;
    [SerializeField] protected bool horizontal = true, shooting = true;
    [SerializeField] protected Rigidbody projectile;
    [Range(-5f, 5f)] [SerializeField] protected float SlowDown = 2.5f;

    protected Vector3 startPos;
    protected float nextFire;

    //var init
    new protected void Start ()
    {
        base.Start();

        startPos = transform.position;
        nextFire = Time.time;

    }


 //funct def
    protected void Move(bool hori)
    {
        if (hori == true)
        {
            transform.position = startPos + new Vector3(Mathf.Sin(Time.time / SlowDown) * -movementRadius, 0f, 0f);

        }
        else
        {
            transform.position = startPos + new Vector3( 0f, 0f, Mathf.Sin(Time.time / SlowDown) * -movementRadius);


        }

    }

    protected void Fire()
    {
        if (active && nextFire < Time.time)
        {
            var clone = Instantiate(projectile, transform.position, GetComponent<Transform>().rotation);
            clone.velocity = (TfPlayer.position - transform.position) * bulletSpeed * Time.deltaTime * 100;
            Destroy(clone.gameObject, bulletLifetime);
            nextFire = Time.time + fireRate;

        }

    }

    //unity calls
    void Update ()
    {
        Move(horizontal);
        if (shooting == true)
        {
            Fire();
        }

	}
    
}
