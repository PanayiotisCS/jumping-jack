using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public bool flag;
    ScoreCounter scoreCounter;

    public AudioSource jumpAudio;
    public AudioSource gameOverAudio;
    public ParticleSystem explosion;

    SpriteRenderer sprite;

    Animator animator;
    
    [HideInInspector]
    public bool countFlag; 
    //Player player_1;
    int once;

    // Start is called before the first frame update
    void Start()
    {
        countFlag = true;
        once = 0;
        flag = false;
        scoreCounter = FindObjectOfType<ScoreCounter>().GetComponent<ScoreCounter>();
        sprite = GetComponent<SpriteRenderer>();

        if(sprite == null)
        {
            Debug.LogError("Empty Sprite");
        }
        animator = GetComponent<Animator>();
        animator.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((Input.GetKey(KeyCode.Space) || Input.touchCount == 1)  && flag == false)
        {
            jumpAudio.Play();
            animator.SetTrigger("Jump");
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 21, 0);
            flag = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            animator.SetTrigger("Land");
            flag = false;
        }

        // User looses
        if (collision.gameObject.tag == "Respawn")
        {
            flag = true;
            StartCoroutine("WaitForMusic");
        }
    }

    IEnumerator WaitForMusic()
    {
        if(once == 0)
        {
            countFlag = false;
            jumpAudio.enabled = false;
            PlayParticles();
            gameOverAudio.Play();
        }
        yield return new WaitWhile(() => gameOverAudio.isPlaying);

        
        ChangeScene("Menu");
    }

    private void ChangeScene(string scene)
    {
        PlayerPrefs.SetInt("player_score", (int)scoreCounter.score);
        SceneManager.LoadScene(scene);
    }

    public void PlayParticles()
    {
        once++;
        explosion.Play();
        sprite.color = new Color(0, 0, 0, 0);
    }
}
