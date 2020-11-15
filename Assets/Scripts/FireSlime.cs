using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSlime : Slime
{
    public GameObject Fire;
    public GameObject Vapor;
    private AudioSource audioSource;
    private bool invul = true;

    public GameObject CanvasHelper;

    private int onInvulClicks = 0;
    private int OnInvulClicks
    {
        get { return onInvulClicks; }

        set
        {
            if (onInvulClicks >= 3)
            {
                Time.timeScale = 0; //pause
                CanvasHelper.SetActive(true);
                value = 0;
            }
            onInvulClicks = value;
        }
    }

    [SerializeField]
    private GameObject HealthPanel;

    private bool isBecameNormal = false;

    void Start()
    {
        base.Start();
        audioSource = this.GetComponent<AudioSource>();
    }

    public override void OnMouseDown()
    {
        if (isDead == false)
        {

            if (WaterController.IsWaterEnable && this.SlimeType == SlimeType.FireSlime) //
            {
                TurnSlimeToNormal();
                WaterController.StopMakingWater();
            }
            else if (invul == false)
            {
                GetDamage();
                WaterController.StopMakingWater();
            }
            else if (invul == true)
            {
                OnInvulClicks++;

            }
        }
    }

    private void TurnSlimeToNormal()
    {
        if (isBecameNormal == false)
        {
            //GameObject instance = Instantiate(Resources.Load("Prefabs/Slime", typeof(GameObject)), this.transform) as GameObject;
            GameObject slime = Resources.Load("Prefabs/Slime", typeof(GameObject)) as GameObject;
            this.GetComponent<SpriteRenderer>().sprite = slime.GetComponent<SpriteRenderer>().sprite;
            audioSource.Play();
            isBecameNormal = true;
            HealthPanel.SetActive(true);
            Vapor.SetActive(true);
            Fire.SetActive(false);
            Destroy(Vapor, 1f);
            invul = false;
            Debug.Log("TurnSlimeToNormal()");
        }

    }
}
