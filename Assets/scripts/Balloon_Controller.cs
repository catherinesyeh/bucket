using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Balloon_Controller : MonoBehaviour
{
	// controlling (x,y) of bucket in the balloon
    public float minX = -4.5f; 
    public float maxX = 4.5f;
    public float minY = 1.5f;
    public float maxY = -1.5f;

    public float speed = 1f; // speed at which balloon moves across the screen

    bool moving = false; // controls whether balloon is moving, default to "not moving" at first to allow for explanation screens
    bool started = false; // controls for whether the "game" aspect of the explainable has started
    public Text message; // GameObject that contains the text the user is shown
    public Button but; // play again
    public Button startBut; // start
    public Button contBut; // continue

    public static int numTargets = 2; // default number of targets for P(Guess) is 2
    public static int correctTarget = 1; // default 'correct' target is target #1, but there's a random number generator later in the code that'll switch this up each time the explainable is loaded
    public Slider slider; // GameObject that will allow user to change the number of targets for P(Known)

    // Start is called before the first frame update
    void Start()
    {
        moving = false; // Balloon is static when explainable is loaded
        started = false; // 'Game' has not started when explainable is loaded

        // Puts Bucket in the right position when the explainable is loaded
        minX = transform.position.x; 
        maxX = -minX;

        minY = transform.position.y;
        maxY = -minY;

        message.text = ""; // Default text for when the scene loads
        but.gameObject.SetActive(false); // Play again button is disabled
        contBut.gameObject.SetActive(false); // Continue button is disabled
    }

    // Update is called once per frame
    void Update()
    {
        if (!started && !startBut.gameObject.activeInHierarchy)
        { // start moving after instructions appear
            moving = true;
            started = true;

            if (GameTracker.firstTime || GameTracker.pGuess) // The slider's value should only affect the number of targets if it's the user's first time 'playing' or if they've progressed to the p(Guess) scene
            {
                if (GameTracker.pGuess)
                {
                    numTargets = (int)slider.value; // Set the number of targets to the value of the slider
                }

                pickCorrectTarget(numTargets); // Generates a random "correct" target
            }
        }

        if (moving) { // Moves balloon across screen
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
    }

    // Detects collision with the targets
    void OnTriggerEnter2D(Collider2D other) { // used tutorial https://www.youtube.com/watch?v=ZoZcBgRR9ns
    	moving = false;

        // Debug.Log("Correct target: " + correctTarget.ToString());

    	// Changes the message shown to the user depending on what "state" they're in
        if (other.name[7] == correctTarget.ToString()[0]) {
            if (GameTracker.pKnown) {
                if (GameTracker.firstTime) 
                {
                    message.text = "Congratulations! You landed on the right target!\n\nWow, that's impressive because there was no way you" + 
                                   " could’ve known which was the right target, so your P(Known) in this instance was probably pretty close to 0." + 
                                   " You did, however, have a 50% chance of getting it right, as there are two targets. So P(Guess) in this instance" + 
                                   " was 0.5.";

                    GameTracker.firstTime = false;
                }
                else 
                {
                    message.text = "Congratulations! You landed on the right target!\n\nNow you know which target is the correct one, so your" +
                                   " P(known) is 1.";
                }
            } else if (GameTracker.pGuess) {
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
