using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week3Boat : MonoBehaviour
{
    public List<GameObject> targets;
    public int targetIdx = 0; //public so the buoy's can increase it!

    public float speed = 1;
    public float turnSpeed = 1;

    /*

    private void Awake()
    {
        // Internal init goes here
    }

    void Start()
    {
        // Find the buoy here, and cache it. No searching in update!
        var targets = FindObjectsOfType<Week3buoy>();
        if (targets.Length != 1)
        {
            Debug.LogError("No, or more than, one buoy");
        }

        target = targets[0];
    }
    */

    /*
     * Handle collisions at the buoy ... it's easier if not a bit hacky feeling
    private void OnTriggerEnter(Collider other)
    {
        //Ensure you collided with a buoy
        if (other.GetType() == typeof(SphereCollider))
        {
            Debug.Log("Collided with a buoy");
            targets[targetIdx].gameObject.SetActive(false);
            getNextTarget = true;
        }
        else
        {
            Debug.Log("Collided with non-buoy");
        }

    }
    */

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, targets[targetIdx].transform.position) < 1)
        {
            targetIdx++;
        }

        if (targetIdx < targets.Count)
        {
            // Rotate toward the buoy. Time for some quaternion math, without having to actually learn quaternions!
            var startRotation = transform.rotation;
            transform.LookAt(targets[targetIdx].transform);
            var endRotation = transform.rotation;

            // Now, do a spherical interpolation between the two rotations, 10% each frame
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, turnSpeed);

            transform.Translate(Vector3.forward * speed * Time.deltaTime); // Translate in local forward (+z) by a standard amount
        }
        else
        {
            //Blank me out!
            gameObject.SetActive(false);
        }
        
    }
}
