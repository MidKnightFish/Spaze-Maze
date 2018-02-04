using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AktivateTextAtLine : MonoBehaviour {

    public TextAsset theText;

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;

    public bool DestroyWhenFinished;

	// Use this for initialization
	void Start () {
        theTextBox = FindObjectOfType<TextBoxManager>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            theTextBox.RealoadScript(theText);
            theTextBox.CurrentLine = startLine;
            theTextBox.endLine = endLine;
            theTextBox.EnableTextBox();
           

            if (DestroyWhenFinished)
            {
                
                Destroy(gameObject);

            }
        }

    }
}
