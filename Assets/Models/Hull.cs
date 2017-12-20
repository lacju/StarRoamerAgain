// ===============================
// AUTHOR: Justin Laconto
// PURPOSE: Represents the player's ship. 
// ===============================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ShipType
{
    Freighter, Frigate, Cruiser
}

public class Hull : ScriptableObject {
    [Header("HULLPOINTS")]
    [Header("Tier One Freighter = 350, Tier Two Freighter = 1000")]
    [Header("Tier One Frigate = 500HP, Tier Two Fridage = 1300")]
    [Header("Tier One Cruiser = 2500, Tier Two Cruiser = 3500")]

    public ShipType shipType;
    public float hitPointModifier;
    public bool tierTwo;
    public string hullModel;
    public float baseMonetaryValueHull;
    public bool optionalEquipmentSlot;
    public int cargoCapacity;
    public float maxSpeed;
    public float turnSpeed;
    public int turretSlots;
    public int weaponSlots;
    public float currentHullpoints;
    public float maxHullPoints;
    public string shipPersonalName;
    public Reactor equippedReactor;
    public bool reactorEquipped;
    public Engine equippedEngine;
    public bool engineEquipped;
    public Shield equippedShields;
    public bool shieldEquipped;
    public Armor equippedArmor;
    public bool armorEquipped;
    public Weapon equippedWeapon0;
    public bool weapon0Equipped;
    public Weapon equippedWeapon1;
    public bool weapon1Equipped;
   // public Turret equippedTurret0; not implimented
   // public Turret equippedTurret1; not implimented
    public PlayerObject _POC;
    public GameObject shipModel;
    public Sprite shipIcon;
    public List<Item> allEquippedEquipment;
    
    public void CheckForEquipment()
    {
        allEquippedEquipment = new List<Item>();

        

        if (equippedEngine != null)
        {
            allEquippedEquipment.Add(equippedEngine);
            equippedEngine.isEquipped = true;
        }
        if (equippedReactor != null)
        {
            allEquippedEquipment.Add(equippedReactor);
            equippedReactor.isEquipped = true;
        }
        if (equippedShields != null)
        {
            allEquippedEquipment.Add(equippedShields);
            equippedShields.isEquipped = true;
        }
        if (equippedArmor != null)
        {
            allEquippedEquipment.Add(equippedArmor);
            equippedArmor.isEquipped = true;
        }
        if (equippedWeapon0 != null)
        {
            allEquippedEquipment.Add(equippedWeapon0);
            equippedWeapon0.isEquipped = true;
        }
        if (equippedWeapon1 != null)
        {
            allEquippedEquipment.Add(equippedWeapon1);
            equippedWeapon1.isEquipped = true;
        }

    }


