using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    string GameControllerTag = "GameController";
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
}
