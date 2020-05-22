using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This class contains some variables that we want to be able to track throughout the user going through the explainable's many scenes
public class GameTracker : MonoBehaviour
{
    public static bool firstTime = true; // Tracks whether it's the user's first time attempting the first 'game'

    public static bool pKnown = true; // Tracks whether it's the p(Known) scene

    public static bool pGuess = false; // Tracks whether it's the p(Guess) scene
}
