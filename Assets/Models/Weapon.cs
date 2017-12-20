using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item {

    public enum DamageType
    {
        Radiation, Heat, Kinetic, EM
    }

    public DamageType dmgType;
    public float minDamage;
    public float maxDamage;
    public float refireRate;
    public float energyCost;
    public Projectile projectile { get;  private set; }
    public ObjectPool projectilePrefabs;
    private PlayerObject _POC;
    public GameObject projectileSpawnPoint;

    public void InitializeEquipment(float mindamage, float maxdamage, DamageType dmgtype, float refirerate, float energycost, float projectileVel, Projectile assignedProjectile, Sprite iconImg, 
        ItemType itemtype, string itemname, bool isequipment, string itemdescription, float basecostcredits)
    {

        minDamage = mindamage;
        maxDamage = maxdamage;
        refireRate = refirerate;
        energyCost = energycost;
        sprite = iconImg;
        itemType = itemtype;
        itemName = itemname;
        isEquipment = isequipment;
        itemDescription = itemdescription;
        baseCostCredits = basecostcredits;
        dmgType = dmgtype;
        projectile = assignedProjectile;
        projectile.SetProjectileVelocity(projectileVel);
        projectile.SetMinimumDamage(mindamage);
        projectile.SetMaximumDamage(maxdamage);
        projectileSpawnPoint = GameObject.Find("ProjectileSpawnPoint");
    }

    public void FireWeapon()
    {
        projectile.GetPooledInstance<Projectile>();
      //  projectile.transform.localPosition = projectileSpawnPoint.transform.position;
        //projectile.transform.localRotation = projectileSpawnPoint.transform.rotation;
        
        //spawn.transform.localScale = Vector3.one * scale.RandomInRange;
        //spawn.transform.localRotation = Random.rotation;

       // projectile.Body.velocity = projectileSpawnPoint.transform.forward * projectile.projectileVelocity;
        //spawn.Body.angularVelocity =
        //    Random.onUnitSphere * angularVelocity.RandomInRange;

        //spawn.SetMaterial(stuffMaterial);
    }

    
    

}
