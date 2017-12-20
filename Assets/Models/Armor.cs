// ===============================
// AUTHOR: Justin Laconto
// PURPOSE: Equipment: Armor Slot. 
// ===============================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Armor : Item
{
    public enum DamageType
    {
        Radiation, Heat, Kinetic, EM
    }

    
    [Tooltip("The larger the number the lower the damage reduction (Range: 0.1-1)")]
    public float armorLevel;
    [Tooltip("Damage resitance")]
    public DamageType damageResistance;
    public DamageType damageWeakness;
    [Tooltip("Damage resistence modifier. Larger numbers mean lower damage reduction (Range: 0.1-1)")]
    public float weaknessModifier;
    public float resistanceModifier;
    [Tooltip("Weakness to damage type")]


    private PlayerObject _POC;
    private float newArmorPoints; //level assigned and held when unequipping the armor in case its damaged

    public void InitializeEquipment( float armorlevel, DamageType damageresistance,float resistancemodifier, DamageType damageweakness, 
        float weaknessmodifier, Sprite iconImg, ItemType itemtype, string itemname, bool isequipment, string itemdescription, float basecostcredits)
    {
        
        armorLevel = armorlevel;
        damageResistance = damageresistance;
        damageWeakness = damageweakness;
        weaknessModifier = weaknessmodifier;
        resistanceModifier = resistancemodifier;

        sprite = iconImg;
        itemType = itemtype;
        itemName = itemname;
        isEquipment = isequipment;
        itemDescription = itemdescription;
        baseCostCredits = basecostcredits;
    }


   
}

