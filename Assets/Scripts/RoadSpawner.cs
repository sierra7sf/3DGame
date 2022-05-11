using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    //list of roads being cycled through and the offset at which to spawn them
    public List<GameObject> roads;
    public List<GameObject> Collectables;
    private float offset = 110f;

    //ObjectSpawnBox offsets
    private float minX_offset = 30;
    private float maxX_offset = 105;
    private float minZ_offset = -9.8f;
    private float maxZ_offset = 1.5f;

    //reorders the roads if in the wrong possition
    void Start()
    {
        if(roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(roads => roads.transform.position.x).ToList();
        }
    }


    public void MoveRoad()
    {
        GameObject MovedRoad = roads[0];
        roads.Remove(MovedRoad);
        float newx = roads[roads.Count - 1].transform.position.x + offset;
        MovedRoad.transform.position = new Vector3(newx, 0, 0);
        roads.Add(MovedRoad);
    }

    public void SpawnObject()
    {
        Debug.Log("Object spawned");

        GameObject CurrentRoad = roads[0];
        float curX = CurrentRoad.transform.position.x;
        //float maxX = CurrentRoad.transform.position.x + maxX_offset;
        float curZ = CurrentRoad.transform.position.z;
        //float maxZ = CurrentRoad.transform.position.z + maxZ_offset;
        //Debug.Log(CurrentRoad.transform.position.x);
        //Debug.Log(maxX);maxX



        int RandomIndex = Random.Range(0, Collectables.Count);
        Vector3 RandomSpawnPos = new Vector3(curX + Random.Range(10, 30), 1.2f, curZ + Random.Range(-2,2));
        Debug.Log(RandomSpawnPos.x);

        Instantiate(Collectables[RandomIndex], RandomSpawnPos, Quaternion.identity);


        RandomIndex = Random.Range(0, Collectables.Count);
        Vector3 RandomSpawnPos2 = new Vector3(RandomSpawnPos.x + Random.Range(20, 30),
                                              RandomSpawnPos.y, RandomSpawnPos.z + Random.Range(-2, 2));
        Instantiate(Collectables[RandomIndex], RandomSpawnPos2, Quaternion.identity);


        RandomIndex = Random.Range(0, Collectables.Count);
        Vector3 RandomSpawnPos3 = new Vector3(RandomSpawnPos2.x + Random.Range(20, 30),
                                              RandomSpawnPos2.y, RandomSpawnPos.z + Random.Range(-2, 2));

        Instantiate(Collectables[RandomIndex], RandomSpawnPos3, Quaternion.identity);
    }

}
