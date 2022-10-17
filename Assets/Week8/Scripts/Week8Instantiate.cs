using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week8Instantiate : MonoBehaviour
{
    public GameObject ThingToSpawnPrefab;

    GameObject myThing;

    // Start is called before the first frame update
    void Start()
    {
        if (ThingToSpawnPrefab != null)
        {
            myThing = Instantiate(ThingToSpawnPrefab);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && myThing != null)
        {
            Destroy(myThing);
        }
    }
}
