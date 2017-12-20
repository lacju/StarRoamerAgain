using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class HandleItemOnButtonClick : MonoBehaviour
{

    private Item handledItem;
    private Item[] playerInvContents;
    private PlayerObject _POC;
    private VendorHandler _vendor;
    public int rewiredPlayerId = 0;
    private Player rewiredPlayer;

    private void Awake()
    {
        _POC = FindObjectOfType<PlayerObject>();
        rewiredPlayer = ReInput.players.GetPlayer(rewiredPlayerId);

    }

    private void Update()
    {

    }

    public void ItemClicked(int invSlotNum)
    {
        Debug.Log("Slot Number" + invSlotNum);
        handledItem = _POC.GetPlayerInventoryContents()[invSlotNum];
        Debug.Log("Handled item" + handledItem);
        _vendor = FindObjectOfType<VendorHandler>();
        if (_vendor != null)
        {
            if (handledItem.stackable)
            {
                if (rewiredPlayer.GetButton("ShiftModifier")) //Hold shift and click to sell the whole inventory slots worth of items
                {

                    _POC.AddToCurrentCredits(_POC.GetPlayerInventoryContents()[invSlotNum].quantity * (_POC.GetPlayerInventoryContents()[invSlotNum].baseCostCredits * (_vendor.GetPriceModifier() + 1)));
                    _POC.TakeItemFromInventoryBySlot( invSlotNum, _POC.GetPlayerInventoryContents()[invSlotNum].quantity);
                }
                else
                {

                    _POC.AddToCurrentCredits(_POC.GetPlayerInventoryContents()[invSlotNum].quantity * (_POC.GetPlayerInventoryContents()[invSlotNum].baseCostCredits * (_vendor.GetPriceModifier() + 1)));
                    _POC.TakeItemFromInventoryBySlot(invSlotNum, 1);
                }
            }
        }

         if (handledItem.isEquipment)
        {
            
          Debug.Log("EQ slot free, should equip");
                Debug.Log("Item being equipped: " + handledItem + " | ItemID: " + handledItem.itemID.ToString() + "| Line 68 | InvSlotnum:" + invSlotNum);
                _POC.EquipModule(handledItem);
              //  Debug.Log("Inv slot number of item being removed from inventory: " + invSlotNum + " | Item (inventory[slotnum]) being removed from inventory: " + _POC.GetPlayerInventoryContents()[invSlotNum].itemName + " | ItemID: " + _POC.GetPlayerInventoryContents()[invSlotNum].itemID + "| Line 70");
           //     _POC.RemoveItemFromInventoryByIndex(invSlotNum);
             //   Debug.Log("Inv slot number of item that should have been removed from inventory: " + invSlotNum + " | Item (inventory[slotnum]) slot in inv that should have had item removed from inventory (should be null): " + _POC.GetPlayerInventoryContents()[invSlotNum] + " | ItemID: " + _POC.GetPlayerInventoryContents()[invSlotNum].itemID + "| Line 70");
           
        }
    }

    public void UnequipModule(string moduleType)
    {
        Debug.Log("string module type: " + moduleType);
        _POC.UnequipItem(moduleType);
    }

    public class Debug
    {
        public static void Log(object obj)
        {
            UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + obj);

        }
    } // time stamps debug 



}

