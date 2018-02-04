using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class LocomotionRigidbody : MonoBehaviour
{
 //var dec
    [SerializeField] protected float speed = 5.5f;

    protected float multiplier = 1.0f, effectiveSpeedCap = 5.5f;
    protected Vector3 movement;
    protected Rigidbody rb;


 //var init
	protected void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        rb.useGravity = false;
        movement = Vector3.zero;
        effectiveSpeedCap = speed;

    }

 //funct def
    protected void Move()
    {
        // movement on X = Horizontal Axis
        // movement on Z = Vertical Axis  
        movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        if (movement.magnitude != 0)
        {
            rb.AddForce(movement * multiplier * Time.deltaTime * 10, ForceMode.Impulse);
            if(rb.velocity.magnitude > speed)
            {       
                    rb.velocity = Vector3.Normalize(rb.velocity) * speed;

            }

        }

    }

}
