using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PressAButtonToShoot : MonoBehaviour {

    //Drag in the Bullet Emitter from the Component Inspector.
    //public GameObject BulletSpawn;

    //Drag in the Bullet Prefab from the Component Inspector.
    //public GameObject Bullet;

    //Enter the Speed of the Bullet from the Component Inspector.
   // public float BulletForwardForce;

    public float nextFire = 0.0f;

    public float fireRate;

    public Rigidbody projectile;
    public float speed = 20;

    

    // Use this for initialization
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.JoystickButton1) && Time.time > nextFire)
            {
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection( new Vector3(0, -speed, 0));
           
            nextFire = Time.time + fireRate;   
        }

        
        /* if (Input.GetKey(KeyCode.JoystickButton1) && Time.time > nextFire)
         {
             //The Bullet instantiation happens here.
             GameObject TemporaryBulletHandler;
             TemporaryBulletHandler = Instantiate(Bullet, BulletSpawn.transform.position, BulletSpawn.transform.rotation) as GameObject;

             //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
             //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
             TemporaryBulletHandler.transform.Rotate(Vector3.left * 90);

             //Retrieve the Rigidbody component from the instantiated Bullet and control it.
             Rigidbody TemporaryRigidBody;
             TemporaryRigidBody = TemporaryBulletHandler.GetComponent<Rigidbody>();

             //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
             TemporaryRigidBody.AddForce(transform.forward * BulletForwardForce);

             //Destroyes Bullet after´the amound of seconds you want
             Destroy(TemporaryBulletHandler, 3.0f);


         }
         */
    }
}
