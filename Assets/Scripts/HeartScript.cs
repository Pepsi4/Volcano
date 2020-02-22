using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    public int Health { get; set; } = 3;

    SpriteRenderer Heart;
    public Sprite Health2;
    public Sprite Health1;

    private void Start()
    {
        Heart = this.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.tag == "Enemy")
        {
            Health--;
            OnPlayerGetDamage();
            collision.gameObject.GetComponent<Enemy>().Destory();
        }
    }

    void OnPlayerGetDamage()
    {
        switch (Health)
        {
            case 2:
                Heart.sprite = Health2;
                break;
            case 1:
                Heart.sprite = Health1;
                break;

            case 0:
                break;
        }
    }
}
