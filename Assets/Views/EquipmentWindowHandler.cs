using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentWindowHandler : MonoBehaviour
{

    public PlayerObject _POC;
    public Sprite emptySlotImage;

    public Text engineSpeed;
    public Text engineBoostSpeed;
    public Text engineBoostCost;
    public Image equippedEngine;
    public Text reactorMaxenergy;
    public Text reactorRegenRate;
    public Image equippedReactor;
    public Text armorEffectiveness;
    public Image equippedArmor;
    public Text maxShields;
    public Text shieldRegen;
    public Image equippedShield;
    public Text weapon0MinDamage;
    public Text weapon0MaxDamage;
    public Text weapon0EnergyCost;
    public Text weapon0Cooldown;
    public Image equippedWeapon0;
    public Text weapon1MinDamage;
    public Text weapon1MaxDamage;
    public Text weapon1EnergyCost;
    public Text weapon1Cooldown;
    public Image equippedWeapon1;
    public Slider hullBar;
    public Text hullNumber;
    public Slider energyBar;
    public Text energyNumber;


    private void Awake()
    {
        //_POC = FindObjectOfType<PlayerObject>();

    }


    private void Update()
    {
        UpdateHUDVitals();
    }

    void UpdateHUDVitals()
    {

        //Engine values
        if ((!_POC.hull.engineEquipped))
        {
            engineSpeed.text = "0";
            engineBoostSpeed.text = "0";
            engineBoostCost.text = "0";
            equippedEngine.sprite = emptySlotImage;
            equippedEngine.enabled = false;
        }
        else
        {
            engineSpeed.text = _POC.hull.equippedEngine.maxSpeed.ToString();
            engineBoostSpeed.text = _POC.hull.equippedEngine.boostSpeed.ToString();
            engineBoostCost.text = _POC.hull.equippedEngine.boostEnergyCost.ToString();
            equippedEngine.sprite = _POC.hull.equippedEngine.sprite;
            equippedEngine.enabled = true;
        }

        //Reactor values
        if ((!_POC.hull.reactorEquipped))
        {
            reactorMaxenergy.text = "0";
            reactorRegenRate.text = "0";
            equippedReactor.sprite = emptySlotImage;
            equippedReactor.enabled = false;
        }
        else
        {
            reactorMaxenergy.text = _POC.hull.equippedReactor.maxPower.ToString();
            reactorRegenRate.text = _POC.hull.equippedReactor.rechargeRate.ToString();
            equippedReactor.sprite = _POC.hull.equippedReactor.sprite;
            equippedReactor.enabled = true;
        }

        //Armor values
        if ((!_POC.hull.armorEquipped))
        {
            armorEffectiveness.text = "0";
            equippedArmor.sprite = emptySlotImage;
            equippedArmor.enabled = false;
        }
        else
        {
            armorEffectiveness.text = (_POC.hull.equippedArmor.armorLevel * 100).ToString();
            equippedArmor.sprite = _POC.hull.equippedArmor.sprite;
            equippedArmor.enabled = true;
        }

        //Shield values
        if ((!_POC.hull.shieldEquipped))
        {
            maxShields.text = "0";
            shieldRegen.text = "0";
            equippedShield.sprite = emptySlotImage;
            equippedShield.enabled = false;
        }
        else
        {
            maxShields.text = _POC.hull.equippedShields.maxCapacity.ToString();
            shieldRegen.text = _POC.hull.equippedShields.rechargeRate.ToString();
            equippedShield.sprite = _POC.hull.equippedShields.sprite;
            equippedShield.enabled = true;
        }

        //Weapon0 values
        if ((!_POC.hull.weapon0Equipped))
        {
            weapon0MinDamage.text = "0";
            weapon0MaxDamage.text = "0";
            weapon0Cooldown.text = "0";
            weapon0EnergyCost.text = "0";
            equippedWeapon0.sprite = emptySlotImage;
            equippedWeapon0.enabled = false;
        }
        else
        {
            weapon0MinDamage.text = _POC.hull.equippedWeapon0.minDamage.ToString();
            weapon0MaxDamage.text = _POC.hull.equippedWeapon0.maxDamage.ToString();
            weapon0Cooldown.text = _POC.hull.equippedWeapon0.refireRate.ToString();
            weapon0EnergyCost.text = _POC.hull.equippedWeapon0.energyCost.ToString();
            equippedWeapon0.sprite = _POC.hull.equippedWeapon0.sprite;
            equippedWeapon0.enabled = true;
        }

        //Weapon1 values
        if ((!_POC.hull.weapon1Equipped))
        {
            weapon1MinDamage.text = "0";
            weapon1MaxDamage.text = "0";
            weapon1Cooldown.text = "0";
            weapon1EnergyCost.text = "0";
            equippedWeapon1.sprite = emptySlotImage;
            equippedWeapon1.enabled = false;
        }
        else
        {
            weapon1MinDamage.text = _POC.hull.equippedWeapon1.minDamage.ToString();
            weapon1MaxDamage.text = _POC.hull.equippedWeapon1.maxDamage.ToString();
            weapon1Cooldown.text = _POC.hull.equippedWeapon1.refireRate.ToString();
            weapon1EnergyCost.text = _POC.hull.equippedWeapon1.energyCost.ToString();
            equippedWeapon1.sprite = _POC.hull.equippedWeapon1.sprite;
            equippedWeapon1.enabled = true;
        }


    }
}
