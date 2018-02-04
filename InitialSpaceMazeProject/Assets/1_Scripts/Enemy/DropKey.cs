using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropKey : MonoBehaviour {
    public GameObject Key;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagSystemClass.playerBulletTag))
        {
            //Destroys game object and drops key on the point where it is deactive waiting in the level
            
            // VIEL JD PFUSCH
            if (Key != null)
                Key.SetActive(true);
            else
                Debug.Log("KEY is missing in DropKey Script!");
            Destroy(gameObject);
            
        }
    }
}

