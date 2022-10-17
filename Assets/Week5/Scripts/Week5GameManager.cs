using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week5GameManager : MonoBehaviour
{
    public GameObject ChickenPrefab;
    public GameObject FoxPrefab;

    public List<Week5ChickenBall> Chickens;
    public List<Week5FoxBall> Foxes;

    public GameObject ChickenHolder;
    public GameObject FoxHolder;

    public float range = 10f;

    public int numChickens;
    public int numFoxes;

    private void Awake()
    {
        if (ChickenPrefab == null || FoxPrefab == null || ChickenHolder == null || FoxHolder == null)
        {
            Debug.LogError("Essential GameObject not defined!");
        }
    }

    private void Start()
    {
        // If we have a Chicken prefab, create them
        if (ChickenPrefab)
        {
            for (var i = 0; i < numChickens; i++)
            {
                var chickenBall = Instantiate(ChickenPrefab, transform.position + RandPosition(range), Quaternion.identity);
                chickenBall.transform.SetParent(ChickenHolder.transform); // Organize your chickens!
                
                var chickenScript = chickenBall.GetComponent<Week5ChickenBall>();
                if (chickenScript != null) // It might be missing from the prefab!
                {
                    Chickens.Add(chickenScript);
                }
                else
                {
                    Debug.LogError("Chicken without a chicken script?");
                }
            }
        }
        else
        {
            Debug.LogError("Chicken prefab missing?");
        }

        // Check to make sure we know what a fox GO is
        if (FoxPrefab)
        {
            for (var i = 0; i < numFoxes; i++)
            {
                var foxBall = Instantiate(FoxPrefab, transform.position + RandPosition(range), Quaternion.identity);
                foxBall.transform.SetParent(FoxHolder.transform); // Organize your foxes!

                var foxScript = foxBall.GetComponent<Week5FoxBall>();
                if (foxScript != null) // It might be missing from the prefab!
                {
                    Foxes.Add(foxScript);
                }
                else
                {
                    Debug.LogError("Chicken without a chicken script?");
                }
            }
        }
        else
        {
            Debug.LogError("Fox prefab missing?");
        }
    }

    static Vector3 RandPosition(float SpawnRange)
    {
        return new Vector3(Random.Range(-SpawnRange, SpawnRange), 0.45f, Random.Range(-SpawnRange, SpawnRange));
    }
}
