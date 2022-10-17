using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week4BallCreator : MonoBehaviour
{
    public GameObject BallPrefab;
    public Transform StartPosition;
    public float BallInterval;

    float timeElapsed = 0f;

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > BallInterval)
        {
            timeElapsed = 0f;

            var newBall = Instantiate(BallPrefab, StartPosition.position, StartPosition.rotation);
        }
    }
}