    public void EquipReactor(Reactor reactor = null)
    {       
        if (reactor != null)
        {
            equippedReactor = reactor;
            equippedReactor.isEquipped = true;
            reactorEquipped = true;
           
        }
        else
        {
            reactorEquipped = false;
            
            equippedReactor = reactor;
        }
        
    }
    public void EquipEngine(Engine engine = null)
    {
        equippedEngine = engine;
        if (engine != null)
        {
            equippedEngine.isEquipped = true;
            engineEquipped = true;
        }
        else
        {
            engineEquipped = false;
        }

    }
    public void EquipShield(Shield shields = null)
    {
        equippedShields = shields;
        if (shields != null)
        {

            equippedShields.isEquipped = true;
            shieldEquipped = true;
        }
        else
        {
            shieldEquipped = false;
        }
    }
    public void EquipArmor(Armor armor = null)
    {
        equippedArmor = armor;
        if (armor != null)
        {
            equippedArmor.isEquipped = true;
            armorEquipped = true;
        }
        else
        {
            armorEquipped = false;
        }

    }
    public void EquipWeapon0(Weapon weapon = null)
    {

        equippedWeapon0 = weapon;
        if (weapon != null)
        {
            equippedWeapon0.isEquipped = true;
            weapon0Equipped = true;
        }
        else
        {
            weapon0Equipped = false;
        }
    }
    public void EquipWeapon1(Weapon weapon = null)
    {

        equippedWeapon1 = weapon;
        if (weapon != null)
        {
            equippedWeapon1.isEquipped = true;
            weapon1Equipped = true;
        }
        else
        {
            weapon1Equipped = false;
        }
    }
    public void InitializeHull(ShipType shiptype, string hullmodel, bool tiertwo, float basemonetaryvaluehull, int cargocapacity, float maxspeed, float turnspeed, 
        int turretslots, int weaponslots, GameObject shipmodel, Sprite shipicon, bool optionalequipmentslot = false)
    {
        shipType = shiptype;
        tierTwo = tiertwo;
        hullModel = hullmodel;
        baseMonetaryValueHull = basemonetaryvaluehull;
        optionalEquipmentSlot = optionalequipmentslot;
        shipModel = shipmodel;
        shipIcon = shipicon;
        cargoCapacity = cargocapacity;
        maxSpeed = maxspeed;
        turnSpeed = turnspeed;
        turretSlots = turretslots;
        weaponSlots = weaponslots;

        switch (shipType)
        {
            case ShipType.Freighter:
                if (tierTwo)
                {
                    maxHullPoints = 1000;
                }
                else
                {
                    maxHullPoints = 350;
                }
                break;
            case ShipType.Frigate:
                if (tierTwo)
                {
                    maxHullPoints = 1300;
                }
                else
                {
                    maxHullPoints = 500;
                }
                break;
            case ShipType.Cruiser:
                if (tierTwo)
                {
                    maxHullPoints = 2500;
                }
                else
                {
                    maxHullPoints = 3500;
                }
                break;
        }
        currentHullpoints = maxHullPoints;
    }
    public ShipType GetShipClass()
    {
        return shipType;
    }
    public string GetModel()
    {
        return hullModel;
    }
    public float GetValue()
    {
        return baseMonetaryValueHull + equippedReactor.baseCostCredits + equippedEngine.baseCostCredits + equippedShields.baseCostCredits + equippedArmor.baseCostCredits + equippedWeapon0.baseCostCredits + equippedWeapon1.baseCostCredits;
    }
    public int GetCargoCapacity()
    {
        return cargoCapacity;
    }
    public float GetMaxSpeed()
    {
        return maxSpeed;
    }
    public float GetTurnSpeed()
    {
        return turnSpeed;
    }
    public int GetTurretSlots()
    {
        return turretSlots;
    }
    public int GetWeaponSlot()
    {
        return weaponSlots;
    }
    public void SetPersonalName(string name)
    {
        shipPersonalName = this.name;
    }
    public string GetPersonalName()
    {
        return shipPersonalName;
    }
    public float GetMaxHullPoints()
    {
        return maxHullPoints;
    }
    private void Awake()
    {
        _POC = FindObjectOfType<PlayerObject>();

       
    }

    public Item UnequipItem(string slotToUnequip)
    {
        Item itemToReturn;
        switch (slotToUnequip)
        {           
            case "Armor":
                itemToReturn = equippedArmor;
                EquipArmor();
                return itemToReturn;
            case "Shield":
                itemToReturn = equippedShields;
                EquipShield();
                return itemToReturn;
            case "Engine":
                itemToReturn = equippedEngine;
                EquipEngine();
                return itemToReturn;
            case "Reactor":
                itemToReturn = equippedReactor;
                EquipReactor();
                return itemToReturn;
            case "Weapon0":
                itemToReturn = equippedWeapon0;
                EquipWeapon0();
                return itemToReturn;
            case "Weapon1":
                itemToReturn = equippedWeapon1;
                EquipWeapon1();
                return itemToReturn;
        }
        return null;
    }
}
