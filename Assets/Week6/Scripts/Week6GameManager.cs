using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Week6GameManager : MonoBehaviour
{
    public GameObject ChickenPrefab;
    public List<Week6ChickenScript> Chickens;
    public List<Week6Repulsor> Repulsors;
    public GameObject ChickenHolder;
    public Week6FoxBall Fox;
    public float range = 9.5f;
    public int numChickens;
    public Week6CameraFollowTarget FollowScript;

    private void Awake()
    {
        if (ChickenPrefab == null || FollowScript == null || ChickenHolder == null)
        {
            Debug.LogError("Essential GameObject not defined!");
        }
    }

    public void SetCameraPosition(Vector3 position)
    {
        if (FollowScript)
        {
            FollowScript.TargetPosition = position;
        }
    }

    private void Start()
    {
        Repulsors = FindObjectsOfType<Week6Repulsor>().ToList(); // Will get both repulsors, and anything descended from it;

        if (FollowScript != null && Fox != null)
        {
            FollowScript.WatchTarget = Fox.gameObject;
        }
        else
        {
            Debug.LogError("Something key is misisng here");
        }

        // If we have a Chicken prefab, create them
        if (ChickenPrefab)
        {
            for (var i = 0; i < numChickens; i++)
            {
                var chickenBall = Instantiate(ChickenPrefab, transform.position + RandPosition(range), Quaternion.identity);
                chickenBall.transform.SetParent(ChickenHolder.transform); // Organize your chickens!

                var chickenScript = chickenBall.GetComponent<Week6ChickenScript>();
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
    }

    public static Vector3 RandPosition(float SpawnRange)
    {
        return new Vector3(Random.Range(-SpawnRange, SpawnRange), 0.45f, Random.Range(-SpawnRange, SpawnRange));
    }
}
