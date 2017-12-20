using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class Projectile : PooledObject {

    //  public Rigidbody Body { get;  set; }
    public Transform tform;
    public float projectileVelocity;
    public float minimumDamage;
    public float maximumDamage;
    public float weaponSlot = 0;
    private GameObject projectileSpawnPoint;

    private void Awake()
    {
        //   Body = GetComponent<Rigidbody>();
        tform = GetComponent<Transform>();

        if (weaponSlot == 0)
        {
            projectileSpawnPoint = GameObject.Find("ProjectileSpawnPoint0");
        }
        else
        {
            projectileSpawnPoint = GameObject.Find("ProjectileSpawnPoint1");
        }
    }

    public void SetProjectileVelocity(float pv)
    {
        projectileVelocity = pv;
    }
    

    public void SetMinimumDamage(float minDmg)
    {
        minimumDamage = minDmg;
    }

    public void SetMaximumDamage(float maxDmg)
    {
        maximumDamage = maxDmg;
    }
    
    private void OnEnable()
    {
        gameObject.transform.localPosition = projectileSpawnPoint.transform.position;
        gameObject.transform.localRotation = projectileSpawnPoint.transform.rotation;
    }

    private void OnDisable()
    {
        //  gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        ReturnToPool();
    }

    private void Update()
    {
        if (!gameObject.GetComponent<Renderer>().isVisible)
        {
            ReturnToPool();
        }
    }

    private void FixedUpdate()
    {
        float playerSpeed = GameObject.Find("PlayerObject").GetComponent<Rigidbody>().velocity.magnitude;

        if (playerSpeed < 1)
        {
            //  Body.AddForce(this.transform.forward  * projectileVelocity);
            transform.Translate(Vector3.forward * Time.deltaTime * projectileVelocity);
        }
        else
        {
            //  Body.AddForce(this.transform.forward  * projectileVelocity);
            transform.Translate(Vector3.forward * Time.deltaTime * projectileVelocity);
        }
    }
}
