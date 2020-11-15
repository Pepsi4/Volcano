using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnBecameInvisible : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject, 1f);
    }
}
