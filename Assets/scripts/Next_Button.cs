using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// Class to help control the intro scene
public class Next_Button : MonoBehaviour
{
	int slide = 0; // Tracks which message the user should be shown

    public Button back;
    public Button next;

    void Start()
    {   
        updateText();
    }

    public void pressNext() // Next button was pressed, advances user by one slide
    {
        Debug.Log("Next button pressed");
        slide++;
        updateText();
    }

    public void pressBack() // Back button was pressed, regresses user by one slide
    {
        Debug.Log("Back button pressed");
        slide--;
        updateText();
    }

    public void backToMenu() // Brings the user back to the menu
    {
        Debug.Log("Back to menu");
        slide = 3;
        SceneManager.LoadScene("Intro");
        updateText();
    }

    public void updateText() // Controls what text the user is shown depending on what 'slide' they're on
    { 
        if (slide == 0)
        {
            GameObject.Find("Message").GetComponent<Text>().text =
            "Hi! I’m Bucket! Today we’re going to be learning about BKT, or Bayesian Knowledge Tracing!";

            back.gameObject.SetActive(false);
            next.GetComponentInChildren<Text>().text = "Next";
        }
        else if (slide == 1)
        {
            GameObject.Find("Message").GetComponent<Text>().text =
                "WHY IS BKT IMPORTANT?\nBKT is an artificial intelligence algorithm that lets us predict what people know. " +
                "It is particularly useful in educational settings to help teachers and students measure skill ~mastery~, " +
                "aka. \"did you actually learn the stuff I wanted you to learn?\"";

            back.gameObject.SetActive(true);
            next.GetComponentInChildren<Text>().text = "Next";
        }
        else if (slide == 2)
        {
            GameObject.Find("Message").GetComponent<Text>().text =
                "Once we’re pretty sure, so like 95-100% sure, that someone knows a thing, we can say they’ve mastered it. " +
                "As sureness is a probability, you can guess that BKT is just a bunch of probabilities, but stuffed into an algebraic formula.";

            back.gameObject.SetActive(true);
            next.GetComponentInChildren<Text>().text = "Next";
        }
        else if (slide == 3)
        {
            GameObject.Find("Message").GetComponent<Text>().text =
                "BKT is built on four probabilities. Click on the buttons below to learn more about them.";
            
            back.gameObject.SetActive(true);
            next.GetComponentInChildren<Text>().text = "P(guess) & P(known)";
        }
        else
        { // go to next scene
            SceneManager.LoadScene("P(known)");
        }
    }
}
