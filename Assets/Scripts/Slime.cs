using System.Collections;
using UnityEngine;

public class Slime : Enemy
{
    protected Animator animator;


    public WaterController WaterController;
    public FireController FireController;


    private Rigidbody2D rigidbody;

    new public string GotDamageAnimation = "Slime_got_damage";

    public void HideHealthPanel()
    {
        Debug.Log("HideHealthPanel");
        HpBar.SetActive(false);
    }

    protected SpriteRenderer hpBarSpriteRenderer;

    new protected int _health = 4;

    public void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();

        hpBarSpriteRenderer = HpBar.GetComponent<SpriteRenderer>();

        StartCoroutine(StartSlimeJump());
    }

    private void Move()
    {
        rigidbody.AddForce(new Vector3(-0.7f, 1.2f, 0), ForceMode2D.Impulse);
    }

    private float jupmDeltaTime = 3f;

    private IEnumerator StartSlimeJump()
    {
        Move();
        yield return new WaitForSeconds(jupmDeltaTime);
        StartCoroutine(StartSlimeJump());
    }

    public Sprite HealthBar_4;
    public Sprite HealthBar_3;
    public Sprite HealthBar_2;
    public Sprite HealthBar_1;
    public GameObject HpBar;

    public virtual void GetDamage()
    {
        Health--;

        if (isDead == false)
        {


            animator.Play(GotDamageAnimation);

            switch (Health)
            {
                case 3:
                    hpBarSpriteRenderer.sprite = HealthBar_3;
                    break;

                case 2:
                    hpBarSpriteRenderer.sprite = HealthBar_2;
                    break;

                case 1:
                    hpBarSpriteRenderer.sprite = HealthBar_1;
                    break;
            }
        }
    }

    public virtual void OnMouseDown()
    {
        if (isDead == false)
        {
            GetDamage();
        }


        try
        {
            if (WaterController.IsWaterEnable)
            {
                WaterController.StopMakingWater();
            }

            if (FireController.IsFireEnable)
            {
                FireController.StopMakingFire();
            }
        }
        catch (System.NullReferenceException)
        {
            Debug.Log("WaterController or FireController is disabled.");
        }

    }



    public void TryToDropCoin()
    {
        if (IsDroppingCoin()) DropCoin();
    }


    //public UnityEngine.Events.UnityEvent OnDeath;
}
