using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBotShoot : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
    public Transform playerEstimatedPosition;
    public Transform bulletSpawn, bulletTarget;
    private Vector3 direction, faceDirection;
    public float nextFire = 0.0f;
    public float fireRate;
    public Rigidbody projectile;
    public float speed = 20;

    // Use this for initialization
    void Start () {
		
	}

   
    private void faceTarget()
    {

        GetComponent<Transform>().rotation = Quaternion.LookRotation(Vector3.Cross(direction, Vector3.back), direction);
        Debug.DrawRay(GetComponent<Transform>().position, direction, Color.red);
        Debug.DrawRay(GetComponent<Transform>().position, GetComponent<Transform>().up, Color.green);
        Debug.DrawRay(GetComponent<Transform>().position, Vector3.Cross(direction, Vector3.back), Color.blue);
    }
    void Update()
    {


        if (Time.time > nextFire)
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, speed, 0));
            nextFire = Time.time + fireRate;
        }

        if (bulletTarget)
            direction = (bulletTarget.position - bulletSpawn.position);
        faceTarget();
        Debug.DrawRay(GetComponent<Transform>().position, direction, Color.red);
    }
}

