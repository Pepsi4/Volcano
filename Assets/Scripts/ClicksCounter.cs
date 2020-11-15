using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicksCounter : MonoBehaviour
{
    public int Clicks { get; set; }

    public void IncrementClicks()
    {
        if (IsDefaultAnimationPlayingOnObjects())
        {
            OnClickWithoutAnimations.Invoke();
            Debug.Log(Clicks++);
            
        }
    }

    //Section for animations.
    //we do not need to count clicks, if we have playing animation.

    public UnityEngine.Events.UnityEvent OnClickWithoutAnimations;

    [SerializeField]
    List<Animator> animators = new List<Animator>();
    [SerializeField]
    string defaultAnimatorState;


    public bool IsDefaultAnimationPlayingOnObjects()
    {
        foreach (var item in animators)
        {
            if (item.GetCurrentAnimatorStateInfo(0).IsName(defaultAnimatorState) == false)
            {
                return false;
            }
        }

        return true;
    }
}
