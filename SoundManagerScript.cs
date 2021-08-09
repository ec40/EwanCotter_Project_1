//This file handled the sound that was created for the player inputs
//Essentially playing an 'oof' sound for incorrect and a 'ding' for correct
//Also plays a crowd applauding when a whole scene is completed
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip damageTakenSound, levelProgressionSound, questionRightSound;
    static AudioSource audioSrc;

    void Start()
    {
        damageTakenSound = Resources.Load<AudioClip>("oof");
        levelProgressionSound = Resources.Load<AudioClip>("victory");
        questionRightSound = Resources.Load<AudioClip>("ding");

        audioSrc = GetComponent<AudioSource>();

    }

    //Called after a play input
    public static void PlaySound (string clip)
    {
        switch (clip) {
            case "oof":
                audioSrc.PlayOneShot(damageTakenSound);
                break;
            case "victory":
                audioSrc.PlayOneShot(levelProgressionSound);
                break;
            case "ding":
                audioSrc.PlayOneShot(questionRightSound);
                break;
        }
    }
}
