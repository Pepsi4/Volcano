using UnityEngine.UI;
using TMPro;
using UnityEngine;


//trophie info
public class TrofeInfo : MonoBehaviour
{
    //script is using for UI panel, which is showhing how much slimes you need
    // to collect for trophies.

    //rename to trophy button 
    //
    public string SlimeName;

    public TextMeshProUGUI TextMeshProBronze;
    public TextMeshProUGUI TextMeshProSilver;
    public TextMeshProUGUI TextMeshProGold;

    public Sprite SlimeSprite;
    public GameObject SlimeImageToChange;
    public TextMeshProUGUI TitleText;

    public void ChangeTitleText()
    {
        TitleText.text = "to achive this trophies you need to collect follow amount of " + SlimeName + "!";
    }


    public Trofe Trofe;

    public void ChangeTrofeText()
    {
        TextMeshProBronze.text = Trofe.SlimesToAchiveBronze.ToString();
        TextMeshProSilver.text = Trofe.SlimesToAchiveSilver.ToString();
        TextMeshProGold.text = Trofe.SlimesToAchiveGold.ToString();
    }

    public void ChangeSlimeImage()
    {
        SlimeImageToChange.GetComponent<Image>().sprite = SlimeSprite;
    }
}
