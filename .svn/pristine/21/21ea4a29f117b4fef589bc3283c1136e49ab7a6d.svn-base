using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHandler : MonoBehaviour {

    [Tooltip("Max speed of the NPC")]
    public float maxSpeed;
    [Tooltip("Minium damage")]
    public float minimumDamage;
    [Tooltip("Maximum Damage")]
    public float maximumDamage;
    [Tooltip("Shield strength")]
    public float shieldPower;
    [Tooltip("Shield recharge delay")]
    public float shieldRechargeDelay;
    [Tooltip("Shield recharge rate, per 2 seconds")]
    public float shieldRechargeRate;
    [Tooltip("Object containing the energy shield effect")]
    public GameObject energyShieldEffect;

    private float hullPoints;
    private float currentShieldPoints;
    private float currentHullPoints;
    private bool regenOnCoolDown = false;
    private EnergyShieldManager EMS;

    private void Awake()
    {
        EMS = energyShieldEffect.GetComponent<EnergyShieldManager>();
        currentShieldPoints = shieldPower;

    }

    private void Update()
    {
        if (!regenOnCoolDown)
        {
            Regenerate();
        }
        
    }

    public void TakeDamage(float damage)
    {

        if (currentShieldPoints > 0)
        {
            if (currentShieldPoints < damage)
            {
                DamageHull(damage - currentShieldPoints);
                currentShieldPoints = -1;
            }
            currentShieldPoints = (currentShieldPoints - damage);
        }
        else if (currentHullPoints > 0)
        {
            DamageHull(damage);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void DamageHull(float hullDmg)
    {
        currentHullPoints = currentHullPoints - hullDmg;
        //method will eventually handle subsystem damage
    }

    public void SetMaxHullPoints(float mhp)
    {
        hullPoints = mhp;
    }

    public void Regenerate()
    {
        if (currentShieldPoints < shieldPower)
        {
            if (currentShieldPoints <= 0)
            {
                EMS.enabled = false;
                currentShieldPoints = (0);
                Invoke("DelayedRegenerate", shieldRechargeDelay);
            }
            else if (currentShieldPoints < shieldPower)
            {
                if ((shieldPower - currentShieldPoints) < shieldRechargeRate)
                {
                    currentShieldPoints = shieldPower;
                }
                else
                {
                    regenOnCoolDown = true;
                    Invoke("AddShield", 2);
                    currentShieldPoints += shieldRechargeRate;
                    EMS.enabled = true;
                }
            }
        }
    }

    void DelayedRegenerate() //called by regenerate method when the recharge delay needs be enacted (shields drop to zero or less)
    {
        currentShieldPoints += shieldRechargeRate;
        EMS.enabled = true;
        CancelInvoke();
    }
    private void AddShield()
    {
        currentShieldPoints += shieldRechargeRate;
        regenOnCoolDown = false;
    }
}
