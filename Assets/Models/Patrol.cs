using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;

public class Patrol : MonoBehaviour
{

    public Transform[] points;
    public float speed;
    public float waitAtLocation;

    private int destPoint;
    private float step;





    void Start()
    {
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
