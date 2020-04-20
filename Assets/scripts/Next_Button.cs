using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Next_Button : MonoBehaviour
{
	int slide = 1;

    public void updateText() 
    { 
        if (slide == 1)
        {
            GameObject.Find("Message").GetComponent<Text>().text =
                "WHY IS BKT IMPORTANT?\nBKT is an artificial intelligence algorithm that lets us predict what people know. " +
                "It is particularly useful in educational settings to help teachers and students measure skill ~mastery~, " +
                "aka. \"did you actually learn the stuff I wanted you to learn?\"";
        }
        else if (slide == 2)
        {
            GameObject.Find("Message").GetComponent<Text>().text =
                "Once we’re pretty sure, so like 95-100% sure, that someone knows a thing, we can say they’ve mastered it. " +
                "As sureness is a probability, you can guess that BKT is just a bunch of probabilities, but stuffed into an algebraic formula.";
        }
        else if (slide == 3)
        {
            GameObject.Find("Message").GetComponent<Text>().text =
                "BKT is built on four probabilities. Click on the buttons below to learn more about them.";
            GameObject.Find("NextButton").GetComponentInChildren<Text>().text = "P(guess) & P(known)";
        }
        else
        { // go to next scene
            SceneManager.LoadScene("P(known)");
        }
    	slide++;
    }
}
