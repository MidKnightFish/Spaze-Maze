using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialBild : MonoBehaviour {

    public GameObject TutorialBox;
    bool isUsed = false;

   
    void Start()
    {

    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {

            
            TutorialBox.GetComponent<Image>().enabled = false;
           
        }
    }
void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "Player" && isUsed == false)
        {
            TutorialBox.GetComponent<Image>().enabled = true;
            isUsed = true;

        }
        


    }

        }
