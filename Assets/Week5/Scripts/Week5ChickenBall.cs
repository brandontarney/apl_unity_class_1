using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week5ChickenBall : MonoBehaviour
{
    public float chickenForce = 10f;
    Week5GameManager gameManager;
    Rigidbody rb;

    private void Awake()
    {
        gameManager = FindObjectOfType<Week5GameManager>();
        if (gameManager == null) Debug.LogError("Game Manager is missing!");

        rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogError("My rigidbody is null???");
    }

    // We hit something!
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Fox"))
        {
            gameObject.SetActive(false); // If we destroy, then GameManager's list can get messed up
        }
    }

    void FixedUpdate()
    {
        if (gameManager && rb)
        {
            var closestDist = float.MaxValue;
            Week5FoxBall closestFox = null;

            // Find the closest fox
            foreach (var f in gameManager.Foxes)
            {
                var dist = Vector3.Distance(transform.position, f.transform.position);
                if (dist < closestDist && f.gameObject.activeInHierarchy)  // Is this fox active?
                {
                    closestFox = f;
                    closestDist = dist;
                }
            }

            if (closestFox != null)
            {
                var dir = transform.position - closestFox.transform.position;
                dir.y = 0f; // Cancel out Y movement
                dir = dir.normalized; // Normalize the vector

                rb.AddForce(dir.normalized * chickenForce);
            }
        }
    }
}
