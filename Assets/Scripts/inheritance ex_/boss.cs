using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss
{
    protected string message;

    //to test - delete brackets
    public void Shoot()
    {
        // Debug.Log(message);
    }
}

public class IceBoss : Boss
{
    public IceBoss()
    {
        message = "Ice Attack";
    }
}

public class FireBoss : Boss
{
    public FireBoss()
    {
        message = "Fire Ball";
    }
}

