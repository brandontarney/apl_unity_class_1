using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week8ParentChild : MonoBehaviour
{
    public GameObject OtherGameObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (OtherGameObject.transform.parent == transform)
            {
                OtherGameObject.transform.SetParent(null);
            }
            else
            {
                OtherGameObject.transform.SetParent(transform);
            }
        }
    }
}
