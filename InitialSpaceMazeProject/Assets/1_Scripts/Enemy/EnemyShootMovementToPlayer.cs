using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootMovementToPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public Transform playerEstimatedPosition;
    public Transform bulletSpawn, bulletTarget;
    private Vector3 direction, faceDirection;

    // Use this for initialization
    void Start()
    {
        //transform.LookAt(player.position);
       // offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    private void faceTarget()
    {

        GetComponent<Transform>().rotation = Quaternion.LookRotation(Vector3.Cross(direction, Vector3.back), direction);
        Debug.DrawRay(GetComponent<Transform>().position, direction, Color.red);
        Debug.DrawRay(GetComponent<Transform>().position, GetComponent<Transform>().up, Color.green);
        Debug.DrawRay(GetComponent<Transform>().position, Vector3.Cross(direction, Vector3.back), Color.blue);
    }

    void Update()
    {
        if (!bulletTarget) return; // JD PFUSCH

        direction = (bulletTarget.position - bulletSpawn.position);
        faceTarget();
        Debug.DrawRay(GetComponent<Transform>().position, direction, Color.red);
    }
}
