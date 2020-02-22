using UnityEngine;

public class BossController : MonoBehaviour
{
    private void OnDisable()
    {
        FireBoss fireBoss = new FireBoss();
        IceBoss iceBoss = new IceBoss();

        fireBoss.Shoot();
        iceBoss.Shoot();
    }
}
