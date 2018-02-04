using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReStartLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.JoystickButton6))
        {
            Time.timeScale = 1f;
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
