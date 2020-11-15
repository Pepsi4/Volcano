using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBecameVisibleEventHelper : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent OnBecameVisibleEvent;

    private void OnBecameInvisible()
    {
        Debug.Log("on enable");
        OnBecameVisibleEvent.Invoke();
    }

}
