using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FirstPage : MonoBehaviour
{
        
    public AudioSource mySound;

    public void Start()
    {

    }

    public void Update()
    {

    }

    public void X()
    {

    }

    public void Y()
    {
        AudioClip clip = (AudioClip)Resources.Load("Sounds/Elokuvani3");
        mySound.clip = clip;

        mySound.Play();
        //yield return new WaitForSeconds(mySound.clip.length);
        System.Console.WriteLine("!!!");

        if (Input.GetKeyUp(KeyCode.Space))
        {
            mySound.Play();
        }
    }


}