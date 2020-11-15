
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinsController : MonoBehaviour
{
    private static bool isValueLoaded;
    private static int coins = 12000;
    private int isFirstLoad = 0;
    public static int Coins
    {
        get
        {
            return coins;
        }
        set
        {
            coins = value;
            SaveValue();
        }
    }
    public Text coinText;
    public TextMeshProUGUI coinTextMeshPro;

    public void UpdateCoinUI()
    {
        //Debug.Log("UpdateCoinUI");
        if (coinText != null)
            coinText.text = coins.ToString();

        if (coinTextMeshPro != null)
        {
            coinTextMeshPro.text = coins.ToString();
        }
    }

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        LoadValue();
        UpdateCoinUI();
    }

    private void LoadValue()
    {
        if (isValueLoaded == false)
        {
            isFirstLoad = PlayerPrefs.GetInt("isFirstLoad");
            if (isFirstLoad == 1)
            {
                coins = PlayerPrefs.GetInt("Coins");
                isValueLoaded = true;
                Debug.Log("It's not a first load!");
            }
            else
            {
                Debug.Log("It's a first load!");
            }
        }
    }
    public static void SaveValue()
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetInt("isFirstLoad", 1);
    }
}


//13.02 **** 1:25
//made a save-load system for coins