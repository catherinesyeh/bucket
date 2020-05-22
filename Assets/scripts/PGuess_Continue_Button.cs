using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Continue button to progress from the p(Known) scene to the p(Guess) scene
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
