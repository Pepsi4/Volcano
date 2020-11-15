using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationOnClicks : MonoBehaviour
{
    [SerializeField]
    private List<string> animationNames = new List<string>();

    [SerializeField]
    private List<int> playAnimationOnClicks = new List<int>();

    public ClicksCounter ClicksCounter;

    private int animationCounter = 0;
   // private int clicksCounter = 0;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (isAnimationNull() == false)
        {
            animator.Play(animationNames[animationCounter]);
            Debug.Log("animationCounter: " + animationCounter++);

            
        }

       // ClicksCounter.Clicks++;
    }

    private bool isAnimationNull()
    {
        for (int i = 0; i < playAnimationOnClicks.Count; i++)
        {
            if (ClicksCounter.Clicks == playAnimationOnClicks[i])
            {
                return false;
            }
        }

        return true;
    }
}
