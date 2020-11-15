using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    CoinsController CoinsController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Coin"))
        {
            CoinsController.Coins++;
            CoinsController.UpdateCoinUI();
            Destroy(collision.gameObject);
        }
    }
}
