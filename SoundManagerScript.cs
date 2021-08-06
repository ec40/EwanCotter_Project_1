using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip damageTakenSound, levelProgressionSound, questionRightSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        damageTakenSound = Resources.Load<AudioClip>("oof");
        levelProgressionSound = Resources.Load<AudioClip>("victory");
        questionRightSound = Resources.Load<AudioClip>("ding");

        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
