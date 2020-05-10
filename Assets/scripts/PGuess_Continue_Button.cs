using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PGuess_Continue_Button : MonoBehaviour
{

    public void pressContinue()
    {
    	GameTracker.pGuess = true;
    	GameTracker.pKnown = false;
    	//Debug.Log(pKnown);

        SceneManager.LoadScene("P(guess)");
    }
}
