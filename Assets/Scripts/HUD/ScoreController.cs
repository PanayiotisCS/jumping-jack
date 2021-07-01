using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    public TMP_Text score;
    private int game_scene_score;
    // Start is called before the first frame update
    void Start()
    {
        game_scene_score = PlayerPrefs.GetInt("player_score");
        score.text = $"Score {game_scene_score}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
