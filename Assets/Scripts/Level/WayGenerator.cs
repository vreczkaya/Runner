using System.Collections.Generic;
using UnityEngine;

public class WayGenerator : MonoBehaviour
{
    public List<WayPrefab> wayElements;
    public Transform generationPoint;
    private float zSpawnPosition;

    float levelLenghth;
    float blockLenghth;

    void Start()
    {
        levelLenghth = WayPrefab.GetWayPrefabLenghth();
        blockLenghth = 180;

        for (int i = 0; i < wayElements.Count; i++)
        {
            wayElements[i] = Instantiate(wayElements[i]);
            wayElements[i].gameObject.SetActive(false);
        }

        zSpawnPosition = transform.position.z - 30;

        GetWayPrefab(wayElements).transform.position = new Vector3(0f, 0f, zSpawnPosition);
        zSpawnPosition += 180;
        GetWayPrefab(wayElements).transform.position = new Vector3(0f, 0f, zSpawnPosition);
        zSpawnPosition += 180;
    }

    private WayPrefab GetWayPrefab(List<WayPrefab> wayElements)
    {
        for (int i = 0; i < wayElements.Count; i++)
        {
            if (!wayElements[i].gameObject.activeInHierarchy)
            {
                wayElements[i].gameObject.SetActive(true);
                return wayElements[i];
            }
        }
        int k = Random.Range(0, wayElements.Count);
        wayElements.Add(this.wayElements[k]);
        return Instantiate(wayElements[wayElements.Count - 1]);
    }

    void Update()
    {
        if (transform.position.z < generationPoint.position.z)
        {
            transform.position = new Vector3(0f, transform.position.y, transform.position.z + blockLenghth);
            GetWayPrefab(wayElements).transform.position = new Vector3(0f, 0f, zSpawnPosition);
            zSpawnPosition += 180;
        }
    }
}
