using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBackup : MonoBehaviour {

    public float minDamage;
    public float maxDamage;
    public float refireRate;
    public float energyCost;
    public float projectileLife;
    public float projectileForce;
    public GameObject projectile;
    public int pooledAmount = 20;
    public bool willGrow;
    public GameObject projectileSpawn; //represents the object that this script is attached to

    private float damage;
    private float health = 100;
    private bool destroyed;
    private GameObject obj;
    List<GameObject> pooledObjects;

    void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(projectile);
            obj.SendMessage("SetMinDamage", minDamage);
            obj.SendMessage("SetMaxDamage",  maxDamage);
            obj.SendMessage("SetLife", projectileLife);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }


        if (destroyed && health > 0)
        {
            destroyed = false;
            gameObject.SetActive(false);
        }
    }

    public void ReduceHealth(float dmg)
    {
        health = health - dmg;
    }

    public float GetDamage()
    {
        return damage;
    }

    public float RefireRate()
    {
        return refireRate;
    }

    public float EnergyCost()
    {
        return energyCost;
    }

    public float ProjectileForce()
    {
        return projectileForce;
    }

    //public void Fire()
    //{
    //    Debug.Log("fired");
    //    GameObject obj = GetPooledObject();
    //    Debug.Log("pooled bolt collected");
    //    Rigidbody rbb = obj.GetComponent<Rigidbody>();
    //    Debug.Log("bolts RB assigned");
    //    obj.transform.position = projectileSpawn.transform.position;
    //    Debug.Log("bolt positioned");
    //    obj.transform.rotation = projectileSpawn.transform.rotation;
    //    Debug.Log("bolt rotated");
    //    obj.SetActive(true);
    //    Debug.Log("bolt activated");
    //    rbb.AddForce(transform.forward * projectileForce);
    //    Debug.Log("force applied to bolt");
    //}

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                Debug.Log("Object dispensed");
                return pooledObjects[i];
                
            }
        }
       // Debug.Log("bolt dispensed");
        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(projectile);
            obj.SendMessage("SetMinDamage", minDamage);
            obj.SendMessage("SetMaxDamage", maxDamage);
            obj.SendMessage("SetLife", projectileLife);
            pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }

    public float HealthPercent()
    {
        return (health / 100);
    }
}
