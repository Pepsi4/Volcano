using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    [SerializeField]
    FireController FireController;

    public bool IsWaterEnable = false;
    public void StartMakingWater()
    {
        IsWaterEnable = true;
        FireController.StopMakingFire();
        this.GetComponent<Image>().color = new Color(0.4514952f, 0.4603769f, 0.8396226f); //dark blue
    }

    public void StopMakingWater()
    {
        IsWaterEnable = false;
        this.GetComponent<Image>().color = new Color(1f, 1f, 1f); //dark blue
    }
}
