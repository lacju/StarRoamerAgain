// ===============================
// AUTHOR: Justin Laconto
// PURPOSE: Prototype patrol script. 
// ===============================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostilePatrol : MonoBehaviour {

    public Transform[] patrolPoints;
    public Transform[] targets;
    public float speed;
    public float waitAtLocation;
    public bool randomTarget;
    public float huntRadius;
    public float hoverRange;
    public float fireRange;

    private int destPoint;
    private float step;
    private Transform target;




    void Start()
    {
        GotoNextPoint();
        NewTarget();
        
    }



    

    void GotoNextPoint()
    {
        if (patrolPoints.Length == 0)
            return;

        destPoint = UnityEngine.Random.Range(0, patrolPoints.Length);
        transform.LookAt(patrolPoints[destPoint]);
    }

    void OnTriggerEnter(Collider other)
    {
        Invoke("GotoNextPoint", waitAtLocation);
    }

    void NewTarget()
    {
        foreach (Transform ii in targets)
        {
            Debug.Log("foreached");
            if (Vector3.Distance(transform.position, ii.position) <= huntRadius)
            {
                target = ii.transform;
                Debug.Log("foreach found");
                break;
            }
        }
    }



    void Update()
    {
        step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[destPoint].position, step);


                transform.LookAt(target);
        Debug.Log("target looked at");
        if (Vector3.Distance(transform.position, target.position) >= hoverRange)
                {

                    transform.position += transform.forward * speed * Time.deltaTime;
            Debug.Log("target traveled to");


            if (Vector3.Distance(transform.position, target.position) <= fireRange)
                    {
                //Here Call any function U want Like Shoot at here or something
                NewTarget();
                    }
                }        
        }
    }
