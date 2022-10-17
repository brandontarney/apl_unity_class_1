using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week2MoveKinematic : MonoBehaviour
{
    public KeyCode positiveZ = KeyCode.UpArrow; // This is the default, you can override these in the inspector
    public KeyCode negativeZ = KeyCode.DownArrow;
    public KeyCode positiveX = KeyCode.RightArrow;
    public KeyCode negativeX = KeyCode.LeftArrow;
    public float speed = 1;

    Rigidbody rb;

    private void Awake()
    {
        // Self-init, with own components
        // Other GameObjects might not exist yet
        rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogError("RigidBody is missing");
    }

    // Start is called before the first frame update
    void Start()
    {
        // Other GameObjects should exist (unless dynamically created), and should have been through their awake
        if (speed == 0)
        {
            Debug.LogWarning("Speed is 0? Doesn't make sense, defaulting to 1");
            speed = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // This happens a lot, do not search for other objects in update or FixedUpdate
        var movementVector = Vector3.zero;

        if (Input.GetKey(positiveZ))
        {
            movementVector.z += speed;
        }

        if (Input.GetKey(negativeZ))
        {
            movementVector.z -= speed;
        }

        if (Input.GetKey(positiveX))
        {
            movementVector.x += speed;
        }

        if (Input.GetKey(negativeX))
        {
            movementVector.x -= speed;
        }

        rb.MovePosition(transform.position + movementVector);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bonk!");
    }

    private void FixedUpdate()
    {
        // In this case, we are using keyboard control of the player
        // So we've taken control and are not using fixed update
        // Week2ConstantForce has an example with FixedUpdate
    }
}
