using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] private ParticleSystem PlayerGetHit;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagSystemClass.enemyTag) || collision.gameObject.CompareTag(TagSystemClass.enemyBulletTag))
        {
            ParticleSystem PGetHit =Instantiate(PlayerGetHit, PlayerGetHit.transform.position, PlayerGetHit.transform.rotation) as ParticleSystem;

            PGetHit.Play();

        }

    }

}