using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public AudioSource soundtrack;
    // Start is called before the first frame update
    void Start()
    {
        soundtrack.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
