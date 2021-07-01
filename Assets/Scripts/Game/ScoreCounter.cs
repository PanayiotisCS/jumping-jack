using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [Header("Score/HighScore")]
    public TMP_Text score_text;
    [HideInInspector]
    public float score;
    float pointIncreasedPerSecond;

    PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        score = 0;
        pointIncreasedPerSecond = 20;
    }

    // Update is called once per frame
    void Update()
    {
        score_text.text = "Score " + (int)score;
        if (player.countFlag == true)
        {
            score += pointIncreasedPerSecond * Time.deltaTime;
        }
    }
}
