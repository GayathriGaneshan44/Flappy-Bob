using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public logicScript logic;
    public bool birdIsAlive = true;
    public AudioClip flap;
    public AudioClip gameOverSound;

    private float topBoundary;
    private float bottomBoundary;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();

        // Define screen boundaries
        Camera mainCamera = Camera.main;
        topBoundary = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        bottomBoundary = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            
           
        }

        // Check if bird moves out of screen boundaries
        if (transform.position.y > topBoundary || transform.position.y < bottomBoundary)
        {
            gameOver();
           
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameOver();
        
    }

    private void gameOver()
    {
        logic.gameOver();
        birdIsAlive = false;

      
    }
}
