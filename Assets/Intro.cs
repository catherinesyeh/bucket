using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
	int slide = 1;

    public void updateText() {
    	// if (slide == 1) {
    		GameObject.Find("Message").GetComponent<Text>().text = "WHY IS BKT IMPORTANT?\nBKT is an artificial intelligence algorithm that lets us predict what people know. It is particularly useful in educational settings to help teachers and students measure skill ~mastery~, aka “did you actually learn the stuff I wanted you to learn?” ";
    	// }
    	slide++;
    }
}
