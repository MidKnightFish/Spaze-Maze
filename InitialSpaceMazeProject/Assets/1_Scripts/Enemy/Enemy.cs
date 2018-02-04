using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float CurveSpeed = 5;
    public float MoveSpeed = 1;
    private float goBack;
    public float goBackWhen;
    public float goForthWhen;

    float fTime = 0;
    Vector3 vLastPos = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        vLastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        vLastPos = transform.position;

        fTime += Time.deltaTime * CurveSpeed;

        Vector3 vSin = new Vector3(Mathf.Sin(fTime), -Mathf.Sin(fTime), 0);


        goBack += 1.0F * Time.deltaTime;

        if (goBack >= goBackWhen)
        {

            Vector3 vLin = new Vector3(-MoveSpeed, 0, 0);
            transform.position += (vSin + vLin) * Time.deltaTime;
            Debug.DrawLine(vLastPos, transform.position, Color.red, 100);

            if (goBack >= goBackWhen + goForthWhen)
            {

                goBack = 0;

            }


        }
        else
        {
            Vector3 vLin = new Vector3(MoveSpeed, 0, 0);
            transform.position += (vSin + vLin) * Time.deltaTime;
            Debug.DrawLine(vLastPos, transform.position, Color.red, 100);

        }
    }
}