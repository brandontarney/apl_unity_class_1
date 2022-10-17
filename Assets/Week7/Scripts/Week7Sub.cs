using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week7Sub : MonoBehaviour
{
    public List<Week7Cannon> cannons;

    Queue<GameObject> targetsToAssign;
    List<GameObject> targetHistory;

    private void Awake()
    {
        targetsToAssign = new Queue<GameObject>();
    }

    private void Update()
    {
        foreach (var c in cannons)
        {
            if (c.TargetObject == null && targetsToAssign.Count > 0)
            {
                c.TargetObject = targetsToAssign.Dequeue(); // Get the next thing to kill
            }
        }
    }


    // Assign the threat to a cannon
    public void KillThreat(GameObject threat)
    {
        // Something has entered. Let's see if it has a boat component
        var bc = threat.GetComponent<Week7Boat>();
        if (bc == null) return; // Not a boat, ignore it

        // If we alreay have this target queued, don't re-queue it
        if (targetsToAssign.Contains(threat) == false)
        {
            var addItem = true;

            // Check to make sure no cannons are targeting it
            foreach (var c in cannons)
            {
                if (c.TargetObject == threat)
                {
                    addItem = false;
                }
            }

            // Nobody targeting it? Great! Add it to the list
            if (addItem) {
                targetsToAssign.Enqueue(threat);
            }
        }
    }

    public void ClearThreat(GameObject threat)
    {
        foreach (var c in cannons)
        {
            if (c.TargetObject == threat) c.TargetObject = null;
        }
    }
}
