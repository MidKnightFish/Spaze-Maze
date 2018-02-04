/*
 *          has to be on turret top part          
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviourScriptPattern : TurretBehaviourScript
{
 //var dec
    [SerializeField] bool[] pattern;
    int i = 0;
 //var def
    new private void Start()
    {
        base.Start();
        
    }

 //funct def
    private void PatternFire()
    {
        if(active)
        {
                if(nextFire <= Time.time)
                {
                    if (pattern[i])
                    {
                        var clone = Instantiate(projectile, bulletSpawn.position, GetComponent<Transform>().rotation);
                        clone.velocity = Vector3.Normalize(bulletSpawn.position - turretPos) * bulletSpeed * Time.deltaTime * 100;

                        Destroy(clone.gameObject, bulletLifetime);


                    }
                    i = (i+1 >= pattern.Length) ? 0 : i+1;
                    nextFire = Time.time + fireRate;

                }

        }

    }

 //unity calls
    private void Update()
    {
        PatternFire();
        

    }



   


}
