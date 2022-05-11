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
    private float minX_offset = 10;
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
        float minX = CurrentRoad.transform.position.x + minX_offset;
        float maxX = CurrentRoad.transform.position.x + maxX_offset;
        float minZ = CurrentRoad.transform.position.z + minZ_offset;
        float maxZ = CurrentRoad.transform.position.z + maxZ_offset;


        int RandomIndex = Random.Range(0, Collectables.Count);
        Vector3 RandomSpawnPos = new Vector3(Random.Range(minX + 20, maxX/2), 1.2f , Random.Range(minZ, maxZ));
        Instantiate(Collectables[RandomIndex], RandomSpawnPos, Quaternion.identity);


        RandomIndex = Random.Range(0, Collectables.Count);
        Vector3 RandomSpawnPos2 = new Vector3(RandomSpawnPos.x + Random.Range(minX_offset+ 20, maxX_offset - 20),
                                              RandomSpawnPos.y, RandomSpawnPos.z + Random.Range(minZ_offset/3, maxZ_offset / 3));
        Instantiate(Collectables[RandomIndex], RandomSpawnPos2, Quaternion.identity);


        RandomIndex = Random.Range(0, Collectables.Count);
        Vector3 RandomSpawnPos3 = new Vector3(RandomSpawnPos2.x + Random.Range(minX_offset + 20, maxX_offset - 20),
                                              RandomSpawnPos.y, RandomSpawnPos.z + Random.Range(minZ_offset / 3, maxZ_offset / 3));

        Instantiate(Collectables[RandomIndex], RandomSpawnPos3, Quaternion.identity);
    }

}
