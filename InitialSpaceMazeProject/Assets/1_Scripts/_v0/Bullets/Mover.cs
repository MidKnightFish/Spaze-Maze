using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    //public var delay = 2.0;
    public float timer;


    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet" || collision.gameObject.tag == "Wall" || collision.gameObject.tag == "dynWall")
        {

            //gameOverPanel.SetActive(true);
            //gameObject.SetActive(false);
            Destroy(gameObject);

        }
    }
    void Update() {

        timer += 1.0F * Time.deltaTime;

        if (timer >= 4)
        {
            GameObject.Destroy(gameObject);
        }

    }
        
       

    }
   

   // function WaitAndDestroy()
    //{
      //  yield WaitForSeconds(delay);
        //Destroy(gameObject);
    //}
