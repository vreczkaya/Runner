using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPrefab : MonoBehaviour
{
    private static float wayPrefabLength; //придумать, как получить длину префаба пути из системы
    private float zPosition = 0;
    private int xPosition = 0;
    private int yPosition = 0;
    public GameObject destroyPoint;


    void Start() 
    {
        zPosition = this.transform.position.z;
        destroyPoint = GameObject.Find("Destroy Point");
        wayPrefabLength = 30;
    }

    void Update()
    {
        if (this.transform.position.z < destroyPoint.transform.position.z)
        {
            this.gameObject.SetActive(false);
        }
    }

    public static float GetWayPrefabLenghth()
    {
        return wayPrefabLength;
    }

    public float GetZPosition()
    {
        return zPosition;
    }

    public void SetZPosition(int zPosition)
    {
        this.zPosition = zPosition;
    }

    public int GetXPosition()
    {
        return xPosition;
    }

    public int GetYPosition()
    {
        return yPosition;
    }
}
