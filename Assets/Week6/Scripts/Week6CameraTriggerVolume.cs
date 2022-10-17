using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week6CameraTriggerVolume : MonoBehaviour
{
    public Vector3 CameraTargetPosition;

    Week6GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<Week6GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found?");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fox"))
        {
            gameManager.SetCameraPosition(CameraTargetPosition);
        }
    }
}
