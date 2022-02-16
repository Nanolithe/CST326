using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public AudioClip paddleSound, wallSound, scoreZoneSound;
    public AudioSource audioSource;
   // public AudioSource paddleSource, wallSource, scoreSource;
    //public AudioClip paddleSound;
    public float horizontalSpeed = 0f;
    public float verticalSpeed = 0f;

    public float verticalDirection = 1f;
    public float horizontalDirection = 1f;

    public float speedAddition = 1.5f;
    public ScoreManager scoreManager;

    public Material ballMaterial;
    public Color defaultColor = Color.green;
    public Color upColor = Color.blue;
    public Color downColor = Color.red;
    private void Awake()
    {
        ResetBall();
    }

    private void FixedUpdate()
    {
        transform.position += (new Vector3(horizontalSpeed * horizontalDirection, verticalSpeed * verticalDirection, 0)* Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Paddle"))
        {
            // increases speed and paddle magic
            //Debug.Log("Hit at " + collision.transform.position.y + "center at" + paddleBox.bounds.center.y);
            horizontalSpeed += speedAddition;
            verticalSpeed += speedAddition;
            
            horizontalDirection *= -1f;
            if (transform.position.y >= collision.transform.position.y)
            {
                // goes up
                verticalDirection = 1f;
                ballMaterial.color = upColor;
            }
            else
            {
                // goes down
                verticalDirection = -1f;
                ballMaterial.color = downColor;
            }
            
            audioSource.clip = paddleSound; 
        }
        else if (collision.collider.CompareTag("Wall"))
        {
            // Collision Magic
            verticalDirection *= -1;

            audioSource.clip = wallSound;
        }
        else if (collision.collider.CompareTag("ScoreZone"))
        {
            // reset ball and add score to which team scored
            if (transform.position.x > 0)
            {
                //Left Point
                scoreManager.AddLeftPoint();
            }
            else
            {
                //Right Point
                scoreManager.AddRightPoint();
            }

            ResetBall();

            audioSource.clip = scoreZoneSound;
        }

        audioSource.Play();
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;
        horizontalSpeed = 7f;
        if (scoreManager.lastSideScored == 0)
        {
            float randomNumber = Random.Range(0f, 100f);
            horizontalDirection = (randomNumber > 50 ? 1f : -1f);
        }
        else
        {
            horizontalDirection = scoreManager.lastSideScored;
        }
        verticalSpeed = 0;
        // Clears Current Trails
        GetComponent<TrailRenderer>().Clear();
        ballMaterial.color = defaultColor;
    }
    
}
