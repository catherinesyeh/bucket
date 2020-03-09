using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Controller_With_Keys : MonoBehaviour
{
    public float minX = -4.5f;
    public float maxX = 4.5f;
    public float minY = 1.5f;
    public float maxY = -1.5f;

    public float speed = 1f;

    public float endY1 = -1.3f;
    public float endY2 = -1.45f;
    public float endX1 = 2.6f;
    public float endX2 = 3f;

    bool moving = true;

    public int correctTarget = 1;

    // Start is called before the first frame update
    void Start()
    {
        minX = transform.position.x;
        maxX = -minX;
        minY = transform.position.y;
        maxY = -minY;

        endY1 = -1.3f;
        endY2 = -1.45f;
        endX1 = 2.6f;
        endX2 = 3f;  
    }

    // Update is called once per frame
    void Update()
    {
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
        } else {
            Debug.Log("Oops! Better luck next time.");
        }
    }
}
