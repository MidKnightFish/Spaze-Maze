/*
 *      ###ADD LIFE AMOUNT GUI PROC### 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    //var dec
    [SerializeField] private GameObject DeathScreen, WinScreen;
    [SerializeField] private GameObject[] hpBars, keyBars;
    [SerializeField] private RectTransform SpeedResourceRect;
    private Vector2 SpeedRect;

    //var init
    protected void Start()
    {
        SpeedRect = SpeedResourceRect.anchoredPosition;


    }


    //funct def
    private void Death(int lifes)   //lifes after decrement
    {
        //###                                 LIFE AMOUNT GUI                                  ###
        if (lifes <= 0)
        {
            DeathScreen.SetActive(true);
            Time.timeScale = 0f;

        }

    }

    private void Victory()
    {
        WinScreen.SetActive(true);


    }

    private void HpBarSwitcher(int hp)  //hp before dmg is applied
    {
        int index = hp;
        hpBars[index - 1].SetActive(false);

        if (hp >= 2)
        {
            hpBars[index - 2].SetActive(true);

        }


    }

    private void HpRefresh(int hp)
    {
        if (hp >= 1)
        {
            hpBars[hp - 1].SetActive(false);

        }
        hpBars[3].SetActive(true);


    }

    private void BoostBarSwitcher(float resc)
    {
        SpeedResourceRect.anchoredPosition = new Vector2(SpeedRect.x - 850f*(1-resc), SpeedRect.y);


    }
        
    private void BoostBarRefresh()
    {
        SpeedResourceRect.anchoredPosition = SpeedRect;


    }

    private void KeyBarSwitcher(int keyCount)//count after increment
    {
        /*
        if (keyCount >= 1)
        {
            if (keyCount >= 2)
            {
                keyBars[keyCount - 2].SetActive(false);

            }
            keyBars[keyCount - 1].SetActive(true);

        }
        else
            foreach (GameObject key in keyBars) key.SetActive(false);
        */
        for (int i = 0; i < keyBars.Length; i++)
        {
            if (i < keyCount)
                keyBars[i].SetActive(true);
            else
                keyBars[i].SetActive(false);
        }

    }



    //unity calls
    private void OnEnable()
    {
        PlayerBehaviourScript.OnPlayerDeath += Death;
        PlayerBehaviourScript.OnPlayerVictory += Victory;
        PlayerBehaviourScript.OnPlayerDmg += HpBarSwitcher;
        PlayerBehaviourScript.SpeedbarDecrease += BoostBarSwitcher;
        PlayerBehaviourScript.OnSpeedboostBarRefresh += BoostBarRefresh;
        PlayerBehaviourScript.OnHpBarRefresh += HpRefresh;
        PlayerBehaviourScript.OnGetKey += KeyBarSwitcher;


    }

    private void OnDisable()
    {
        PlayerBehaviourScript.OnPlayerDeath -= Death;
        PlayerBehaviourScript.OnPlayerVictory -= Victory;
        PlayerBehaviourScript.OnPlayerDmg -= HpBarSwitcher;
        PlayerBehaviourScript.SpeedbarDecrease -= BoostBarSwitcher;
        PlayerBehaviourScript.OnSpeedboostBarRefresh -= BoostBarRefresh;
        PlayerBehaviourScript.OnHpBarRefresh -= HpRefresh;
        PlayerBehaviourScript.OnGetKey -= KeyBarSwitcher;


    }


}
