using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    private bool death = false;
   
	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update()
    {



    }
/*
    private void SetDeathState()
    {
        death = true;

    }*/

    void Pause()
    {
        if (death == false)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
            PlayerBehaviourScript.OnPressStart -= Pause;
            PlayerBehaviourScript.OnPressStart += Resume;
        }/*
        else
        {
            SceneManager.LoadScene("Goldmaster");
            Time.timeScale = 1f;
            death = false;

        }*/             //#### USING CHECKPOINT SYSTEM, NO SCENE LOAD @ RESTART ####

    }


public void Resume()
{
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        PlayerBehaviourScript.OnPressStart -= Resume;
        PlayerBehaviourScript.OnPressStart += Pause;
}
    public void LoadCredits()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading credits....");
        SceneManager.LoadScene("Credits");

    }
    public void LoadOptions()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading options....");
        SceneManager.LoadScene("optioinsMenu");

    }
    public void LoadMenue()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading Menue....");
        SceneManager.LoadScene("PressAbuttontoStartGameScene");
    }
    public void QuitGame()
    {
        Debug.Log("QuittingGame...");
        Application.Quit();

    }
    public void LoadFirstLevel()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading 1Level....");
        SceneManager.LoadScene("Goldmaster");

    }
    
    private void OnEnable()
    {
        PlayerBehaviourScript.OnPressStart += Pause;
        //PlayerBehaviourScript.OnPlayerDeath += SetDeathState;

    }

    private void OnDisable()
    {
        PlayerBehaviourScript.OnPressStart -= Pause;
        //PlayerBehaviourScript.OnPlayerDeath -= SetDeathState;

    }

}
	

