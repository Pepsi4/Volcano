using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSlime : Slime
{
    new protected int _health = 4;
    private readonly float explosionRadius = 15000f;

    public MushroomSlime()
    {
        Health = _health;
    }
    //protected override int Health
    //{
    //    get { return _health; }
    //    set
    //    {
    //        Debug.Log(value);
    //        if (value <= 0 && isDead == false)
    //        {
    //            isDead = true;
    //            OnDeath.Invoke();
    //        }
    //        else
    //        {
    //            _health = value;
    //        }
    //    }
    //}

    public void Explose()
    {
        Collider2D[] hitColliders = Physics2D.OverlapAreaAll(
            new Vector2(transform.position.x - 0.7f, transform.position.y + 0.7f),
            new Vector2(transform.position.x + 0.7f, transform.position.y - 0.7f)
            );

        Debug.Log(hitColliders.Length);

        foreach (Collider2D collider in hitColliders)
        {
            Debug.Log(collider.gameObject.name);
            try
            {
                collider.gameObject.GetComponent<Slime>().GetDamage();

                Rigidbody2D foundObjectRigidbody = collider.GetComponent<Rigidbody2D>();

                if (foundObjectRigidbody.transform.position.x > this.gameObject.transform.position.x)
                {
                    collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
                }
                else
                {
                    collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0), ForceMode2D.Impulse);
                }

            }
            catch (System.NullReferenceException) { Debug.Log("GameOject is not a slime."); }


        }
    }

    protected override string AnimationOnDeathName { get; set; } = "Mushroom_Slime_Death";



    //[SerializeField]
    //public override void OnDeath()
    //{
    //    Debug.Log("OnDeath");
    //    GetComponent<Animator>().Play(AnimationOnDeathName);
    //}
}
