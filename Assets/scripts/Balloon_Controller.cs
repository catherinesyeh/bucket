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

    public int correctTarget = 1;

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
            Debug.Log("Congratulations! You landed on the right target!");
            message.text = "Congratulations! You landed on the right target!";
        } else {
            Debug.Log("Oops! Better luck next time.");
            message.text = "Oops! Better luck next time.";
        }

        but.gameObject.SetActive(true);
        contBut.gameObject.SetActive(true);
    }
}
