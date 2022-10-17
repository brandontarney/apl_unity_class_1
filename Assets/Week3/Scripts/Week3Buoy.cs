using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week3Buoy : MonoBehaviour
{
    /*
     * For now this will become a dumb buoy controlled by game manager
    public Vector3 worldCenter;
    public float distanceFromCenter = 3;

    Week3Boat boat;

    private void Start()
    {
        var boats = FindObjectsOfType<Week3Boat>();
        if (boats.Length != 1)
        {
            Debug.LogError("Multiple boats? No boats?");
        }

        boat = boats[0];

        Reset(); // Reset needs a boat, so it has to happen in Start!
    }



    private void Reset()
    {
        transform.position = worldCenter + new Vector3(Random.Range(-distanceFromCenter, distanceFromCenter), 0, Random.Range(-distanceFromCenter, distanceFromCenter));

        if (Vector3.Distance(boat.transform.position, transform.position) < 2)
        {
            Debug.Log("Tried to spawn too close... trying again!");
            Reset();
        }

    }

            */


    private void OnTriggerEnter(Collider other)
    {
        //Blank me out!
        gameObject.SetActive(false);

    }
}
