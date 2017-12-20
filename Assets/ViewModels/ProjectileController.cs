﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    public enum weaponSlot
    {
        slot1, slot2, slot3, slot4, turret
    }
    
    private float life;
    private float damage;
    private float minDamage;
    private float maxDamage;
    private float speed;
    private Vector3 initialVelocity;
    private Quaternion rotation;
    private PlayerObject _POC;
    private GameObject projectileSpawnPoint;



    private void Awake()
    {
        _POC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerObject>();
        
    }

    private void Start()
    {
      //  projectileSpawnPoint = _POC.GetProjectileSpawnPoint();
        Debug.Log("Projectile initialized");
      //  SetLife(_POC.GetProjectileLife());
     //   SetMinDamage(_POC.GetWeaponMinDamage());
      //  SetMaxDamage(_POC.GetWeaponMaxDamage());
        SetDamage();
        SetSpeed();
        Debug.Log("Projectile created (Awake()). Life: " + life + "mindmg: " + minDamage + "maxdmg: " + maxDamage + "speed(force): " + speed);
        Invoke("TurnOff", life);
    }

    public void ProjectileSpawned()
    {
        Debug.Log("Projectile initialized");
       // projectileSpawnPoint = _POC.GetProjectileSpawnPoint();
      //  SetLife(_POC.GetProjectileLife());
      //  SetMinDamage(_POC.GetWeaponMinDamage());
     //   SetMaxDamage(_POC.GetWeaponMaxDamage());
        SetDamage();
        SetSpeed();
    //    gameObject.transform.position = _POC.GetProjectileSpawnPoint().transform.position;
        gameObject.transform.rotation = projectileSpawnPoint.transform.rotation;
        gameObject.GetComponent<Rigidbody>().velocity = _POC.GetPlayerShipVelocity();
        gameObject.GetComponent<Rigidbody>().AddForce(gameObject.GetComponent<Transform>().forward * speed);
    }

    void OnTriggerEnter(Collider target)
    {
        

        Debug.Log("Projectiled collided with" + target);
        target.SendMessageUpwards("TakeDamage", damage);
        Destroy(gameObject);
        Debug.Log("Projectiled collided with" + target);

    }


    void TurnOff()
    {
        //gameObject.SetActive(false);
        //gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Debug.Log("Projectile created (TurnOff()). Life: " + life + "mindmg: " + minDamage + "maxdmg: " + maxDamage + "speed(force): " + speed);
        Destroy(gameObject);

    }

    void SetDamage()
    {
        damage = Random.Range(minDamage, maxDamage);
    }

    void SetLife(float lifeInput)
    {
        life = lifeInput;
    }

    void SetSpeed()
    {
 //       speed = _POC.GetProjectileForce();
    }
    void SetRotation()
    {
        rotation = projectileSpawnPoint.transform.rotation;
    }
    void SetInitialVelocity()
    {
        initialVelocity = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().velocity;
    }
    public void SetMinDamage(float minDmg)
    {
        minDamage = minDmg;
    }

    public void SetMaxDamage(float maxDmg)
    {
        maxDamage = maxDmg;
    }



    public class Debug
    {
        public static void Log(object obj)
        {
            UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + obj);

        }
    }
}