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
    	var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
         transform.position += move * speed * Time.deltaTime;
    }
}
