using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Start_Game : MonoBehaviour
{
    public Text instructs;
    public Button startBut;
    public Slider slider;
    public Text slidertext;

    public void StartGame()
    {
        instructs.gameObject.SetActive(false);
        startBut.gameObject.SetActive(false);
        slider.gameObject.SetActive(false);
        slidertext.gameObject.SetActive(false);
    }
}
