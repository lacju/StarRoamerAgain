using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : Item {

    public enum DamageType
    {
        Radiation, Heat, Kinetic, EM
    }

    public float maxCapacity;
    public float rechargeRate;
    public float rechargeDelay;
    public float dmgResistance;
    public float dmgWeakness;
    public DamageType damageResistance;
    public DamageType damageWeakness;

    private PlayerObject _POC;
    private bool regenOnCoolDown = false;

    public void InitializeEquipment(float maxcapacity, float rechargerate, float rechargedelay, DamageType damageresistance, float dmgresist, 
        DamageType damageweakness, float dmgweakness, Sprite iconImg, ItemType itemtype, string itemname, bool isequipment, string itemdescription, float basecostcredits)
    {
        maxCapacity = maxcapacity;
        rechargeRate = rechargerate;
        rechargeDelay = rechargedelay;
        sprite = iconImg;
        itemType = itemtype;
        itemName = itemname;
        isEquipment = isequipment;
        itemDescription = itemdescription;
        baseCostCredits = basecostcredits;
        dmgResistance = dmgresist;
        dmgWeakness = dmgweakness;
    }

    public float currentShields; //Current shield level
    public bool shieldRechargeDelayInEffect = false;
    public bool shieldRegenOnCoolDown = false;
    public bool coRoutineRunning = false;
    public IEnumerator ShieldRegenerate()
    {
        coRoutineRunning = true;
            while (currentShields < maxCapacity)
            {
                if (currentShields <= 0)
                {
                    currentShields = 0;
                    shieldRechargeDelayInEffect = true;
                    yield return new WaitForSeconds(rechargeDelay);
                    shieldRechargeDelayInEffect = false;
                }
                if (currentShields < maxCapacity)
                {
                    if ((maxCapacity - currentShields) < rechargeRate)
                    {
                        currentShields = (maxCapacity);
                    }
                    else
                    {
                        shieldRegenOnCoolDown = true;
                        currentShields += (rechargeRate);
                        yield return new WaitForSeconds(3);
                        shieldRegenOnCoolDown = false;

                    }
                }
            }
        coRoutineRunning = false;
    }

    //public void EquipEquipment()
    //{
    //    _POC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerObject>();
    //    _POC.SetMaxShields(MaxCapacity());
    //    _POC.SetCurrentShieldPoints(0);
    //    isEquipped = true;
    //}

    //public void UnequipEquipment()
    //{
    //    _POC.SetCurrentShieldPoints(0);
    //    _POC.SetMaxShields(1);
    //    isEquipped = false;

    //}


    public float MaxCapacity()
    {
        return maxCapacity;
    }

    public float RechargeRate()
    {
        return rechargeRate;
    }

    private float RechargeDelay()
    {
        return rechargeRate;
    }

    public class Debug
    {
        public static void Log(object obj)
        {
            UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + obj);

        }
    } 
}