using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{

    public List<GameObject> roads;
    private float offset = 110f;

    // Start is called before the first frame update
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
  
}
