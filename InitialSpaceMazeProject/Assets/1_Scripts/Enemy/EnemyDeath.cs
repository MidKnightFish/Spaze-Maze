using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {

    private AudioSource sfxDeathMob;
    public GameObject explosion;

    private void Start()
    {
        sfxDeathMob = GameObject.Find("Death1_Mob").GetComponent<AudioSource>();

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagSystemClass.playerBulletTag))
        {           
            Instantiate(explosion, transform.position, Quaternion.identity);
            
            sfxDeathMob.Play();

        }

    }

}