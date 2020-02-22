using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ParticleController ParticleSystemController;
    public string GotDamageAnimation { get; set; }

    public GameObject Coin;
    private float _coinLifeTime = 15f;

    public void DropCoin()
    {
        var coin = Instantiate(Coin, transform.position, new Quaternion());
        Destroy(coin, _coinLifeTime);
    }

    /// <summary>
    /// Destroying object and creates particle system.
    /// </summary>
    public void Destory()
    {
        ParticleSystemController.CreateParticleSystemOnLocation(this.transform);
        this.gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
