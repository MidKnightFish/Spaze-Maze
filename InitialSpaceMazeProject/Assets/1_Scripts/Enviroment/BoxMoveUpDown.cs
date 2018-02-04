using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxMoveUpDown : MonoBehaviour
{

    //public Vector3 startPosition; //old
    public Transform endPosition;
    public Transform startPosition;
    private float startTime;
    public float speed = 1.0F;
    private float journeyLength;
    public bool constantlyMoving = false;
    public bool alreadyMoved;

    private ParticleSystem.EmissionModule[] BoxSignals;

    // Light
    float temp;
    public Light[] allLights;
    bool lightOn;

    // Signal
    bool signalOn;

    // public float movementRadius;
    void Start()
    {

        //startPosition = transform.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition.position, endPosition.position);
        alreadyMoved = false;

        allLights = GetComponentsInChildren<Light>();

        ParticleSystem[] particles = this.GetComponentsInChildren<ParticleSystem>();
        if (particles.Length > 0)
        {
            BoxSignals = new ParticleSystem.EmissionModule[particles.Length];
            for (int i = 0; i < particles.Length; i++)
            {
                BoxSignals[i] = particles[i].emission;
            }
        }
    }

    void Update()
    {
        //float distCovered = (Time.time - startTime) * speed; //old
        //float fracJourney = distCovered / journeyLength; //old

        if (alreadyMoved == false)
        {

            // moving
            //transform.position = Vector3.Lerp(startPosition.position, endPosition.position, Mathf.Sin(Time.time)); //old
            if (constantlyMoving)
            {
                temp = (1 - Mathf.Cos(speed * Time.time * Mathf.PI)) / 2f;
            }
            else
            {
                temp = (0.75f - Mathf.Cos(speed/*/journeyLength*/ * Time.time * Mathf.PI)) / 1.5f;
            }
            transform.position = Vector3.Lerp(startPosition.position, endPosition.position, temp);

            // Light
            if (allLights != null)
            {
                if (temp > -0.1f && temp < 1.1f)
                {
                    if (!lightOn)
                    {
                        foreach (Light light in allLights)
                            light.enabled = true;
                        lightOn = true;
                    }
                }
                else
                {
                    if (lightOn)
                    {
                        foreach (Light light in allLights)
                            light.enabled = false;
                        lightOn = false;
                    }
                }
            }
            // Signal
            if (BoxSignals != null)
            {
                if (temp > -0.1f && temp < 1.1f)
                {
                    if (!signalOn)
                    {
                        for (int i = 0; i < BoxSignals.Length; i++)
                        {
                            BoxSignals[i].enabled = true;
                            signalOn = true;
                        }
                    }
                }
                else
                {
                    if (signalOn)
                    {
                        for (int i = 0; i < BoxSignals.Length; i++)
                        {
                            BoxSignals[i].enabled = false;
                            signalOn = false;
                        }
                    }
                }
            }

            Debug.DrawLine(startPosition.position, endPosition.position, Color.red);

            

        }
       /*if (alreadyMoved == true)
        {
            transform.position = Vector3.Lerp(endPosition.position, startPosition.position, fracJourney);
            alreadyMoved = false;
        }
        */

        //transform.position = startPosition + new Vector3(0.0f, Mathf.Sin(Time.time) * movementRadius , 0.0f);

       
    }

 }