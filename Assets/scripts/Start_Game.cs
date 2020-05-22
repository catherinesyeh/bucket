using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


// Starts the explainable
public class Start_Game : MonoBehaviour
{
    public Text instructs; // Instructions text
    public Button startBut; // Start button
    public Slider slider; // Slider for number of targets
    public Text slidertext; // Text attached to the aforementioned slider

    public void StartGame()
    {
        // Disable all these GameObjects when explainable is first started up
        instructs.gameObject.SetActive(false);
        startBut.gameObject.SetActive(false);
        slider.gameObject.SetActive(false);
        slidertext.gameObject.SetActive(false);
    }
}
