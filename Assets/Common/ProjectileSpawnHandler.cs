// ===============================
// AUTHOR: Justin Laconto
// PURPOSE: Keeps the playerobject from seperating from the ProjectileSpawnPoint GameObject when the player moves. 
// ===============================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnHandler : MonoBehaviour {


    public float x;
    public float y;
    public float z;

	// Use this for initialization
	void Start () {
        x = gameObject.transform.localPosition.x;
        y = gameObject.transform.localPosition.y;
        z = gameObject.transform.localPosition.z;
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.localPosition = new Vector3(x, y, z);
	}
}
