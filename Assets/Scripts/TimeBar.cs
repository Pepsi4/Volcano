using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TimeBar : MonoBehaviour
{
    public GameObject MovingObject;
    public float Time { get; set; } = 25f;

    private float positonRightX = 105f;
    private float positionLeftX = -100f;

    public SlimeSpawner SlimeSpawner;

    private RectTransform MovingObjectRect;
    public RectTransform FlagFirst;
    public RectTransform FlagSecond;

    public bool IsFirstWaveStarted { get; set; } = false;
    public bool IsSecondWaveStarted { get; set; } = false;
    public bool isThirdWaveStarted { get; set; } = false;

    private Vector3 velocity = Vector3.zero;

    // float speed;
    void Start()
    {
        MovingObjectRect = MovingObject.GetComponent<RectTransform>();
        MovingObject.GetComponent<Animator>().Play("MovingObjectOnTimeBar");
        MovingObject.GetComponent<Animator>().speed = 0.5f;
    }

    private void Update()
    {
        if (MovingObjectRect.rectOverlaps(FlagFirst) == true && IsFirstWaveStarted == false)
        {
            Debug.Log("MovingObjectRect is overlaps FlagFirst");
            IsFirstWaveStarted = true;
            StartWave_1();
        }
        else if (MovingObjectRect.rectOverlaps(FlagSecond) == true && IsSecondWaveStarted == false)
        {
            Debug.Log("MovingObjectRect is overlaps FlagSecond");
            IsSecondWaveStarted = true;
            StartWave_2();
        }
    }

    private void StartWave_1()
    {
        Debug.Log("First wave started!");
        SlimeSpawner.SpawningCount = Spawner.GetWave().EnemiesInWave_1;
        SlimeSpawner.StartSpawningEnemies();
    }

    private void StartWave_2()
    {
        Debug.Log("Second wave started!");
        SlimeSpawner.SpawningCount = Spawner.GetWave().EnemiesInWave_2;
        SlimeSpawner.StartSpawningEnemies();
    }
}


public static class ExtensionMethod
{
    public static bool rectOverlaps(this RectTransform rectTrans1, RectTransform rectTrans2)
    {
        Rect rect1 = new Rect(rectTrans1.localPosition.x, rectTrans1.localPosition.y, rectTrans1.rect.width / 2, rectTrans1.rect.height);
        Rect rect2 = new Rect(rectTrans2.localPosition.x, rectTrans2.localPosition.y, rectTrans2.rect.width, rectTrans2.rect.height);

        return rect1.Overlaps(rect2);
    }
}