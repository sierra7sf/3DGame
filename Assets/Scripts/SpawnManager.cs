using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    RoadSpawner roadSpawner;
    bool spawnRoadTrigger = false;
    bool spawnObjectTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();
    }

    public void SpawnRoadTriggerEnter()
    {
        if (spawnRoadTrigger == false)
        {
            StartCoroutine(RoadTriggerTimer());
            roadSpawner.MoveRoad();
        }
     
    }

    public void SpawnObjectsTriggerEnter()
    {

        if (spawnObjectTrigger == false)
        {
            StartCoroutine(ObjectTriggerTimer());
            roadSpawner.SpawnObject();
        }
    }

    IEnumerator RoadTriggerTimer()
    {
        spawnRoadTrigger = true;
        yield return new WaitForSeconds(1);
        spawnRoadTrigger = false;
    }

    IEnumerator ObjectTriggerTimer()
    {
        spawnObjectTrigger = true;
        yield return new WaitForSeconds(1);
        spawnObjectTrigger = false;
    }

}

