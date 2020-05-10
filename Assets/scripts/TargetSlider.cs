using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TargetSlider : MonoBehaviour
{
    public static int numTargets;

    public Slider targetSlider;

    // Update is called once per frame
    public void Update() 
    {
    	numTargets = (int) targetSlider.value;
    	// Debug.Log("this many targets now: " + numTargets);
    }
}
