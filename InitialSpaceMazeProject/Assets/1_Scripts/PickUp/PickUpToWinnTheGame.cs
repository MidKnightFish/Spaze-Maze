using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpToWinnTheGame : MonoBehaviour
{
    public GameObject win;
    //public static bool PlayerWon = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            win.SetActive(true);
           // PlayerWon = true;
        }
    }
}