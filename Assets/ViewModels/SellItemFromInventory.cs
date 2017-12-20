﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class SellItemFromInventory : MonoBehaviour {

    private Inventory _playerInv;
    private PlayerObject _POC;
    private VendorHandler _vendor;

    public int rewiredPlayerId = 0;
    private Player rewiredPlayer;

    private void Awake()
    {
        
        _POC = FindObjectOfType<PlayerObject>();
        _vendor = FindObjectOfType<VendorHandler>();
    }


    public void SellItem(int itemslot)
    {
        _vendor = FindObjectOfType<VendorHandler>();

        if (_vendor != null)
        {
            if (_vendor.isActiveAndEnabled)
            {
                if (_playerInv.items[itemslot].GetQuantity() != 0)
                {
                    if (rewiredPlayer.GetButton("ShiftModifier")) //Hold shift and click to sell the whole inventory slots worth of items
                    {
                   
                        _POC.AddToCurrentCredits(_playerInv.items[itemslot].quantity * (_playerInv.items[itemslot].baseCostCredits * (_vendor.GetPriceModifier() + 1)));
                        _playerInv.RemoveStackableItem(_playerInv.items[itemslot], _playerInv.items[itemslot].quantity);
                    }
                    else
                    {
                  
                        _POC.AddToCurrentCredits(_playerInv.items[itemslot].quantity * (_playerInv.items[itemslot].baseCostCredits * (_vendor.GetPriceModifier() + 1)));
                        _playerInv.RemoveStackableItem(_playerInv.items[itemslot], 1);
                    }
                }


                _POC.AddToCurrentCredits(_playerInv.items[itemslot].baseCostCredits);
                Debug.Log(_playerInv.items[itemslot]);
                _POC.TakeItemFromInventoryBySlot(itemslot); 
                Debug.Log(_playerInv.items[itemslot]);

            }
        }
    }

}