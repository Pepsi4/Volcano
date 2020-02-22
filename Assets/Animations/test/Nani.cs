using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nani : MonoBehaviour
{
    public Animator Animator;
    public AnimationClip NaniAnimation;

    public AudioSource AudioSource;

    public void PlayNaniAnimation()
    {
        Animator.Play(NaniAnimation.name);
    }

    public void PlaySound()
    {
        AudioSource.Play();
    }
}
