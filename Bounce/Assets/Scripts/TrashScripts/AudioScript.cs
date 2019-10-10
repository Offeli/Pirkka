using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour
{
    private const string Path = "Sounds/Elokuvani3";
    AudioSource myAudio;

    // Start is called before the first frame update
    void Start()
    {
        myAudio.GetComponent<AudioSource>();
        myAudio.clip = Resources.Load<AudioClip>(Path);
        myAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //myAudio.GetComponent<AudioSource>();
        //myAudio.clip = Resources.Load<AudioClip>(Path);
        //myAudio.Play();
    }

    public void Play2()  
    {
        //myAudio.GetComponent<AudioSource>();
        //myAudio.clip = Resources.Load<AudioClip>(Path);
        //myAudio.Play();
    }
}
    