using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week4PooledBall : MonoBehaviour
{
    public float FreeIfBelow;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogError("Ball has no rigidbody? WHAT?!?!?");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < FreeIfBelow)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
}
