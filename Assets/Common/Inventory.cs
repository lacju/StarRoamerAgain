// ===============================
// AUTHOR: Justin Laconto
// PURPOSE: Manages the players inventory of items and equipment. Currently in the process of being replaced by InventorySytem. 
// ===============================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    //Inventory Variables
    public List<Text> itemQuantityText = new List<Text>(numItemSlots);
    public List<Image> itemImages = new List<Image>(numItemSlots);
    public List<Item> items = new List<Item>(numItemSlots);
    public const int numItemSlots = 36;
    private static Inventory instance;
    private int leftoverItems;
    private int leftoverItemsStackRemoval;
    private PlayerObject _POC;

    private Dictionary<Image, Item> testInventory;

    public static Inventory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("Player Inventory").AddComponent<Inventory>();
            }

            return instance;
        }
    }

    private void Awake()
    {
        _POC = FindObjectOfType<PlayerObject>();

        for (int i = 0; i < numItemSlots; i++)
        {
            items.Add(null);
        }

    }


    public void AddItem(Item itemToAdd, int quantityToAdd = 0)
    {

        //if (_POC == null)
        //{
        //    _POC = FindObjectOfType<PlayerObject>();
        //}

        // for (int i = 0; i < items.Count; i++)

        // if (itemToAdd != null)
        //  {



        foreach (var item in items)

        {
            if (itemToAdd != null)
            {



                if (item != null)
                {




                    Debug.Log("item to add: " + itemToAdd);
                    Debug.Log("item to add stackable: " + itemToAdd.stackable);
                    if (itemToAdd.stackable == true)
                    {

                        if (itemToAdd.itemID == item.itemID)
                        {
                            if (item.maxStackSize > item.GetQuantity())
                            {
                                if (quantityToAdd <= (item.maxStackSize - item.GetQuantity()))
                                {
                                    item.AddToStack(quantityToAdd);
                                    itemQuantityText[items.IndexOf(item)].text = item.GetQuantity().ToString();
                                    itemQuantityText[items.IndexOf(item)].enabled = true;
                                    _POC.AddToCurrentCargoWeight(item.itemWeight * quantityToAdd);
                                    return;
                                }
                                else
                                {
                                    int leftoverItems = quantityToAdd - (item.maxStackSize - item.GetQuantity());
                                    _POC.AddToCurrentCargoWeight(item.itemWeight * (item.maxStackSize - item.GetQuantity()));
                                    item.quantity = item.maxStackSize;
                                    itemQuantityText[items.IndexOf(item)].text = item.GetQuantity().ToString();
                                    itemQuantityText[items.IndexOf(item)].enabled = true;

                                    for (int v = 0; v < items.Count; v++)
                                    {
                                        if (items[v] == null)
                                        {
                                            items[v] = itemToAdd;
                                            itemImages[v].sprite = itemToAdd.sprite;
                                            itemImages[v].enabled = true;
                                            if (leftoverItems <= items[v].maxStackSize)
                                            {
                                                if (leftoverItems > 0)
                                                {
                                                    items[v].AddToStack(leftoverItems);
                                                    itemQuantityText[v].text = leftoverItems.ToString();
                                                    itemQuantityText[v].enabled = true;
                                                    _POC.AddToCurrentCargoWeight(item.itemWeight * leftoverItems);
                                                    return;
                                                }
                                                else
                                                {
                                                    items[v].AddToStack(1);
                                                    itemQuantityText[v].text = "1";
                                                    itemQuantityText[v].enabled = true;
                                                    _POC.AddToCurrentCargoWeight(item.itemWeight);
                                                    return;
                                                }

                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }

                }


                else if (item == null)
                {

                    if (itemToAdd.stackable)
                    {

                        itemImages[items.IndexOf(item)].sprite = itemToAdd.sprite;
                        itemImages[items.IndexOf(item)].enabled = true;
                        items[items.IndexOf(item)] = itemToAdd;
                        if (quantityToAdd <= item.maxStackSize)
                        {

                            if (quantityToAdd > 0)
                            {

                                item.AddToStack(quantityToAdd);
                                itemQuantityText[items.IndexOf(item)].text = quantityToAdd.ToString();
                                itemQuantityText[items.IndexOf(item)].enabled = true;
                                _POC.AddToCurrentCargoWeight(item.itemWeight * (quantityToAdd));
                                return;
                            }
                            else
                            {

                                item.AddToStack(1);
                                itemQuantityText[items.IndexOf(item)].text = "1";
                                itemQuantityText[items.IndexOf(item)].enabled = true;
                                _POC.AddToCurrentCargoWeight(item.itemWeight);
                                return;
                            }
                        }
                        if (quantityToAdd > 0 && quantityToAdd > itemToAdd.maxStackSize)
                        {

                            int leftoverItems = quantityToAdd - itemToAdd.maxStackSize;

                            item.AddToStack(item.maxStackSize);
                            itemQuantityText[items.IndexOf(item)].text = item.maxStackSize.ToString();
                            itemQuantityText[items.IndexOf(item)].enabled = true;
                            AddItem(itemToAdd, leftoverItems);
                            _POC.AddToCurrentCargoWeight(item.itemWeight * (quantityToAdd - itemToAdd.maxStackSize));
                            return;

                        }
                    }
                    Debug.Log("Inv: item to add passed in: " + itemToAdd);
                    itemImages[items.IndexOf(item)].sprite = itemToAdd.sprite;
                    itemImages[items.IndexOf(item)].enabled = true;
                    items[items.IndexOf(item)] =(itemToAdd);
                  //  Debug.Log("Inv: item slotted into inv: " + items[items.IndexOf(item)].GetType().ToString());
                    _POC.AddToCurrentCargoWeight(itemToAdd.itemWeight);
                    break;


                }
               

            }
        }
            }
        
    
    public Item RetrieveItem(Guid itemId, int quantityToRemove = 0)
    {
        if (_POC == null)
        {
            _POC = FindObjectOfType<PlayerObject>();
        }
        foreach (Item itemInInv in items)
        {
            Item itemToReturn;
            if (!itemInInv.stackable)
            {
                if (itemInInv.itemID == itemId)
                {
                    itemToReturn = itemInInv;

                    items[items.IndexOf(itemInInv)] = null;
                    itemImages[items.IndexOf(itemInInv)].sprite = null;
                    itemImages[items.IndexOf(itemInInv)].enabled = false;
                    return itemToReturn;
                    
                }
            }
            if (itemInInv.itemID == itemId)
                {
                    Item itemToReturnQuant = itemInInv;

                    if (items[items.IndexOf(itemInInv)].quantity > quantityToRemove)
                    {
                        itemToReturnQuant = itemInInv;
                        items[items.IndexOf(itemInInv)].quantity -= quantityToRemove;
                        itemToReturnQuant.quantity = quantityToRemove;
                        return itemToReturnQuant;
                    }
                    if (items[items.IndexOf(itemInInv)].quantity == quantityToRemove)
                    {
                        itemToReturnQuant = itemInInv;
                        items[items.IndexOf(itemInInv)] = null;
                        itemImages[items.IndexOf(itemInInv)].sprite = null;
                        itemImages[items.IndexOf(itemInInv)].enabled = false;
                        itemQuantityText[items.IndexOf(itemInInv)].enabled = false;
                        itemInInv.quantity = quantityToRemove;
                        return itemToReturnQuant;
                    }
                    else
                    {
                        itemToReturnQuant = itemInInv;
                        leftoverItemsStackRemoval = quantityToRemove - items[items.IndexOf(itemInInv)].quantity;
                        items[items.IndexOf(itemInInv)] = null;
                        itemImages[items.IndexOf(itemInInv)].sprite = null;
                        itemImages[items.IndexOf(itemInInv)].enabled = false;
                        itemQuantityText[items.IndexOf(itemInInv)].enabled = false;
                        RetrieveItem(itemInInv.itemID, leftoverItemsStackRemoval);
                        return itemToReturnQuant;
                    }
                }
            }
        return null;
        }

    public Item RetrieveItemByIndex(int index, int quantityToRemove = 0)
    {
        if (_POC == null)
        {
            _POC = FindObjectOfType<PlayerObject>();
        }
        Item itemToReturn = items[index];

            if (!items[index].stackable)
            {
                    items[index] = null;
                    itemImages[index].sprite = null;
                    itemImages[index].enabled = false;
                    return itemToReturn;
            }
           
                Item itemToReturnQuant = items[index];

                if (items[index].quantity > quantityToRemove)
                {
                    items[index].quantity -= quantityToRemove;
                    itemToReturnQuant.quantity = quantityToRemove;
                    return itemToReturnQuant;
                }
                if (items[index].quantity == quantityToRemove)
                {
                    items[index] = null;
                    itemImages[index].sprite = null;
                    itemImages[index].enabled = false;
                    itemQuantityText[index].enabled = false;
                    return itemToReturnQuant;
                }
                else
                {
                    leftoverItemsStackRemoval = quantityToRemove - items[index].quantity;
                    items[index] = null;
                    itemImages[index].sprite = null;
                    itemImages[index].enabled = false;
                    itemQuantityText[index].enabled = false;
                    RetrieveItemByIndex(index, leftoverItemsStackRemoval);
                    return itemToReturnQuant;
                }
            }
    
        
    public void RemoveItemByIndex(int index)
    {
            if (items[index] != null)
            {
                itemImages[index].sprite = null;
                itemImages[index].enabled = false;
                items[index] = null;
            }
        
    }

    public void RemoveItemByID(Guid itemId)
    {
        if (_POC == null)
        {
            _POC = FindObjectOfType<PlayerObject>();
        }
        foreach (Item itemInInv in items)
        {
            if (itemInInv != null)
            {


                Debug.Log("itemInInv (Line 286): " + itemInInv.ToString());
                Debug.Log("items (Line 286): " + items.ToString());
                Debug.Log("itemInInv.itemID (Line 291): " + items.ToString());
                Debug.Log("itemId (Line 291): " + items.ToString());
                if (itemInInv.itemID == itemId)
                {
                    Debug.Log("Item ID if loop penetrated");
                    
                    itemImages[items.IndexOf(itemInInv)].sprite = null;
                    itemImages[items.IndexOf(itemInInv)].enabled = false;
                    items[items.IndexOf(itemInInv)] = null;
                    return;
                }
            }
        }      
    }
    public void RemoveStackableItem(Item itemToRemove, int quantityToRemove)
    {
        if (_POC == null)
        {
            _POC = FindObjectOfType<PlayerObject>();
        }
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == itemToRemove)
            {
                if (items[i].quantity > quantityToRemove)
                {
                    items[i].quantity -= quantityToRemove;
                    return;
                }
                if (items[i].quantity == quantityToRemove)
                {
                    items[i] = null;
                    itemImages[i].sprite = null;
                    itemImages[i].enabled = false;
                    itemQuantityText[i].enabled = false;
                    return;
                }
                else
                {
                    leftoverItemsStackRemoval = quantityToRemove - items[i].quantity;
                    items[i] = null;
                    itemImages[i].sprite = null;
                    itemImages[i].enabled = false;
                    itemQuantityText[i].enabled = false;
                    RemoveStackableItem(itemToRemove, leftoverItemsStackRemoval);
                }

            }
        }
    }
    public List<Item> GetPlayerInventoryContents()
    {

        return items;
    }
    public class Debug
    {
        public static void Log(object obj)
        {
            UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + obj);

        }
    } // time stamps debug 
}

