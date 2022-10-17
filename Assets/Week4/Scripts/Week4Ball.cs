using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week4Ball : MonoBehaviour
{
    public float DestroyIfBelow;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < DestroyIfBelow)
        {
            Destroy(gameObject);
        }
    }
}
