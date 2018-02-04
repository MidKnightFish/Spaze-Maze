using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour
{

    //public var delay = 2.0;
    [SerializeField] private float bulletLifetime = 4f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagSystemClass.playerTag) || collision.gameObject.CompareTag(TagSystemClass.wallTag) || collision.gameObject.CompareTag(TagSystemClass.dynWallTag))
        {
            Destroy(gameObject);

        }

    }

    void Update()
    {
            Destroy(gameObject, bulletLifetime);


    }     
       

}
