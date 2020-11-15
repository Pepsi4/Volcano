using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    //[SerializeField]
    //private ParticleSystem WhiteParticle;

    //public ParticleSystem ExplosionSlimeParticleSystem;

    [SerializeField]
    private ParticleSystem CurrentParticleSystem;

    [RuntimeInitializeOnLoadMethod]
    public void CreateParticleSystemOnLocation(Transform transform)
    {
        var particleSystem = Instantiate(CurrentParticleSystem, transform.position, new Quaternion());
        float totalDuration = CurrentParticleSystem.main.duration + CurrentParticleSystem.main.startLifetimeMultiplier;
        Destroy(particleSystem.gameObject, totalDuration);
    }
}

