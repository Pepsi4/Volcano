using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMiddle : Slime
{
    new float Health = 8;

    protected override void GetDamage()
    {
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

    private void OnMouseDown()
    {
        GetDamage();

        if (Health <= 0)
        {
            if (IsDroppingCoin()) DropCoin();
            Destory();
        }
    }
}
