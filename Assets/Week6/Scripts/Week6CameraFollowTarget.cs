using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week6CameraFollowTarget : MonoBehaviour
{
    public GameObject WatchTarget;
    public Vector3 TargetPosition;

    float closeEnough = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        TargetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (WatchTarget != null)
        {
            transform.LookAt(WatchTarget.transform);
        }

        // Interpolate between two positions
        // Note, in this case the "start" moves with the gameObject, which provides
        // a deceleration
        if (Vector3.Distance(TargetPosition, transform.position) > closeEnough)
        {
            transform.position = Vector3.Lerp(transform.position, TargetPosition, 0.01f);
        }
    }
}
