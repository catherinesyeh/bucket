using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderValueToText : MonoBehaviour
{
    public Slider sliderUI;
    private Text textSliderValue;
    public float total;

    void Start()
    {
        textSliderValue = GetComponent<Text>();
        total = sliderUI.maxValue;
    }

    public void OnSliderValueChanged(float num)
    {
        string sliderMessage = "Number of Targets = " + num.ToString() + ", P(guess) = " + num.ToString() + "/" + total.ToString();
        textSliderValue.text = sliderMessage;
        Debug.Log("Value changed.");
    }
}