using UnityEngine;

public class Slime : Enemy
{
    protected Animator animator;
    protected float Health = 4;

    public Sprite HealthBar_4;
    public Sprite HealthBar_3;
    public Sprite HealthBar_2;
    public Sprite HealthBar_1;
    public GameObject HpBar;

    new public string GotDamageAnimation = "Slime_got_damage";

    protected SpriteRenderer hpBarSpriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();

        //Debug.Log(animator);

        hpBarSpriteRenderer = HpBar.GetComponent<SpriteRenderer>();
    }

    protected virtual void GetDamage()
    {
        Health--;
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

    private float minRangeChance = 0;
    private float maxRangeChance = 1;
    protected bool IsDroppingCoin()
    {
        //Debug.Log(Random.Range(minRangeChance, maxRangeChance));
        bool result = Mathf.RoundToInt(Random.Range(minRangeChance, maxRangeChance)) == 1;
        Debug.Log(result);
        return result;
    }

    private void OnBecameInvisible()
    {
        Destory();
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
