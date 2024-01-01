using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody2D playerRB;
    private float flapSpeed = 7.0f;
    private bool isSpacePressed = false;

    private float frameXThreshold = -10f;
    private float frameYThreshold = -5.7f;

    // Start is called before the first frame update
    void Start()
    {
        FindAnyObjectByType<AudioManager>().stopAudio("MenuAudio");
        FindAnyObjectByType<AudioManager>().playAudio("GameAudio");
    }

    // Update is called once per frame
    void Update()
    {
        // Check Whether Player is out of bounds
        if(gameObject.transform.position.x < frameXThreshold || gameObject.transform.position.y < frameYThreshold)
        {
            FindObjectOfType<GameManager>().gameOver();
            FindAnyObjectByType<AudioManager>().stopAudio("GameAudio");
            FindAnyObjectByType<AudioManager>().playAudio("GameOverAudio");
            Destroy(gameObject);
        }

        // Get Input Key, Tried doing in Fixed Update, but was not registering the space input everytime, looked online and people faced similar issue and suggested get input in update method only
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            isSpacePressed = true;
        }
    }

    private void FixedUpdate()
    {
        if(isSpacePressed == true) 
        {
            resetVelocity();
            Vector2 flapVector = new Vector2(0, flapSpeed);
            playerRB.AddForce(flapVector, ForceMode2D.Impulse);
            isSpacePressed=false;
        }
    }

    private void resetVelocity()
    {
        playerRB.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("PipeObstacle") == true)
        {
            FindObjectOfType<GameManager>().gameOver();
            FindAnyObjectByType<AudioManager>().stopAudio("GameAudio");
            FindAnyObjectByType<AudioManager>().playAudio("GameOverAudio");
            // Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }
}
