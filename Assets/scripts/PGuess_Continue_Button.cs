using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PGuess_Continue_Button : MonoBehaviour
{
	int slide = 0; 

	public Button continue;

    // Start is called before the first frame update
    void Start()
    {
        updateText();
    }

    public void pressContinue()
    {
        Debug.Log("Continue button pressed");
        slide++;
        updateText();
    }

    // Update is called once per frame
    public void updateText()
    {
        if (slide == 0)
        {
        	GameObject.Find("Message").GetComponent<Text>()text = 
        		"TEST";

        	continue.GetComponentInChildren<Text>().text = "Continue";
        }
        else 
        {	// go to next scene
        	SceneManager.LoadScene("P(known)");
        }
    }
}
