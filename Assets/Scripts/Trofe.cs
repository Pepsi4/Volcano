using System.Collections;
using TMPro;
using UnityEngine;

public class Trofe : MonoBehaviour
{

    

    public TextMeshProUGUI text;

    public GameObject BronzeTrofe;
    public GameObject SilverTrofe;
    public GameObject GoldenTrofe;



    public int SlimesToAchiveBronze = 10;
    public int SlimesToAchiveSilver = 20;
    public int SlimesToAchiveGold = 50;

    public int CurrentSlimesCollected;
    

    public void UpdateTrophies()
    {
        Debug.Log(CurrentSlimesCollected);
        if (CurrentSlimesCollected > SlimesToAchiveBronze)
        {
            BronzeTrofe.SetActive(true);
        }
        if (CurrentSlimesCollected > SlimesToAchiveSilver)
        {
            SilverTrofe.SetActive(true);
        }
        if (CurrentSlimesCollected > SlimesToAchiveGold)
        {
            GoldenTrofe.SetActive(true);
        }
    }

    //private void Start()
    //{
    //    Debug.Log("Start 1");
    //    UpdateTrophies();
    //}

}
