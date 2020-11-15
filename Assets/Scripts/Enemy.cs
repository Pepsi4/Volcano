using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SlimeType SlimeType;

    public UnityEngine.Events.UnityEvent OnDeath;

    protected int _health = 4;
    protected virtual int Health
    {
        get { return _health; }
        set
        {
            if (value <= 0 && isDead == false)
            {
                isDead = true;
                OnDeath.Invoke();
            }
            else
            {
                _health = value;
            }
        }
    }

    void SetHealth(int health)
    {
        _health = health;
    }

    public void Test()
    {
        Debug.Log("Test");
    }

    private float minRangeChance = 0;
    private float maxRangeChance = 1;
    protected bool IsDroppingCoin()
    {
        bool result = Mathf.RoundToInt(Random.Range(minRangeChance, maxRangeChance)) == 1;
        return result;
    }

    protected virtual string AnimationOnDeathName { get; set; }

    //private bool isDeathAnimationPlaying = false;
    public void PlayDeathAnimation()
    {
        GetComponent<Animator>().Play(AnimationOnDeathName);
    }

    public ParticleController ParticleSystemController;
    public string GotDamageAnimation { get; set; }

    protected bool isDead = false;


    public GameObject Coin;
    private float _coinLifeTime = 15f;

    public void DropCoin()
    {
        var coin = Instantiate(Coin, transform.position, new Quaternion());
        Destroy(coin, _coinLifeTime); //TODO: fix incorrect destory.
    }

    /// <summary>
    /// Destroying object and creates particle system.
    /// </summary>
    public void Destroy()
    {
        ParticleSystemController.CreateParticleSystemOnLocation(this.transform);
        Destroy(this.gameObject);
    }



    private void OnBecameInvisible()
    {
        if (LevelLoader.IsLevelLoading == false)
        {
            Destroy(this.gameObject);
        }
        //Debug.Log(this.gameObject.name + "  HAS DESTROYED");

    }
}
