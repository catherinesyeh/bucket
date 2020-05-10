using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public static int numTargets = 2;
    public static int correctTarget = 1;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        started = false; 

        minX = transform.position.x;
        maxX = -minX;

        minY = transform.position.y;
        maxY = -minY;

        message.text = "";
        but.gameObject.SetActive(false);
        contBut.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!started && !startBut.gameObject.activeInHierarchy)
        { // start moving after instructions appear
            moving = true;
            started = true;

            Debug.Log("P(guess)?: " + GameTracker.pGuess);
            Debug.Log("First time?: " + GameTracker.firstTime);

            if (GameTracker.firstTime || GameTracker.pGuess)
            {
                if (GameTracker.pGuess)
                {
                    numTargets = (int)slider.value;
                }
                Debug.Log("Num targets: " + numTargets);
                pickCorrectTarget(numTargets);
            }
        }

        if (moving) {
	    	var xPos = transform.position.x;
	        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, maxX - minX) + minX, transform.position.y, transform.position.z);

	    	var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0); // copied code from https://answers.unity.com/questions/667641/how-do-i-move-my-2d-object-using-arrow-keys-also-h.html
	        transform.position += move * speed * Time.deltaTime;
	    }
    }

    // pick target to be correct one
    void pickCorrectTarget(int numTargets)
    {
        if (numTargets > 1)
        { // pick random target if more than 1
            correctTarget = Random.Range(1, numTargets + 1);
        } else
        {
            correctTarget = 1;
        }
        Debug.Log("Correct target: " + correctTarget.ToString());
    }

    // Detects collision with the targets
    void OnTriggerEnter2D(Collider2D other) { // used tutorial https://www.youtube.com/watch?v=ZoZcBgRR9ns
    	moving = false;

        // Debug.Log("Correct target: " + correctTarget.ToString());

        if (other.name[7] == correctTarget.ToString()[0]) {
            if (GameTracker.pKnown) {
                if (GameTracker.firstTime)
                {
                    message.text = "Congratulations! You landed on the right target!\n\nWow, that's impressive because there was no way you" + 
                                   " could’ve known which was the right target, so your P(Known) in this instance was probably pretty close to 0." + 
                                   " You did, however, have a 50% chance of getting it right, as there are two targets. So P(Guess) in this instance" + 
                                   " was 0.5.";

                    GameTracker.firstTime = false;
                  //  Debug.Log(GameTracker.firstTime);
                }
                else
                {
                    message.text = "Congratulations! You landed on the right target!\n\nNow you know which target is the correct one, so your" +
                                   " P(known) is 1.";
                }
            } else if (GameTracker.pGuess) {
                Debug.Log("alohhaa");
                message.text = "Congratulations! You landed on the right target!";
            }
        } else {
            if (GameTracker.pKnown) {
                if (GameTracker.firstTime)
                {
                    message.text = "Oops! Better luck next time.\n\nIt’s alright, there was no way you could’ve known which was the right target," +
                   " so your P(Known) in this instance was probably pretty close to 0. You did, however, have a 50% chance of getting it right," +
                   " as there are two targets. So P(Guess) in this instance was 0.5.";

                    GameTracker.firstTime = false;
                  //  Debug.Log(GameTracker.firstTime);
                }
                else
                {
                    message.text = "Oops! Better luck next time.\n\nEven though you know which target is the correct one, and your P(known) is 1," +
                                   " sometimes we still make mistakes.";
                }
            } else if (GameTracker.pGuess) {
                Debug.Log("Oopsie doodles");
                message.text = "Oops! Better luck next time.";
            }
        }

        but.gameObject.SetActive(true);
        contBut.gameObject.SetActive(true);
    }
}
