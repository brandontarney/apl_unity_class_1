using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week6FoxBall : Week6Repulsor
{
    /*
     * 
     *  Note that this class inherits from the Repulsor class, so it will be found with other chicken repulsors.
     * 
     * */


    public float foxForce = 10f;
    Week6GameManager gameManager;
    Rigidbody rb;

    Vector3 wanderTarget;
    float closeEnough = 1f;
    float wanderTime = 0f;
    float wanderTimeLimit = 3f;

    bool wasFollowing = false;

    private void Awake()
    {
        gameManager = FindObjectOfType<Week6GameManager>();
        if (gameManager == null) Debug.LogError("Game Manager is missing!");

        rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogError("My rigidbody is null???");
    }

    private void Start()
    {
        SetWanderTarget();
    }

    void FixedUpdate()
    {
        if (gameManager && rb)
        {
            var closestDist = float.MaxValue;
            Week6ChickenScript closestChicken = null;

            List<float> distances = new List<float>();
            // Find the closest fox
            foreach (var c in gameManager.Chickens)
            {
                distances.Add(Vector3.Distance(transform.position, c.transform.position));
                // Only process for active chickens
                if (c.gameObject.activeInHierarchy)
                {
                    // Does the fox have a line-of-sight to the chicken?
                    RaycastHit rayHitInfo;

                    LayerMask mask = ~LayerMask.GetMask("Triggers", "Glass"); // The ray looks at all layers EXCEPT triggers, and it looks through glass
                    
                    if (Physics.Raycast(transform.position, c.transform.position - transform.position, out rayHitInfo, Mathf.Infinity, mask) && rayHitInfo.collider.CompareTag("Chicken"))
                    {
                        // Draw a yellow line in debug to show you saw a chicken
                        Debug.DrawRay(transform.position, rayHitInfo.point - transform.position, Color.yellow);

                        var dist = Vector3.Distance(transform.position, c.transform.position);
                        if (dist < closestDist && c.gameObject.activeInHierarchy) // Is this chicken active?
                        {
                            closestChicken = c;
                            closestDist = dist;
                        }
                    }
                    else
                    {
                        // Draw a white line to show the attempt and failure
                        Debug.DrawRay(transform.position, rayHitInfo.point - transform.position, Color.white);
                    }
                }
            }

            // If there is a chicken, chase it
            if (closestChicken != null) // Super important if we eat all the chickens, or can't see them
            {
                wanderTime = 0f;
                var dir = closestChicken.transform.position - transform.position;
                dir.y = 0f; // Cancel out Y movement
                dir = dir.normalized; // Normalize the vector

                rb.AddForce(dir.normalized * foxForce);
                Debug.DrawRay(transform.position, (closestChicken.transform.position - transform.position), Color.red);
                wasFollowing = true;
            } 
            else // Otherwise, meander
            {
                if (wasFollowing == true)
                {
                    Debug.Log("Change");
                }
                wasFollowing = false;

                if (Vector3.Distance(transform.position, wanderTarget) > closeEnough && wanderTime < wanderTimeLimit)
                {
                    wanderTime += Time.fixedDeltaTime;
                    var dir = wanderTarget - transform.position;
                    dir.y = 0f; // Cancel out Y movement
                    dir = dir.normalized; // Normalize the vector

                    rb.AddForce(dir.normalized * foxForce);
                    Debug.DrawRay(transform.position, (wanderTarget - transform.position), Color.blue);
                } else
                {
                    SetWanderTarget();
                }
            }

            
        }
    }

    private void SetWanderTarget()
    {
        wanderTime = 0f;
        var randPos = Week6GameManager.RandPosition(5f);
        randPos.Scale(new Vector3(1f, 0f, 1f)); // Get rid of the y component
        wanderTarget = transform.position + randPos;
    }
}
