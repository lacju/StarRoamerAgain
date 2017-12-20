// ===============================
// AUTHOR: Justin Laconto
// PURPOSE: Item base class. 
// ===============================

using System;
using UnityEngine;
public enum ItemType
{
    Armor, Shield, Engine, Weapon, Reactor, Commodity
}
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public ItemType itemType;
    public string itemName;
    public bool stackable;
    public int maxStackSize;
    public bool isEquipment;
    public bool isEquipped;
    public Guid itemID;
    public string itemDescription;
    public float baseCostCredits;
    public float itemWeight;
    public string itemQuality;


    public int quantity = 0;

    public void InitializeItem(Sprite iconImg, ItemType itemtype, string itemname, bool isequipment, string itemdescription, float basecostcredits, 
        float itemweight, string itemquality = "Common", bool canStack = false, int maxstacksize = 1, bool isequipped = false)
    {
        sprite = iconImg;
        itemName = itemname;
        stackable = canStack;
        maxStackSize = maxstacksize;
        itemID = Guid.NewGuid();
        isEquipment = isequipment;
        isEquipped = isequipped;
        itemDescription = itemdescription;
        baseCostCredits = basecostcredits;
        itemWeight = itemweight;
        itemQuality = itemquality;
        itemType = itemtype;
    }
    

    public int GetQuantity()
    {
        return quantity;
    }

    public void AddToStack(int qantityToAdd)
    {
        quantity += qantityToAdd;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Right click registered, like a fuckin boss");
        }
    }


}
