using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int leftScore = 0;

    public int rightScore = 0;

    public int lastSideScored = 0;
    // -1 left side scored last, 1 right side scored last, no one scored last
    // Start is called before the first frame update
    void Start()
    {
        ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScore()
    {
        leftScore = 0;
        rightScore = 0;
        lastSideScored = 0;
    }

    public void AddLeftPoint()
    {
        Debug.Log("Left Paddle Scored");
        leftScore++;
        lastSideScored = -1;
        if (leftScore == 11)
        {
            Debug.Log("Game Over! Left Paddle Wins!");
        }
    }

    public void AddRightPoint()
    {
        Debug.Log("Right Paddle Scored");
        rightScore++;
        lastSideScored = 1;
        if (rightScore == 11)
        {
            Debug.Log("Game Over! Right Side Wins!");
        }
    }
}
