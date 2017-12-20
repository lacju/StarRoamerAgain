﻿// ===============================
// AUTHOR: Justin Laconto
// PURPOSE: Makes attached GameObject orbit.  
// ===============================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{

    public Transform  orbitAround;   // The transform that this object will orbit around
    public float OrbitSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(orbitAround.position, Vector3.up, (OrbitSpeed / 2) * Time.deltaTime);
    }
}