using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    public Vector3 worldCenter;
    public float distanceFromCenter = 7; //Slightly less than half the wdith of the world/water/sandbox


    public int numBuoy = 5;
    public GameObject buoy;
    public GameObject boat;


    public List<GameObject> myBuoys;
    //private GameObject mybuoy;
    private GameObject myBoat;


    // Start is called before the first frame update
    void Start()
    {
        // Create the boat (first - so you can ensure it doesn't conflict w/ buoy)
        myBoat = Instantiate(original: boat);

        //Create a Buoys
        for (int idx = 0; idx < numBuoy; idx++)
        { 
            GameObject newBuoy = Instantiate(original: buoy);
            Debug.Log(newBuoy.transform);
            moveBuoy(newBuoy);
            Debug.Log(newBuoy.transform);
            myBuoys.Add(newBuoy);
        }

        var myBoatComponent = myBoat.GetComponent<Week3Boat>();
        myBoatComponent.targets = myBuoys;

    }


    private void moveBuoy(GameObject buoy)
    {

        buoy.transform.position = worldCenter + new Vector3(
            Random.Range(-distanceFromCenter, distanceFromCenter), 0, Random.Range(-distanceFromCenter, distanceFromCenter));

        //Check it's not near the boat
        if (Vector3.Distance(myBoat.transform.position, buoy.transform.position) < 2)
        {
            Debug.Log("Tried to spawn too close... trying again!");
            moveBuoy(buoy);
        }

        
        //Check it's not near other buoys
        foreach (var existingBuoy in myBuoys)
        {
            if (Vector3.Distance(myBoat.transform.position, transform.position) < 2)
            {
                Debug.Log("Tried to spawn too close... trying again!");
                moveBuoy(buoy);
            }
        }
        

        // TODO: Check to ensure this doesn't recurse forever! (e.g. if there are many buoy's)
    }

    /*
    // Update is called once per frame
    void Update()
    {
        if (mybuoy.activeSelf)
        {
            //Do nothing - ball hasn't been found yet
        }
        else
        {
            movebuoy();
            mybuoy.SetActive(true);
        }


    }
    */
}
