using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week7Projectile : MonoBehaviour
{
    public float minHeight = 0f;

    float startTime;
    Rigidbody rb;

    private void Start()
    {
        startTime = Time.realtimeSinceStartup;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minHeight)
        {
            //Debug.Log($"Flight time: { Time.realtimeSinceStartup - startTime } ending at velocity {rb.velocity.magnitude}");
            Destroy(gameObject);
        }
    }
}
