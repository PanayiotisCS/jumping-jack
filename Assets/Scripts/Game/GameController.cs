using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    ScoreCounter scoreCounter;
    ObstSpawning objectSpawning;
    CactusMovement obstacle;
    PlayerMovement player;
    int once_counter;

    // Start is called before the first frame update
    void Start()
    {
        scoreCounter = GetComponent<ScoreCounter>();
        objectSpawning = GetComponent<ObstSpawning>();
        obstacle = FindObjectOfType<CactusMovement>();
        once_counter = 0;

    }

    // Update is called once per frame
    void Update()
    {
        CheckScore();
    }
    
    void CheckScore()
    {
        if(scoreCounter.score >= 500.0f && scoreCounter.score < 1000.0f && once_counter == 0)
        {
            IncreaseSpeed(1.1f);
            once_counter++;
            objectSpawning.SetTime(2f);
        }

        if(scoreCounter.score >= 1000.0f && scoreCounter.score < 1500.0f && once_counter == 1)
        {
            IncreaseSpeed(1.2f);
            once_counter++;
            objectSpawning.SetTime(1.8f);
        }

        if (scoreCounter.score >= 1500.0f && scoreCounter.score < 2000.0f && once_counter == 2)
        {
            IncreaseSpeed(1.5f);
            once_counter++;
            objectSpawning.SetTime(1.5f);
        }

        if (scoreCounter.score >= 2000.0f && once_counter == 3)
        {
            IncreaseSpeed(1.7f);
            once_counter++;
            objectSpawning.SetTime(1f);
        }
    }

    void IncreaseSpeed(float increaseValue)
    {
        obstacle.speed *= increaseValue;
    }
}
