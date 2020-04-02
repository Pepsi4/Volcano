using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public Animator AnimatorMenu;
    public Animator AnimatorSelectMode;
    public Animator AnimatorShop;
    public Animator AnimatorBuffsShop;

    [SerializeField]
    private AnimationClip ShowUpAnimationFromDown;

    [SerializeField]
    private AnimationClip ShowUpAnimationFromTop;

    [SerializeField]
    private AnimationClip HideAnimationDown;

    [SerializeField]
    private AnimationClip HideAnimationUp;

    public void StartButton()
    {
        AnimatorMenu.Play(HideAnimationDown.name);

        AnimatorSelectMode.Play(ShowUpAnimationFromTop.name);
    }

    public void HideSelectGameMode()
    {
        AnimatorSelectMode.Play(HideAnimationUp.name);

        AnimatorMenu.Play(ShowUpAnimationFromDown.name);
    }

    public void ShowShop()
    {
        AnimatorShop.Play(ShowUpAnimationFromTop.name);

        AnimatorMenu.Play(HideAnimationDown.name);
    }

    public void ShowBuffsShop()
    {
        AnimatorShop.Play(HideAnimationDown.name);

        AnimatorBuffsShop.Play(ShowUpAnimationFromTop.name);
    }

    public void HideBuffsShop()
    {
        AnimatorBuffsShop.Play(HideAnimationUp.name);

        AnimatorShop.Play(ShowUpAnimationFromDown.name);

        
    }

    public void HideShop()
    {
        AnimatorShop.Play(HideAnimationUp.name);

        AnimatorMenu.Play(ShowUpAnimationFromDown.name);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
