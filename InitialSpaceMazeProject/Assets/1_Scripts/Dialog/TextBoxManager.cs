using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;
    public Text theText;


    public TextAsset textfile;
    public string[] textLines;

    public int CurrentLine;
    public int endLine;

    public bool isActive;

   

    // Use this for initialization
    void Start()
    {

        if (textfile != null)
        {

            textLines = (textfile.text.Split('\n'));

        }
    

    if (endLine == 0)
        {
            endLine = textLines.Length - 1;
        
        }
    if(isActive)
        {
            EnableTextBox();
            
        }
    
//else
  //      {
           
    //        DisableTextBox();
           
      //  }

   }
    void Update()
    {
        if (!isActive)
        {
            return;

        }

        theText.text = textLines[CurrentLine];

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            CurrentLine += 1;

        }
        if (CurrentLine == endLine)
        {
            Debug.Log("disableingtexbox");
            DisableTextBox();
        }

    }
    public void EnableTextBox()
    {

        textBox.SetActive(true);
        isActive = true;
       
        Time.timeScale = 0f;

    }
    public void DisableTextBox()
    {
        Debug.Log("disable");
        textBox.SetActive(false);
        isActive = false;
      
        Time.timeScale = 1f;
    }
    public void RealoadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }

        //JD
        if (CurrentLine < 0 || endLine > textLines.Length)
        {
            if (CurrentLine < 0)
            {
                CurrentLine = 0;
                //Debug.Log("Wrong Text Length! Too early. Text contains: " + textLines[0]);
            }
            if (endLine > textLines.Length)
            {
                endLine = textLines.Length;
                //Debug.Log("Wrong Text Length! Too late. Text contains: " + textLines[0]);
            }
        }
        //JD
    }

}
