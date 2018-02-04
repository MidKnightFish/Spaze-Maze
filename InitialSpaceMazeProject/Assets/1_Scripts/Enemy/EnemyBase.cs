using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBase : MonoBehaviour
{
    //var dec
    [SerializeField] protected float aggroRange = 14.0f;
    protected Rigidbody rb;
    protected bool active = false;
    protected Transform TfPlayer;

    //var init
    protected void Start()
    {

        TfPlayer = GameObject.FindWithTag(TagSystemClass.playerTag).transform;

    }

 //funct def
    //aggro range check, sets active to true/false based on distance
    protected void AggroCheck(Vector3 origin, Vector3 target)
    {
        RaycastHit hit;
        if (Physics.Raycast(origin, Vector3.Normalize(target - origin), out hit))
        {
            if (hit.collider.gameObject.tag == TagSystemClass.playerTag && hit.distance < aggroRange)
            {
                active = true;

            }
            else if (active && (hit.distance > aggroRange && hit.collider.gameObject.tag == TagSystemClass.playerTag) || hit.collider.gameObject.tag != TagSystemClass.playerTag)
            {
                active = false;

            }

        }

    }

    
 //unity calls
    protected void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag(TagSystemClass.playerBulletTag))
        {
            Destroy(gameObject);

        }

    }

    protected void FixedUpdate()
    {
        AggroCheck(transform.position, TfPlayer.position);

    }
}
