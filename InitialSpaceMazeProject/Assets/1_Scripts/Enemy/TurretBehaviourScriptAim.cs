using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviourScriptAim : TurretBehaviourScript
{
 //var dec
    private Vector3 vecToPlayer;

 //var def
    new private void Start()
    {
        base.Start();      

    }

 //funct def
    private void FaceTarget(Vector3 direction)
    {
        GetComponent<Transform>().rotation = Quaternion.LookRotation(Vector3.Cross(direction, Vector3.up), direction);

    }

 //unity calls
    private void Update()
    {
        if (active == true)
        {
            vecToPlayer = Vector3.Normalize(TfPlayer.position - turretPos);
            FaceTarget(vecToPlayer);
        }
        Fire();


    }


}
