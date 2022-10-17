using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Week7Boat : MonoBehaviour
{
    public float Speed = 1f;
    public float SinkTime = 1f;
    public float SpawnMin = 8f;
    public float SpawnMax = 9f;

    public UnityEvent OnStart;
    public Week7GameObjectEvent OnSink;
    public UnityEvent OnSinkComplete;

    GameObject myTarget;

    private void Start()
    {
        Reset();
    }

    public void Reset()
    {
        var distance = Random.Range(SpawnMin, SpawnMax);
        var angle = Random.Range(0f, Mathf.PI * 2f);
        transform.position = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle)) * distance;

        if (OnStart != null) OnStart.Invoke();
    }

    // Turn toward and move toward my target
    private void Update()
    {
        if (myTarget != null)
        {
            transform.LookAt(myTarget.transform.position); // Instant turn
            transform.Translate(Vector3.forward * Time.deltaTime * Speed, Space.Self);
        }
    }

    // What do do on collision
    private void OnCollisionEnter(Collision collision)
    {
        if (OnSink != null) OnSink.Invoke(gameObject);
    }

    // Set my target
    public void SetTarget(GameObject targetObject)
    {
        myTarget = targetObject;
    }


    public void SinkShip()
    {
        StartCoroutine(SinkCo(SinkTime));
    }

    IEnumerator SinkCo(float sinkTime)
    {
        var startPos = transform.position;
        var endPos = transform.position + new Vector3(0f, -2f, 0f);

        var startRot = transform.rotation;
        var endRot = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Random.Range(70, 110));

        var elapsed = 0f;

        while (elapsed < sinkTime)
        {
            var ratio = elapsed / sinkTime; // How far into the sinking are we?
            transform.position = Vector3.Lerp(startPos, endPos, ratio);
            transform.rotation = Quaternion.Slerp(startRot, endRot, ratio);
            elapsed += Time.deltaTime; // Don't forget this, or you never exit the loop
            yield return null;
        }

        if (OnSinkComplete != null) OnSinkComplete.Invoke();
    }
}
