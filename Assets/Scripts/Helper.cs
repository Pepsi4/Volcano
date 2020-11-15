using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    public Canvas MainCanvas;
    //public Canvas FireAndWaterHelperCanvas;
    //[Header("FireAndWahter Settings")]
    public void ShowCanvas(Canvas canvas)
    {
        canvas.gameObject.SetActive(true);
    }

    public void HideCanvas(Canvas canvas)
    {
        canvas.gameObject.SetActive(false);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
