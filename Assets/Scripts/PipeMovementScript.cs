using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovementScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -35;
    public float speedIncrement = 3; // Speed increase after every 10 pipes
    public static int pipeCount = 0; // Static counter to track pipes
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if(transform.position.x < deadZone)
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
             pipeCount++;
            if (pipeCount % 10 == 0)
            {
                moveSpeed += speedIncrement;
                Debug.Log("Speed Increased! Current Speed: " + moveSpeed);
            }
        }
    }
}
