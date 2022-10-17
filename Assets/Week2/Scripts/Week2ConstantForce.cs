using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week2ConstantForce : MonoBehaviour
{
    public Vector3 ForceToApply;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Find the rigidbody of this object
        if (rb == null)
        {
            Debug.LogError("RigidBody not found!"); // Ooooooops?
        }
    }

    private void FixedUpdate() // Happens at a very fixed frequency, for physics stuff!
    {
        rb.AddForce(ForceToApply * Time.fixedDeltaTime);
    }
}
