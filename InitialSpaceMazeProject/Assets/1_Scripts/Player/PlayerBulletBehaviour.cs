using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehaviour : MonoBehaviour {

    [SerializeField] private float bulletLifetime = 6f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagSystemClass.enemyTag) || collision.gameObject.CompareTag(TagSystemClass.wallTag) || collision.gameObject.CompareTag(TagSystemClass.dynWallTag))
        {
            Destroy(gameObject);

        }

    }

    void Update()
    {
        Destroy(gameObject, bulletLifetime);


    }

}
