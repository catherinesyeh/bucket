using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderValueToText : MonoBehaviour
{
    public Slider sliderUI;
    private Text textSliderValue;

    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;

    public static float y = -4f;
    public static float z = 0;

    void Start()
    {
        textSliderValue = GetComponent<Text>();
        sliderUI.value = 2;
    }

    public void OnSliderValueChanged(float num)
    {
        string sliderMessage = "Number of Targets = " + num.ToString() + ", P(guess) = 1/" + num.ToString();
        textSliderValue.text = sliderMessage;

        updateTargets(num);
    }

    public void updateTargets(float num)
    {

        if (num == 1)
        { // 1 target
            target1.SetActive(true);
            target1.transform.position = new Vector3(0, y, z);
            target2.SetActive(false);
            target3.SetActive(false);
            target4.SetActive(false);
        }
        else if (num == 2)
        { // 2 targets
            target1.SetActive(true);
            target1.transform.position = new Vector3(-4.3f, y, z);
            target2.SetActive(true);
            target2.transform.position = new Vector3(4.3f, y, z);
            target3.SetActive(false);
            target4.SetActive(false);
        }
        else if (num == 3)
        { // 3 targets
            target1.SetActive(true);
            target1.transform.position = new Vector3(-5.5f, y, z);
            target2.SetActive(true);
            target2.transform.position = new Vector3(0, y, z);
            target3.SetActive(true);
            target3.transform.position = new Vector3(5.5f, y, z);
            target4.SetActive(false);
        }
        else
        { // 4 targets
            target1.SetActive(true);
            target1.transform.position = new Vector3(-5.5f, y, z);
            target2.SetActive(true);
            target2.transform.position = new Vector3(-1.9f, y, z);
            target3.SetActive(true);
            target3.transform.position = new Vector3(1.9f, y, z);
            target4.SetActive(true);
            target4.transform.position = new Vector3(5.5f, y, z);
        }
    }
}