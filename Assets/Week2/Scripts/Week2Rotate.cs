using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week2Rotate : MonoBehaviour
{
    public Vector3 RotationSpeed; // Degrees per second

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(RotationSpeed * Time.deltaTime); // Time.deltaTime = number of seconds since last Update
    }
}
