using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week7Cannon : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public float InitialForce = 500f;
    public KeyCode FireKey;
    public float Elevation;
    public GameObject TargetObject;
    public float Cooldown = 2f;

    bool inCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        if (ProjectilePrefab == null)
        {
            Debug.LogError("Projectile is null?");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(FireKey))
        {
            Fire();
        }

        // Clear out lingering targets
        if (TargetObject != null && TargetObject.activeInHierarchy == false) TargetObject = null;

        // If there is a target, turn and shoot! -- This could be WAY smarter!
        if (TargetObject != null)
        {
            var startRot = transform.rotation;
            transform.LookAt(TargetObject.transform);
            var endRot = transform.rotation;

            var rotQuat = Quaternion.Slerp(startRot, endRot, 0.05f);
            transform.rotation = Quaternion.Euler(new Vector3(Elevation, rotQuat.eulerAngles.y, 0f));

            var enableFire = false;
            var dp = Vector3.Dot(transform.forward.normalized, (TargetObject.transform.position - transform.position).normalized);
            if (dp > 0.92f) enableFire = true; // We'll talk more about dot products in week 8

            if (inCooldown == false && enableFire) Fire();
        }
    }

    // This tells the gun to decline firing
    // Waits for a given time
    // And then allows firing again
    IEnumerator CooldownCo(float cooldownTimeSeconds)
    {
        inCooldown = true;

        yield return new WaitForSeconds(cooldownTimeSeconds);

        inCooldown = false;
    }

    public void Fire()
    {
        // If we are in cooldown, do not fire, regardless of what we want
        if (inCooldown == true) return;

        // transform.forward is the world-space direction the object is facing, normalized to 1m out.
        // transform.position + transform.forward * 0.1f places an object at the current location, and then slightly in front of the gameObject
        var bullet = Instantiate(ProjectilePrefab, transform.position + (transform.forward * 0.1f), transform.rotation);
        var rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.forward * InitialForce); // Add a lot of force in the forward direction
        }
        else
        {
            Debug.LogError("Projectile missing rigidBody");
        }

        StartCoroutine(CooldownCo(2f));
    }
}
