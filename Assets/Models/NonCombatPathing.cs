// ===============================
// AUTHOR: Justin Laconto
// PURPOSE: Equipment: Non-Combat patrol script. 
// ===============================

using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;

public class NonCombatPathing : MonoBehaviour
{

    public Transform[] points;
    public float speed;
    public float waitAtLocation;
    public bool useWithPooler;
    public bool randomSpeed;
    public float minSpeed, maxSpeed;

    private int destPoint;
    private float step;

    void Start()
    {
        if (randomSpeed)
        {
            speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
        }
        if (true)
        {
            destPoint = UnityEngine.Random.Range(0, points.Length);
            transform.position = points[destPoint].position;
        }
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        destPoint = UnityEngine.Random.Range(0, points.Length);
        transform.LookAt(points[destPoint]);
    }

    void OnTriggerEnter(Collider other)
    {
        Invoke("GotoNextPoint", waitAtLocation);
    }

    void Update()
    {
        step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, points[destPoint].position, step);
    }
}