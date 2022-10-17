using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Week7Killzone : MonoBehaviour
{
    public Week7GameObjectEvent KillZoneEntered;    

    private void OnTriggerEnter(Collider other)
    {
        if (KillZoneEntered != null) KillZoneEntered.Invoke(other.transform.root.gameObject); // Get the root gameObject
    }
}
