// ===============================
// AUTHOR: Justin Laconto
// PURPOSE: Equipment: Engine Slot. 
// ===============================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Engine : Item
{
    [Tooltip("Max speed of the engine")]
    public float maxSpeed;
    [Tooltip("How quickly the ship turns (rotates on the Y axis)")]
    public float acceleration;
    [Tooltip("How quickly the ship turns (rotates on the Y axis)")]
    public float turnSpeed;
    [Tooltip("Afterburner boost level (physics magnitude: 1-1000)")]
    public float boostSpeed;
    [Tooltip("Energy cost per boost cycle ")]
    public float boostEnergyCost;
    [Tooltip("Time between boost cycles")]
    public float boostCoolDown;

    private PlayerObject _POC;

    public void InitializeEquipment(float maxspeed, float turnspeed, float accelaration, float boostspeed, float boostcost, 
        float boostcd, Sprite iconImg, ItemType itemtype, string itemname, bool isequipment, string itemdescription, float basecostcredits)
    {
        maxSpeed = maxspeed;
        turnSpeed = turnspeed;
        boostSpeed = boostspeed;
        boostEnergyCost = boostcost;
        boostCoolDown = boostcd;
        sprite = iconImg;
        itemType = itemtype;
        itemName = itemname;
        isEquipment = isequipment;
        itemDescription = itemdescription;
        baseCostCredits = basecostcredits;
        acceleration = accelaration;
    }
    
    


}
