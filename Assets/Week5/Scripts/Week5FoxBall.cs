using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week5FoxBall : MonoBehaviour
{
    public float foxForce = 10f;
    Week5GameManager gameManager;
    Rigidbody rb;

    private void Awake()
    {
        gameManager = FindObjectOfType<Week5GameManager>();
        if (gameManager == null) Debug.LogError("Game Manager is missing!");

        rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogError("My rigidbody is null???");
    }

    void FixedUpdate()
    {
        if (gameManager && rb)
        {
            var closestDist = float.MaxValue;
            Week5ChickenBall closestChicken = null;

            // Find the closest fox
            foreach (var c in gameManager.Chickens)
            {
                var dist = Vector3.Distance(transform.position, c.transform.position);
                if (dist < closestDist && c.gameObject.activeInHierarchy) // Is this chicken active?
                {
                    closestChicken = c;
                    closestDist = dist;
                }
            }

            if (closestChicken != null) // Super important if we eat all the chickens
            {
                var dir = closestChicken.transform.position - transform.position;
                dir.y = 0f; // Cancel out Y movement
                dir = dir.normalized; // Normalize the vector

                rb.AddForce(dir.normalized * foxForce);
            }
        }
    }
}
