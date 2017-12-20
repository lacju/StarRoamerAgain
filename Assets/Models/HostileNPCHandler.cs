﻿// ===============================
// AUTHOR: Justin Laconto
// PURPOSE: Handles the AI and functionality of enemy NPCs. 
// ===============================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileNPCHandler : MonoBehaviour {

    public Transform[] patrolPoints;
    public Transform[] targets;
    public float waitAtLocation;
    public bool randomTarget;
    public float huntRadius;
    public float hoverRange;
    public float fireRange;

    public GenerateDebrisOnDestroy modelToDestroy;
    public Transform projectileSpawner;
    public Hull hull;
    public Weapon weapon;
    public Engine engine;
    public Shield shield;
    public Reactor reactor;

    private float speed;
    private float currentHullPoints;
    private int destPoint;
    private float step;
    private Transform target;
    private Rigidbody rbb;
    private GameObject obj;
    private float nextFire = 0;

    void Start()
    {
       // speed = engine.Acceleration();

        GotoNextPoint();
        NewTarget();

    }

    void Update()
    {
        //if (currentHullPoints <= 0)
        //{
        //    DestroyShip();
        //}

        //step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, patrolPoints[destPoint].position, step);


        //transform.LookAt(target);
        ////Debug.Log("target looked at");
        //if (Vector3.Distance(transform.position, target.position) >= hoverRange)
        //{

        //    transform.position += transform.forward * speed * Time.deltaTime;
        //    //  Debug.Log("target traveled to");

        //    nextFire += Time.deltaTime;
        //    if ((Vector3.Distance(transform.position, target.position) <= fireRange) && (nextFire >= weapon.RefireRate() && (reactor.GetAvailablePower() > weapon.EnergyCost())))
     
        //        Fire();
        //        nextFire = 0.0f;
        //    }
        //}
    }

    void DestroyShip()
    {

            modelToDestroy.DestroyStarship();
            Destroy(gameObject);
    }

    void TakeDamage(float dmg)
    {
        currentHullPoints -= dmg;
    }


    public void UpdateHitPoints(float dmg)
    {
        currentHullPoints -= dmg;
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
        //    Debug.Log("foreached");
            if (Vector3.Distance(transform.position, ii.position) <= huntRadius)
            {
                target = ii.transform;
             //   Debug.Log("foreach found");
                break;
            }
        }
    }

}
