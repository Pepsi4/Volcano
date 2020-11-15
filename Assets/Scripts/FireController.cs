using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField]
    WaterController WaterController;

    public bool IsFireEnable = false;

    public void StartMakingFire()
    {
        IsFireEnable = true;
        WaterController.StopMakingWater();
        this.GetComponent<Image>().color = new Color(0.4514952f, 0.4603769f, 0.8396226f); //dark blue
    }

    public void StopMakingFire()
    {
        IsFireEnable = false;
        this.GetComponent<Image>().color = new Color(1f, 1f, 1f); //dark blue
    }
}
