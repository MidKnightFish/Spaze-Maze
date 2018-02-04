using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToMainMenue : MonoBehaviour {

    // Use this for initialization
    public void LoadMainMenue()
    {
        
        Debug.Log("Loading options....");
        SceneManager.LoadScene("PressAbuttonToStartGameScene");

    }
}
