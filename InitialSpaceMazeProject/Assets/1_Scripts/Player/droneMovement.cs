using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneMovement : MonoBehaviour {
    public float Speed;
    public GameObject Player;
    private Vector3 aim;
    // Use this for initialization
    void Start () {
		
	}
    void FixedUpdate()
    {
        //makes the player move with wasd pfeiltasten oder steuerknüppel auf xbox contoller
         
        float moveHorizontal = Input.GetAxis("4th Axis");
        float moveVertical = Input.GetAxis("5th Axis");
        aim = new Vector3(moveVertical, 0, moveHorizontal);

        if (0 != moveHorizontal ||0 != moveVertical)
        {
            transform.RotateAround(Player.transform.position, Vector3.up, 360 * aim.magnitude);
        }

        //Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        // Player.GetComponent<Rigidbody>().velocity = movement * Speed;

    }
    // Update is called once per frame
    void Update () {
		
	}
}
