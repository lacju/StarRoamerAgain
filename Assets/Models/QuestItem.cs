using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestItem : Item {



    public void InitializeQuestItem(Sprite iconImg, string itemname, string itemdescription, float itemweight, bool isstackable, int maxstacksize)
    {
        sprite = iconImg;
      //  itemType = "Quest";
        baseCostCredits = -1;
        itemQuality = "Quest";
        isEquipment = false;
        isEquipped = false;
        itemWeight = itemweight;
        stackable = isstackable;
        maxStackSize = maxstacksize;
        itemName = itemname;
        itemDescription = itemdescription;

    }
	
}
