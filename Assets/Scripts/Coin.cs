using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    string GameControllerTag = "CoinsController";
    private void Awake()
    {
        CoinsController = GameObject.Find(GameControllerTag).GetComponent<CoinsController>();
    }

    CoinsController CoinsController;
    private void OnMouseDown()
    {
        CoinsController.Coins++;
        CoinsController.UpdateCoinUI();
        Destroy(this.gameObject);
    }

    bool flyToHero = false;
    float timeStamp;
    GameObject hero;
    Vector2 heroDirection;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "CoinsMagnet")
        {
            timeStamp = Time.time;
            hero = GameObject.Find("Hero");
            flyToHero = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (flyToHero)
        {
            Debug.Log("MoveToHero");
            heroDirection = -(transform.position - hero.transform.position).normalized;
            rb.velocity = new Vector2(heroDirection.x, heroDirection.y) * (Time.time / timeStamp);
        }
    }
}
