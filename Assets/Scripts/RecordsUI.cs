using System.Collections;
using TMPro;
using UnityEngine;

public class RecordsUI : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public SlimeType SlimeType;
    public Trofe Trofe;

    void Start()
    {
        ShowRecord();

        try
        {
            Trofe.CurrentSlimesCollected = int.Parse(textMeshPro.text);
            Trofe.UpdateTrophies();
        }
        catch (System.NullReferenceException) { }
    }



    public void ShowRecord()
    {
        switch (SlimeType)
        {
            case SlimeType.Slime:
                Debug.Log(Records.SlimesCollected);
                textMeshPro.text = Records.SlimesCollected.ToString();
                break;

            case SlimeType.MiddleSlime:
                textMeshPro.text = Records.MiddleSlimesCollected.ToString();
                break;

            case SlimeType.GoldenSlime:
                textMeshPro.text = Records.GoldenSlimesCollected.ToString();
                break;

            case SlimeType.MushroomSlime:
                textMeshPro.text = Records.MushroomSlimesCollected.ToString();
                break;

            case SlimeType.FireSlime:
                textMeshPro.text = Records.FireSlimesCollected.ToString();
                break;

            case SlimeType.IceSlime:
                textMeshPro.text = Records.IceSlimesCollected.ToString();
                break;

            default:
                //Debug.Log(Records.AllSlimesCollected);
                textMeshPro.text = Records.AllSlimesCollected.ToString();
                break;
        }



    }
}