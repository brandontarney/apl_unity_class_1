using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week8Coroutine : MonoBehaviour
{
    public Vector3 From;
    public Vector3 To;
    public float TransitionTime = 1f; // Default to 1 second

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveCo(From, To, TransitionTime));

    }

    IEnumerator MoveCo(Vector3 fromLocation, Vector3 toLocation, float duration)
    {
        var elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            transform.position = Vector3.Lerp(fromLocation, toLocation, elapsed / duration); // Linear interpolation

            yield return null;
        }

        // Finally, make sure we end right on the target location
        transform.position = toLocation;
    }
}
