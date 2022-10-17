using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Week8CollisionEvent : MonoBehaviour
{
    public UnityEvent OnCollisionEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if (OnCollisionEvent != null) OnCollisionEvent.Invoke();
    }
}
