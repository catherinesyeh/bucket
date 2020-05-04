using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balloon_Controller : MonoBehaviour
{
    public float minX = -4.5f;
    public float maxX = 4.5f;
    public float minY = 1.5f;
    public float maxY = -1.5f;

    public float speed = 1f;

    bool moving = false;
    bool started = false;
    public Text message;
    public Button but; // play again
    public Button startBut; // start
    public Button contBut; // continue

    public static int correctTarget;

    // Start is called before the first frame update
    void Start()
    {
        minX = transform.position.x;
        maxX = -minX;

        minY = transform.position.y;
        maxY = -minY;

        message.text = "";
        but.gameObject.SetActive(false);
        contBut.gameObject.SetActive(false);
        if (GameTracker.firstTime) {
            correctTarget = Random.Range(1,3);
            Debug.Log(correctTarget.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!started && !startBut.gameObject.activeInHierarchy)
        { // start moving after instructions appear
            moving = true;
            started = true;
        }

        if (moving) {
	    	var xPos = transform.position.x;
	        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, maxX - minX) + minX, transform.position.y, transform.position.z);

	    	var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0); // copied code from https://answers.unity.com/questions/667641/how-do-i-move-my-2d-object-using-arrow-keys-also-h.html
	        transform.position += move * speed * Time.deltaTime;
	    }
    }

    // Detects collision with the targets
    void OnTriggerEnter2D(Collider2D other) { // used tutorial https://www.youtube.com/watch?v=ZoZcBgRR9ns
    	if (other.name == "Target 1") {
    		Debug.Log("Target 1: collision detected");
    	} 
    	else if (other.name == "Target 2") {
    		Debug.Log("Target 2: collision detected");
        }
    	moving = false;

        if (other.name[7] == correctTarget.ToString()[0]) {
            if (GameTracker.pGuess) {
                if (GameTracker.firstTime)
                {
                    message.text = "Congratulations! You landed on the right target!\n\nWow, that's impressive because there was no way you" + 
                                   " could’ve known which was the right target, so your P(Known) in this instance was probably pretty close to 0." + 
                                   " You did, however, have a 50% chance of getting it right, as there are two targets. So P(Guess) in this instance" + 
                                   " was 0.5.";

                    GameTracker.firstTime = false;
                    Debug.Log(GameTracker.firstTime);
                }
                else
                {
                    message.text = "Congratulations! You landed on the right target!\n\nNow you know which target is the correct one, so your" +
                                   " P(known) is 1.";
                }
            } else if (GameTracker.pKnown) {
                Debug.Log("alohhaa");
            }
        } else {
            if (GameTracker.pGuess) {
                if (GameTracker.firstTime)
                {
                    message.text = "Oops! Better luck next time.\n\nIt’s alright, there was no way you could’ve known which was the right target," +
                   " so your P(Known) in this instance was probably pretty close to 0. You did, however, have a 50% chance of getting it right," +
                   " as there are two targets. So P(Guess) in this instance was 0.5.";

                    GameTracker.firstTime = false;
                    Debug.Log(GameTracker.firstTime);
                }
                else
                {
                    message.text = "Oops! Better luck next time.\n\nEven though you know which target is the correct one, and your P(known) is 1," +
                                   " sometimes we still make mistakes.";
                }
            } else if (GameTracker.pKnown) {
                Debug.Log("Oopsie doodles");
            }
        }

        but.gameObject.SetActive(true);
        contBut.gameObject.SetActive(true);
    }
}
