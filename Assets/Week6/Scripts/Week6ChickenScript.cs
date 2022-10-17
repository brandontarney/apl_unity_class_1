using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week6ChickenScript : MonoBehaviour
{
    public float chickenForce = 10f;
    Week6GameManager gameManager;
    Rigidbody rb;

    private void Awake()
    {
        gameManager = FindObjectOfType<Week6GameManager>();
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
            Week6Repulsor closestRepulsor = null;

            // Find the closest fox
            foreach (var r in gameManager.Repulsors)
            {
                var dist = Vector3.Distance(transform.position, r.transform.position);
                if (dist < closestDist && r.gameObject.activeInHierarchy)  // Is this fox active?
                {
                    closestRepulsor = r;
                    closestDist = dist;
                }
            }

            if (closestRepulsor != null)
            {
                var dir = transform.position - closestRepulsor.transform.position;
                dir.y = 0f; // Cancel out Y movement
                dir = dir.normalized; // Normalize the vector

                rb.AddForce(dir.normalized * chickenForce);
            }
        }
    }
}
