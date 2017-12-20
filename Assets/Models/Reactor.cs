using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reactor : Item {

    [Tooltip("Maximum power")]
    public float maxPower;
    [Tooltip("Recharge Rate (per 2 seconds)")]
    public float rechargeRate;
    public bool equipped;
    

    private PlayerObject _POC;

    public void InitializeEquipment(float maxpower, float rechargerate, Sprite iconImg, ItemType itemtype, string itemname, bool isequipment, string itemdescription, float basecostcredits)
    {
        maxPower = maxpower;
        rechargeRate = rechargerate;
        sprite = iconImg;
        itemType = itemtype;
        itemName = itemname;
        isEquipment = isequipment;
        itemDescription = itemdescription;
        baseCostCredits = basecostcredits;
        
    }

    private void OnEnable()
    {
        
    }

    public bool reactorRegenOnCoolDown = false;
    public float availableEnergy = 0;
    public bool coroutineRunning = false;

    public IEnumerator ReactorRegenerate()
    {
        coroutineRunning = true;
        while (availableEnergy < maxPower)
        {
            if (availableEnergy < 0)
            {
                availableEnergy = 0;
            }
            if (availableEnergy < maxPower)
            {
                if ((maxPower - availableEnergy) < rechargeRate)
                {
                    availableEnergy =maxPower;
                }
                else
                {
                    reactorRegenOnCoolDown = true;
                    availableEnergy += rechargeRate;
                    yield return new WaitForSecondsRealtime(1);
                    reactorRegenOnCoolDown = false;

                }
            }
        }
        coroutineRunning = false;
    }

    public float GetCreditValue()
    {
        return baseCostCredits;
    }

    public float RechargeRate()
    {
        return rechargeRate;
    }

    public void ReduceAvailableEnergy(float energyAmt)
    {
        if (availableEnergy >= energyAmt)
        {
            availableEnergy =- energyAmt;
        }
    }

    public class Debug
    {
        public static void Log(object obj)
        {
            UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + obj);

        }
    } // time stamps debug

}
