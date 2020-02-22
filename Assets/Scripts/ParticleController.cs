using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem ExplosionSlimeParticleSystem;
    public void CreateParticleSystemOnLocation(Transform transform)
    {
        var particleSystem = Instantiate(ExplosionSlimeParticleSystem, transform.position, new Quaternion());
        float totalDuration = ExplosionSlimeParticleSystem.main.duration + ExplosionSlimeParticleSystem.main.startLifetimeMultiplier;
        Destroy(particleSystem.gameObject, totalDuration);
    }
}

