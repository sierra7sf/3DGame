using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    RoadSpawner roadSpawner;

    // Start is called before the first frame update
    void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();
    }

    public void SpawnRoadTriggerEnter()
    {
        roadSpawner.MoveRoad();
    }

    public void SpawnObjectsTriggerEnter()
    {
        roadSpawner.SpawnObject();
    }
}

