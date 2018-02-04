using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementLeftRight : MonoBehaviour {

    public Vector3 startPosition;
    public float movementRadius;
    [Range(-5f, 5f)]
    public float SlowDown = 2; // JD PFUSCH, damit nicht durch Null geteilt wird, nur weil kein Wert zugewiesen wurde
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position = startPosition + new Vector3(Mathf.Sin(Time.time / SlowDown) * -movementRadius, 0.0f, 0.0f);
    }
}
