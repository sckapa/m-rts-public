using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    public GameObject[] wayPoints;
    public GameObject[] bridgeWayPoint;
    int _currentWayPointIndex = 0;
    public float wayPointSpeed = 2f;

    public void Start()
    {
        float i, j, k;
        i = Vector3.Distance(transform.position, bridgeWayPoint[0].transform.position);
        j = Vector3.Distance(transform.position, bridgeWayPoint[1].transform.position);
        k = Vector3.Distance(transform.position, bridgeWayPoint[2].transform.position);

        if (i < j && i < k)
        {
            wayPoints[0] = bridgeWayPoint[0];
            wayPoints[1] = bridgeWayPoint[0].transform.GetChild(0).gameObject;
        }
        else if (j < i && j < k)
        {
            wayPoints[0] = bridgeWayPoint[1];
            wayPoints[1] = bridgeWayPoint[1].transform.GetChild(0).gameObject;
        }
        else if (k < i && k < j)
        {
            wayPoints[0] = bridgeWayPoint[2];
            wayPoints[1] = bridgeWayPoint[2].transform.GetChild(0).gameObject;
        }
        gameObject.transform.LookAt(wayPoints[0].transform.position);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, wayPoints[_currentWayPointIndex].transform.position) < 0.5f)
        {
            _currentWayPointIndex++;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[_currentWayPointIndex].transform.position, wayPointSpeed * Time.deltaTime);
        }

        if(Math.Abs(transform.position.z - wayPoints[0].transform.position.z) < 0.5f)
        {
            gameObject.transform.LookAt(wayPoints[1].transform.position);
        }
        else if(Math.Abs(transform.position.z - wayPoints[1].transform.position.z) < 0.5f)
        {
            gameObject.transform.LookAt(wayPoints[2].transform.position);
        }
        else if(Math.Abs(transform.position.z - wayPoints[2].transform.position.z) < 0.5f)
        {
            gameObject.transform.LookAt(wayPoints[2].transform.position);
        }
    }
}