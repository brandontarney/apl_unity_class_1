using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week8Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Something exited");
    }
}
