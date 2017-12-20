// ===============================
// AUTHOR: Justin Laconto
// PURPOSE: Automated test script intended to continually create objects using EquipmentGenerator.
// ===============================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGeneratorTester : MonoBehaviour {

    EquipmentGenerator _EG;
    Inventory _Inv;

    public void LoopThatShit()
    {
        for (int i = 0; i < 100; i++)
        {
            ClickButton();
        }
    }

    public void ClickButton()
    {
        _EG = FindObjectOfType<EquipmentGenerator>();
        _Inv = FindObjectOfType<Inventory>();

        Item generatedItem;
        generatedItem = _EG.RandomlyGenerateEquipment();
        _Inv.AddItem(generatedItem);
    }
}
