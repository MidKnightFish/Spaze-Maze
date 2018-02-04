using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	public Vector3 startPosition;
    public float movementRadius;
 void Start () 
 {
     startPosition = transform.position;
 }
 
 void Update()
 {
      transform.position = startPosition + new Vector3(Mathf.Sin(Time.time) * movementRadius, 0.0f, 0.0f);
 }	
}
