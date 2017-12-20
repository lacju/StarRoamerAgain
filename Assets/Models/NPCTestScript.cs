using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTestScript : MonoBehaviour {

    public float npcLevel;
    public bool npcRandomLevel; //Level will eventually determine HP and other stats if not overridden
    public float npcRandomLevelMinLevel;
    public float npcRandomLevelMaxLevel;
    public float hullHealthPoints; //eventually npc will be assigned a hull which will dictate this
    public float npcShieldsMax;
    public float npcShieldsCurrent;
    public float npcReactorMax;
    public float npcReactorCurrent;
    public Shield npcShieldModule;
    public Engine npcEngineModule;
    public Weapon npcWeaponModule;
    public Reactor npcReactorModule;
    public GameObject lootContainer;

    public GenerateDebrisOnDestroy gbs;
    public EnergyShieldManager esm;
    public EquipmentGenerator eg;
    private void Awake()
    {
        eg = FindObjectOfType<EquipmentGenerator>();
    }
    // Use this for initialization
    void Start () {
        npcShieldModule = (Shield)eg.RandomlyGenerateEquipment(ItemType.Shield);
        npcEngineModule = (Engine)eg.RandomlyGenerateEquipment(ItemType.Engine);
        npcWeaponModule = (Weapon)eg.RandomlyGenerateEquipment(ItemType.Weapon);
        npcReactorModule = (Reactor)eg.RandomlyGenerateEquipment(ItemType.Reactor);
    }
	
	// Update is called once per frame
	void Update () {

        if (!npcShieldModule.coRoutineRunning)
        {
            StartCoroutine(npcShieldModule.ShieldRegenerate());
            npcShieldsCurrent = npcShieldModule.currentShields;
        }
        if (!npcReactorModule.coroutineRunning)
        {
            StartCoroutine(npcReactorModule.ReactorRegenerate());
            npcReactorCurrent = npcReactorModule.availableEnergy;
        }
        if (npcShieldModule.currentShields <= 0)
        {
            esm.enabled = false;
        }
        else if (npcShieldModule.currentShields > 0)
        {
            if (!esm.enabled)
            {
                esm.enabled = true;
            }
        }
    }

    
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Projectile")
    //    {
    //        foreach (ContactPoint contact in collision.contacts)
    //        {
    //            esm.Hit(contact.point);
    //        }
    //        collision.gameObject.SetActive(false);
    //    }
    //}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            //note this position might not be very accurate so i suggest using the Collision function.
            esm.Hit(other.transform.position);
            other.gameObject.SetActive(false);
            npcShieldModule.currentShields = npcShieldModule.currentShields - Random.Range(other.gameObject.GetComponent<Projectile>().minimumDamage, other.gameObject.GetComponent<Projectile>().maximumDamage);

            if (npcShieldModule.currentShields < 0)
            {
                hullHealthPoints = hullHealthPoints - Random.Range(other.gameObject.GetComponent<Projectile>().minimumDamage, other.gameObject.GetComponent<Projectile>().maximumDamage);
            }
            if (hullHealthPoints <= 0)
            {
                Instantiate(lootContainer);
                Destroy(gameObject);
               // gbs.DestroyStarship();
            }
        }


    }
}
