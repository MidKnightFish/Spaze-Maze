using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float timer;

    void Update()
    {

        timer += 1.0F * Time.deltaTime;

        if (timer >= 3)
        {
            GameObject.Destroy(gameObject);
        }

    }
}
