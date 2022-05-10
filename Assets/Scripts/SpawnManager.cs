using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    RoadSpawner roadSpawner;
    int removeroad_Timer = 2;

    // Start is called before the first frame update
    void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();
    }


    public void SpawnTriggerEnter()
    {

        roadSpawner.MoveRoad();
    }
}

