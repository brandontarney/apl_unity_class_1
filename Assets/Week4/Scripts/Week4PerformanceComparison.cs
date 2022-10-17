using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Week4PerformanceComparison : MonoBehaviour
{
    public GameObject createdBallPrefab;
    public GameObject pooledBallPrefab;
    public int poolSize;
    public bool usePooling;
    public float BallInterval;
    public float SpawnRange = 5f;
    public Text FPSReadout;

    Transform StartPosition;
    GameObject[] ballPool; // Lists are convenient, but arrays are faster
    float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform;

        ballPool = new GameObject[poolSize]; // This only gets initiated on start. You would have to stop/play your game again to see any changes

        for (var i = 0; i < poolSize; i++)
        {
            ballPool[i] = Instantiate(pooledBallPrefab, StartPosition.position + RandPosition(), StartPosition.rotation);
            ballPool[i].SetActive(false); // Be sure your new items start deactivated!
        }
    }

    Vector3 RandPosition()
    {
        return new Vector3(Random.Range(-SpawnRange, SpawnRange), Random.Range(-SpawnRange, SpawnRange), Random.Range(-SpawnRange, SpawnRange));
    }

    // Update is called once per frame
    // Since update is called once a frame, as the machine slows, and there are fewer frames, the number of balls also decreases
    // At some point, it will hit a relatively stable cycle
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > BallInterval)
        {
            timeElapsed = 0f;

            if (usePooling == false)
            {
                var newBall = Instantiate(createdBallPrefab, StartPosition.position + RandPosition(), StartPosition.rotation);
                var count = FindObjectsOfType<Week4Ball>().Length;
                FPSReadout.text = Mathf.RoundToInt(1f / Time.deltaTime) + " FPS with " + count + " objects";
            }
            else
            {
                var poolEntry = FindAvailableBall();

                ballPool[poolEntry].transform.position = StartPosition.position + RandPosition();
                ballPool[poolEntry].transform.rotation = StartPosition.rotation;
                ballPool[poolEntry].SetActive(true);
                var count = FindObjectsOfType<Week4PooledBall>().Length;
                FPSReadout.text = Mathf.RoundToInt(1f / Time.deltaTime) + " FPS with " + count + " objects";
            }
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
