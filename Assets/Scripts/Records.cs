using UnityEngine.UI;
using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Records : MonoBehaviour
{
    public static int AllSlimesCollected;

    //Slimes records
    public static int SlimesCollected;
    public static int MiddleSlimesCollected;
    public static int GoldenSlimesCollected;
    public static int FireSlimesCollected;
    public static int IceSlimesCollected;
    public static int MushroomSlimesCollected;

    public static int AllSlimesCollectedBronzeTrofe = 100;
    public static int AllSlimesCollectedSilverTrofe = 250;
    public static int AllSlimesCollectedGoldenTrofe = 500;

    public static int amountOfSlimesToAchieveCongratsText = 1;
    public static int amountOfMidleSlimesToAchieveCongratsText = 25;
    public static int amountOfMushroomSlimesToAchieveCongratsText = 25;
    public static int amountOfGoldenSlimesToAchieveCongratsText = 10;
    public static int amountOfFireSlimesToAchieveCongratsText = 10;
    public static int amountOfIceSlimesToAchieveCongratsText = 10;

    public GameObject CongratsText;


    private bool isAllSlimesCollectedBronzeTrofeAchived;
    private bool isAllSlimesCollectedSilverTrofeAchived;
    private bool isAllSlimesCollectedGoldenTrofeAchived;

    [Header("Trophy achivment")]

    [SerializeField]
    private GameObject TrophyImage;

    [SerializeField]
    private TextMeshProUGUI congratsText;

    [SerializeField]
    private Sprite BronzeTrophySprite;
    [SerializeField]
    private Sprite SilverTrophySprite;
    [SerializeField]
    private Sprite GoldenTrophySprite;

    [SerializeField]
    private GameObject Camera;


    public UnityEngine.Events.UnityEvent OnAllSlimesCollectedTrofeAchieved;

    void SaveTrofeResults()
    {
        PlayerPrefs.SetInt("isAllSlimesCollectedBronzeTrofeAchived", boolToInt(isAllSlimesCollectedBronzeTrofeAchived));
        PlayerPrefs.SetInt("isAllSlimesCollectedSilverTrofeAchived", boolToInt(isAllSlimesCollectedSilverTrofeAchived));
        PlayerPrefs.SetInt("isAllSlimesCollectedGoldenTrofeAchived", boolToInt(isAllSlimesCollectedGoldenTrofeAchived));
    }

    void LoadTrofeResults()
    {
        isAllSlimesCollectedBronzeTrofeAchived = intToBool(PlayerPrefs.GetInt("isAllSlimesCollectedBronzeTrofeAchived"));
        isAllSlimesCollectedSilverTrofeAchived = intToBool(PlayerPrefs.GetInt("isAllSlimesCollectedSilverTrofeAchived"));
        isAllSlimesCollectedGoldenTrofeAchived = intToBool(PlayerPrefs.GetInt("isAllSlimesCollectedGoldenTrofeAchived"));
    }

    void StopMainMusic()
    {
        float activeAudioTime = Camera.GetComponent<AudioSource>().time;
        Camera.GetComponent<AudioSource>().Stop();
        Camera.GetComponent<AudioSource>().time = activeAudioTime;
    }

    void CheckAllSlimesCollectedTrofe()
    {
        if (AllSlimesCollected >= AllSlimesCollectedBronzeTrofe && isAllSlimesCollectedBronzeTrofeAchived == false)
        {
            OnAllSlimesCollectedTrofeAchieved.Invoke();
            congratsText.text = "Well done!!! You have collected 100 slimes and you are achieving bronze trophy!";
            TrophyImage.GetComponent<Image>().sprite = BronzeTrophySprite;
            isAllSlimesCollectedBronzeTrofeAchived = true;
            StopMainMusic();

            SaveTrofeResults();
        }

        if (AllSlimesCollected >= AllSlimesCollectedSilverTrofe && isAllSlimesCollectedSilverTrofeAchived == false)
        {
            OnAllSlimesCollectedTrofeAchieved.Invoke();
            congratsText.text = "Well done!!! You have collected " + AllSlimesCollectedSilverTrofe + " slimes and you are achieving silver trophy!";
            TrophyImage.GetComponent<Image>().sprite = SilverTrophySprite;
            isAllSlimesCollectedSilverTrofeAchived = true;
            StopMainMusic();

            SaveTrofeResults();
        }

        if (AllSlimesCollected >= AllSlimesCollectedGoldenTrofe && isAllSlimesCollectedGoldenTrofeAchived == false)
        {
            OnAllSlimesCollectedTrofeAchieved.Invoke();
            congratsText.text = "Well done!!! You have collected " + AllSlimesCollectedGoldenTrofe + " slimes and you are achieving golden trophy!";
            TrophyImage.GetComponent<Image>().sprite = GoldenTrophySprite;
            isAllSlimesCollectedGoldenTrofeAchived = true;
            StopMainMusic();

            SaveTrofeResults();
        }
    }

    public void Log()
    {
        Debug.Log("AllSlimesCollected : " + AllSlimesCollected);
    }

    private void LoadSlimesCollectedValue()
    {
        AllSlimesCollected = PlayerPrefs.GetInt("AllSlimesCollected", 0);

        SlimesCollected = PlayerPrefs.GetInt("SlimesCollected", 0);
        MiddleSlimesCollected = PlayerPrefs.GetInt("MiddleSlimesCollected", 0);
        GoldenSlimesCollected = PlayerPrefs.GetInt("GoldenSlimesCollected", 0);
        FireSlimesCollected = PlayerPrefs.GetInt("FireSlimesCollected", 0);
        IceSlimesCollected = PlayerPrefs.GetInt("IceSlimesCollected", 0);
        MushroomSlimesCollected = PlayerPrefs.GetInt("MushroomSlimesCollected", 0);
    }

    void Awake()
    {
        LoadSlimesCollectedValue();
        LoadTrofeResults();
    }

    public void SaveValue()
    {
        PlayerPrefs.SetInt("AllSlimesCollected", AllSlimesCollected);

        PlayerPrefs.SetInt("SlimesCollected", SlimesCollected);
        PlayerPrefs.SetInt("MiddleSlimesCollected", MiddleSlimesCollected);
        PlayerPrefs.SetInt("GoldenSlimesCollected", GoldenSlimesCollected);
        PlayerPrefs.SetInt("FireSlimesCollected", FireSlimesCollected);
        PlayerPrefs.SetInt("IceSlimesCollected", IceSlimesCollected);
        PlayerPrefs.SetInt("MushroomSlimesCollected", MushroomSlimesCollected);
    }

    private string showCongratsTextAnimationName = "RecordTextTipShowAndHide";
    List<string> congratsTextList = new List<string>();
    private readonly Queue<IEnumerator> _congratsQueue = new Queue<IEnumerator>();
    private string CheckRecordsForCongrats(SlimeType slimeType)
    {
        if (slimeType == SlimeType.Slime && SlimesCollected % amountOfSlimesToAchieveCongratsText == 0 && SlimesCollected != 0)
        {
            Debug.Log("slimes % 5 == 0 ");
            return "Congrats! You have been collected your " + SlimesCollected + "th slime!";

        }
        if (slimeType == SlimeType.MiddleSlime && MiddleSlimesCollected % amountOfMidleSlimesToAchieveCongratsText == 0 && MiddleSlimesCollected != 0)
        {
            return "Congrats! You have been collected your " + MiddleSlimesCollected + "th giant slime!";
            // CongratsText.GetComponent<Animator>().Play(showCongratsTextAnimationName);
            //yield return new WaitForSeconds(10f);

        }
        if (slimeType == SlimeType.MushroomSlime && MushroomSlimesCollected % amountOfMushroomSlimesToAchieveCongratsText == 0)
        {
            return "Congrats! You have been collected your " + MushroomSlimesCollected + "th mushroom slime!";
            //CongratsText.GetComponent<Animator>().Play(showCongratsTextAnimationName);
            //yield return new WaitForSeconds(10f);

        }
        if (slimeType == SlimeType.GoldenSlime && GoldenSlimesCollected % amountOfGoldenSlimesToAchieveCongratsText == 0 && GoldenSlimesCollected != 0)
        {
            return "Congrats! You have been collected your " + GoldenSlimesCollected + "th golden slime!";
            //CongratsText.GetComponent<Animator>().Play(showCongratsTextAnimationName);
            //yield return new WaitForSeconds(10f);

        }
        if (slimeType == SlimeType.FireSlime && FireSlimesCollected % amountOfFireSlimesToAchieveCongratsText == 0 && FireSlimesCollected != 0)
        {
            return "Congrats! You have been collected your " + FireSlimesCollected + "th fire slime!";
            //CongratsText.GetComponent<Animator>().Play(showCongratsTextAnimationName);
            //yield return new WaitForSeconds(10f);

        }
        if (slimeType == SlimeType.IceSlime && IceSlimesCollected % amountOfIceSlimesToAchieveCongratsText == 0 && IceSlimesCollected != 0)
        {
            return "Congrats! You have been collected your " + IceSlimesCollected + "th ice slime!";
            // CongratsText.GetComponent<Animator>().Play(showCongratsTextAnimationName);
            //yield return new WaitForSeconds(10f);

        }
        return null;
    }

    private IEnumerator ShowCongratsText(string str)
    {
        CongratsText.GetComponent<TextMeshProUGUI>().text = str;
        CongratsText.GetComponent<Animator>().Play(showCongratsTextAnimationName);
        yield return new WaitForSeconds(10f);
    }

    public void IncreaseValue(GameObject slime)
    {
        SlimeType slimeType = slime.GetComponent<Slime>().SlimeType;
        Log();
        switch (slimeType)
        {
            case SlimeType.Slime:
                // Debug.Log("Slimes: " + SlimesCollected);
                SlimesCollected++;
                break;

            case SlimeType.MiddleSlime:
                MiddleSlimesCollected++;
                break;

            case SlimeType.GoldenSlime:
                GoldenSlimesCollected++;
                break;

            case SlimeType.MushroomSlime:
                MushroomSlimesCollected++;
                break;

            case SlimeType.FireSlime:
                FireSlimesCollected++;
                break;

            case SlimeType.IceSlime:
                IceSlimesCollected++;
                break;
        }

        AllSlimesCollected++;
        SaveValue();
        CheckAllSlimesCollectedTrofe();

        string text = CheckRecordsForCongrats(slimeType);
        if (text != null)
        {
            queue.EnqueueAction(ShowCongratsText(text));
           // _congratsQueue.Enqueue(ShowCongratsText(text));
        }
        //StartCoroutine(ExecuteQueue());



    }

    public void IncreaseValue(SlimeType slimeType)
    {
        switch (slimeType)
        {
            case SlimeType.Slime:
                //Debug.Log("SlimesCollected: " + SlimesCollected);
                SlimesCollected++;
                break;

            case SlimeType.MiddleSlime:
                MiddleSlimesCollected++;
                break;

            case SlimeType.GoldenSlime:
                GoldenSlimesCollected++;
                break;

            case SlimeType.MushroomSlime:
                MushroomSlimesCollected++;
                break;

            case SlimeType.FireSlime:
                FireSlimesCollected++;
                break;

            case SlimeType.IceSlime:
                IceSlimesCollected++;
                break;
        }

        AllSlimesCollected++;
        SaveValue();
        CheckAllSlimesCollectedTrofe();

        string text = CheckRecordsForCongrats(slimeType);
        if (text != null)
        {
            queue.EnqueueAction(ShowCongratsText(text));
            // _congratsQueue.Enqueue(ShowCongratsText(text));
        }
        //StartCoroutine(ExecuteQueue());
    }

    void Start()
    {
        queue = new CoroutineQueue(this);
        queue.StartLoop();
    }

    private CoroutineQueue queue;

    private IEnumerator ExecuteQueue()
    {
        while (_congratsQueue.Count > 0)
        {
            yield return new WaitForSeconds(10f);
            yield return _congratsQueue.Dequeue();
        }
    }


    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }

    int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }
}

public class CoroutineQueue
{
    MonoBehaviour m_Owner = null;
    Coroutine m_InternalCoroutine = null;
    Queue<IEnumerator> actions = new Queue<IEnumerator>();
    public CoroutineQueue(MonoBehaviour aCoroutineOwner)
    {
        m_Owner = aCoroutineOwner;
    }
    public void StartLoop()
    {
        m_InternalCoroutine = m_Owner.StartCoroutine(Process());
    }
    public void StopLoop()
    {
        m_Owner.StopCoroutine(m_InternalCoroutine);
        m_InternalCoroutine = null;
    }
    public void EnqueueAction(IEnumerator aAction)
    {
        actions.Enqueue(aAction);
    }

    private IEnumerator Process()
    {
        while (true)
        {
            if (actions.Count > 0)
                yield return m_Owner.StartCoroutine(actions.Dequeue());
            else
                yield return null;
        }
    }
}
