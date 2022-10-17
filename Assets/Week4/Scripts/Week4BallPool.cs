using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week4BallPool : MonoBehaviour
{
    GameObject[] ballPool; // Lists are convenient, but arrays are faster
    public GameObject BallPrefab;
    public Transform StartPosition;
    public float BallInterval;
    public int poolSize = 15;

    float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        ballPool = new GameObject[poolSize]; // This only gets initiated on start. You would have to stop/play your game again to see any changes

        for (var i =0; i < poolSize; i++)
        {
            ballPool[i] = Instantiate(BallPrefab, StartPosition.position, StartPosition.rotation);
            ballPool[i].SetActive(false); // Be sure your new items start deactivated!
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > BallInterval)
        {
            timeElapsed = 0f;

            var poolEntry = FindAvailableBall();

            ballPool[poolEntry].transform.position = StartPosition.position;
            ballPool[poolEntry].transform.rotation = StartPosition.rotation;
            ballPool[poolEntry].SetActive(true);
        }
    }

    int FindAvailableBall()
    {
        for (var i = 0; i < poolSize; i++)
        {
            if (ballPool[i].activeInHierarchy == false) return i;
        }

        // Went through the whole pool? That's not supposed to happen
        // Some code will allocate more pool space or similar on the fly
        // For now, we'll just error out
        throw new System.Exception("Pool size too small!");
    }
}
