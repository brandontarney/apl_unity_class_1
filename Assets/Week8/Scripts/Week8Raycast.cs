using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week8Raycast : MonoBehaviour
{
    // Update is called once per frame
    // Debug.DrawRay will only be visible in shte scene window, not in the game
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.DrawRay(transform.position, hit.point - transform.position, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.white);
        }
    }
}
