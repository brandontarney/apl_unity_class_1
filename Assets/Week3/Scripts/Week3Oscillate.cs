using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week3Oscillate : MonoBehaviour
{
    public float movementAmplitude;
    public float frequency;

    float startPosition;
    float angle; // Uses a sin to create oscilating values... note, all three position axes use one angle/frequency, so they are all locked at the same frequency

    float twoPi;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.y;
        twoPi = Mathf.PI * 2f; // pre-calculate and store this
    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime * frequency * twoPi; // Two pi radians / sec
        transform.position = new Vector3(transform.position.x, startPosition + (movementAmplitude * Mathf.Sin(angle)), transform.position.z);
    }
}
