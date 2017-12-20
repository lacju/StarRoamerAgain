﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePooler : MonoBehaviour {

    public static ProjectilePooler instance;
    public GameObject pooledProjectile;
    private PlayerObject _POC;
    private int pooledAmount = 50;

    List<GameObject> pooledProjectiles;

    
    void Awake()
    {
        _POC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerObject>();
     //   pooledProjectile = _POC.GetWeapon0Projectile();
        instance = this;
    }

    void Start()
    {
        pooledProjectiles = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledProjectile);
            obj.SetActive(false);
            pooledProjectiles.Add(obj);
        }


    }

    public GameObject GetPooledProjectile()
    {
        foreach (var i in pooledProjectiles)
        {
            if (!i.activeInHierarchy)
            {
                 Debug.Log("found in list and returned");
                return i;
                
            }
            else
            {
                GameObject obj = (GameObject)Instantiate(pooledProjectile);
                pooledProjectiles.Add(obj);
                obj.SetActive(false);
                Debug.Log("projectile not found and created, returned");
                return obj;

            }
        }
        return null;       
    }

   
}