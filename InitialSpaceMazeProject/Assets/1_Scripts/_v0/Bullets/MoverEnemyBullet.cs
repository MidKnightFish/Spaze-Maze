using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEnemyBullet : MonoBehaviour


	{

    //public var delay = 2.0;
    public float timer;


    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerBullet" || collision.gameObject.tag == "Wall")
        {

            //gameOverPanel.SetActive(true);
            //gameObject.SetActive(false);
            Destroy(gameObject);

        }
    }
    void Update()
    {

        timer += 1.0F * Time.deltaTime;

        if (timer >= 10)
        {
            GameObject.Destroy(gameObject);
        }

    }



}