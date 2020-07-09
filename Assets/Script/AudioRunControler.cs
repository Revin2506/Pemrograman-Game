using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class AudioRunControler : MonoBehaviour {

    Rigidbody2D rb;
    AudioSource audioSrc;
    bool isMoving = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (rb.velocity.x != 0)
            isMoving = true;
        else
            isMoving = false;

        if (isMoving)
        {
            if (!audioSrc.isPlaying)
                audioSrc.Play();
        }
        else
            audioSrc.Stop();
    }
}
