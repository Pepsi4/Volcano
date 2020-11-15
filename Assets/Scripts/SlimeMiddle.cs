using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMiddle : Slime
{
    //new float Health = 8;

    new protected int _health = 8;
    public SlimeMiddle()
    {
        Health = _health;
    }

    public override void GetDamage()
    {
        Debug.Log("Health : " + Health);

        Health--;
        animator.Play(GotDamageAnimation);
        switch (Health)
        {
            case 6:
                hpBarSpriteRenderer.sprite = HealthBar_3;
                break;

            case 4:
                hpBarSpriteRenderer.sprite = HealthBar_2;
                break;

            case 2:
                hpBarSpriteRenderer.sprite = HealthBar_1;
                break;
        }
    }



    
}
