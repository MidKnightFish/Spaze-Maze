/*
*       cooledTime = elapsed game time at which available returns true
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownClass
{
    public void AddCooldown(float cooldown)
    {
        cooledTime = cooldown + Time.time;

    }

    public void SetActive()
    {
        cooledTime = Time.time;

    }

    public bool Available()
    {
        return cooledTime < Time.time ? true : false;
        
    }

    public float Remaining()
    {
        float hold = -(Time.time - cooledTime);
        return hold <= 0 ? 0 : hold;

    }

    //standard constructor

    public CooldownClass()
    {
        cooledTime = 0.0f;

    }

    private float cooledTime = 0.0f;

}
