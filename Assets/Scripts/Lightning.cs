using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public GameObject WhiteScreen;
    public GameObject SoundPlayer;
    public string AnimationName = "Lightning";

    public void PlayLightning()
    {
        WhiteScreen.GetComponent<Animator>().Play(AnimationName);
    }

    public void PlaySound()
    {
        SoundPlayer.GetComponent<AudioSource>().Play();
    }
}
