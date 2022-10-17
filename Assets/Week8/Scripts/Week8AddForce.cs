using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week8AddForce : MonoBehaviour
{
    public float ForceAmount = 500f;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogError("Misisng a rigidbody");
    }

    public void AddForce()
    {
        rb.AddForce(Vector3.up * ForceAmount);
    }
}
