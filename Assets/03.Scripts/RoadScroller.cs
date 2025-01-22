using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScroller : MonoBehaviour
{
    public GameObject road1; 
    public GameObject road2;
    public float scrollSpeed = 5f; 
    float roadHeight = 10f; 
    
    public GameObject gasPrefab;
    float minGasSpawn = 1;
    float maxGasSpawn = 5;

    void Update()
    {
        ScrollRoad(road1, road2);
        ScrollRoad(road2, road1);
    }

    void ScrollRoad(GameObject road, GameObject otherRoad)
    {
        road.transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
        
        if (road.transform.position.y < -roadHeight)
        {
            road.transform.position = new Vector3(road.transform.position.x, otherRoad.transform.position.y + roadHeight, road.transform.position.z);
        }
    }
}
