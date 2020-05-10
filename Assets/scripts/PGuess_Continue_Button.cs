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
        GameTracker.firstTime = true;

        SceneManager.LoadScene("P(guess)");
    }
}
