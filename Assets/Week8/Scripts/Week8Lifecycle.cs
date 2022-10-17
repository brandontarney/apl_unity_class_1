using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week8Lifecycle : MonoBehaviour
{
    public float RotationSpeed = 10f; // Class default, provides an initial value for the inspector window

    // After this, a value in a prefab or in the inspector would take over

    // Awake happens before Start. Awake might be called before other GameObjects are create
    // and as such, should only be used for internal updates
    private void Awake()
    {
        RotationSpeed = 20f;
    }

    // Start is called before the first frame update, but after Awake
    void Start()
    {
        RotationSpeed = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, RotationSpeed * Time.deltaTime, 0f);
    }

    // FixedUpdate is called at a fixed time interval, for things like physics
    private void FixedUpdate()
    {
        // Not doing a debug message here, as it would fill the debug log FAST and chew up a TON of memory!
    }


    /* 
     * Below are some of the most common lifecycle events.
     * There are WAY more possible, these are just the ones used most frequently
     * See the Unity documentation for details
     */


    // When this hits, or is hit by, something. One of the two objects needs to have a RigidBody!
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bonk");
    }

    // If you want a trigger instead of a collision, see the ExampleTrigger scene

    // Do this when the GameObject is destroyed
    private void OnDestroy()
    {
        Debug.Log("G'Bye");
    }
}
