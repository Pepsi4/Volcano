using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Message : MonoBehaviour
{
    // AUDIO
    [SerializeField]
    private List<AudioClip> audioClips = new List<AudioClip>();

    [SerializeField]
    private List<int> playSoundsOnMessage = new List<int>();

    [SerializeField]
    private AudioSource audioSource;

    private int audioCounter = 0;

    //animation
    private Animator animator;
    private int messageCounter = 0;
    [SerializeField]
    private TextMeshProUGUI textMesh;

    public ClicksCounter ClicksCounter;

    public List<int> ShowMessageOnClick = new List<int>();
    public List<string> Messages = new List<string>();
    //public static bool IsShouldMessageBoxAppear = true;
    public float CharacterDelay = 0.1f;

    public bool isAnimationShowing = false;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void StartShowingMessage()
    {

        try
        {
            StartCoroutine(ShowMessage(Messages[messageCounter]));
        }
        catch (System.ArgumentOutOfRangeException ex)
        {
            Debug.Log("Out of messages.");
        }


        messageCounter++;
    }



    public void StopShowingMessage()
    {
        StopAllCoroutines();
    }

    IEnumerator ShowMessage(string text)
    {

        for (int i = 0; i < text.Length; i++)
        {
            textMesh.text += text[i];
            yield return new WaitForSeconds(CharacterDelay);
        }
    }

    //public void MessageCounterIncrement()
    //{
    //    messageCounter++;
    //}

    private bool isMessageNull()
    {
        for (int i = 0; i < ShowMessageOnClick.Count; i++)
        {
            if (ClicksCounter.Clicks == ShowMessageOnClick[i])
            {
                return false;
            }
        }

        return true;
    }

    void PlaySoundFromList()
    {
        try
        {
            audioSource.clip = audioClips[audioCounter];
            audioCounter++;
            audioSource.Play();
        }
        catch (System.ArgumentOutOfRangeException) { Debug.Log("Out of audio clips!"); }

    }

    public void PlayAnimation(string animName)
    {
        if (isMessageNull() == false)
        {


            textMesh.text = "";
            animator.Play(animName, 0);


            if (playSoundsOnMessage.IndexOf(ClicksCounter.Clicks) != -1)
            {
                PlaySoundFromList();
            }

        }



        //animator.ResetTrigger("hideMessage");

        // HideMessage(2.5f);
    }

    //public void HideMessage(float delay)
    //{
    //    StartCoroutine(HideMessageDelay(delay));
    //}

    //IEnumerator HideMessageDelay(float delay)
    //{
    //    yield return new WaitForSeconds(delay);

    //    animator.SetTrigger("hideMessage");
    //}
}
