using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSlime : Slime
{
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
            if (FireController.IsFireEnable) //
            {
                TurnSlimeToNormal();
                FireController.StopMakingFire();
            }
            else if (invul == false)
            {
                GetDamage();
                FireController.StopMakingFire();
            }
            else if (invul == true)
            {
                OnInvulClicks++;
            }
        }
    }

    private void TurnSlimeToNormal()
    {
        Debug.Log("Turn to normal...");
        if (isBecameNormal == false)
        {
            GameObject slime = Resources.Load("Prefabs/Slime", typeof(GameObject)) as GameObject;
            this.GetComponent<SpriteRenderer>().sprite = slime.GetComponent<SpriteRenderer>().sprite;
            audioSource.Play();
            isBecameNormal = true;
            HealthPanel.SetActive(true);
            Vapor.SetActive(true);
            Destroy(Vapor, 1f);
            invul = false;
        }
    }
}
