// ===============================
// AUTHOR: Justin Laconto
// PURPOSE: Generates equipment with random stats based on settings defined in the inspector. 
// ===============================

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class EquipmentGenerator : MonoBehaviour
{

    public PlayerObject _POC;

    [HideInInspector]
    public List<string> namePrefixCommon;
    [HideInInspector]
    public List<string> namePrefixUncommon;
    [HideInInspector]
    public List<string> namePrefixRare;
    [HideInInspector]
    public List<string> namePrefixEpic;

    [Header("Percentage to increase item stats by rarity")]
    [Header("Epic (0-100% increase)")]
    public float epicModifierMinPercent;
    public float epicModifierMaxPercent;
    [Header("Rare (0-100% increase)")]
    public float rareModifierMinPercent;
    public float rareModifierMaxPercent;
    [Header("Uncommon (0-100% increase)")]
    public float uncommonModifierMinPercent;
    public float uncommonModifierMaxPercent;
    [Header("Common (0-100% increase)")]
    public float commonModifierMinPercent;
    public float commonModifierMaxPercent;

    [HideInInspector]
    public float commonStatModifier;
    [HideInInspector]
    public float uncommonStatModifier;
    [HideInInspector]
    public float rareStatModifier;
    [HideInInspector]
    public float epicStatModifier;
    [HideInInspector]
    public bool generateTierTwo = false;

    [HideInInspector]
    public Item randomlyGeneratedItem;
    [HideInInspector]


    //Reactor
    public Sprite[] reactorSprites;
    [HideInInspector]
    public List<string> reactorTypesTierOne;
    [HideInInspector]
    public List<string> reactorTypesTierTwo;
    [HideInInspector]
    public Reactor reactor;
    [HideInInspector]
    public string reactorName;
    [HideInInspector]
    public string reactorDescription;
    [HideInInspector]
    public string reactorType;
    [HideInInspector]
    public float maxPowerReactor;
    [Header("REACTOR")]
    [HideInInspector]
    public float baseMonetaryValueReactor;
    [Header("Base Monetary Value Range")]
    public float baseMonetaryValueReactorMinTierOne;
    public float baseMonetaryValueReactorMaxTierOne;
    public float baseMonetaryValueReactorMinTierTwo;
    public float baseMonetaryValueReactorMaxTierTwo;
    [Header("Randomly Generated Max Power Range - Tier One")]
    public float maxPowerReactorMinTierOne;
    public float maxPowerReactorMaxTierOne;
    [Header("Randomly Generated Max Power Range - Tier Two")]
    public float maxPowerReactorMinTierTwo;
    public float maxPowerReactorMaxTierTwo;
    [HideInInspector]
    public float rechargeRateReactor;
    [Header("Randomly Generated Reactor Recharge Rate Range (Per 2 Seconds) - Tier One")]
    public float rechargeRateReactorMinTierOne;
    public float rechargeRateReactorMaxTierOne;
    [Header("Randomly Generated Reactor Recharge Rate  Range (Per 2 Seconds) - Tier Two")]
    public float rechargeRateReactorMinTierTwo;
    public float rechargeRateReactorMaxTierTwo;

    //Engine
    [HideInInspector]
    public Sprite[] engineSprites;
    [HideInInspector]
    public List<string> engineTypesTierOne;
    [HideInInspector]
    public List<string> engineTypesTierTwo;
    [HideInInspector]
    public Engine engine;
    [HideInInspector]
    public string engineName;
    [HideInInspector]
    public string engineDescription;
    [HideInInspector]
    public string engineType;
    [HideInInspector]
    private float maxSpeedEngine;
    [Header("ENGINE")]
    [HideInInspector]
    public float baseMonetaryValueEngine;
    [Header("Base Monetary Value Range")]
    public float baseMonetaryValueEngineMinTierOne;
    public float baseMonetaryValueEngineMaxTierOne;
    public float baseMonetaryValueEngineMinTierTwo;
    public float baseMonetaryValueEngineMaxTierTwo;
    [Header("Randomly Generated Max Speed Engine Range - Tier One")]
    public float maxSpeedEngineTierOneMin;
    public float maxSpeedEngineTierOneMax;
    [Header("Randomly Generated Max Speed Engine Range - Tier Two")]
    public float maxSpeedEngineTierTwoMin;
    public float maxSpeedEngineTierTwoMax;
    [HideInInspector]
    private float accelerationEngine;
    [Header("Randomly Generated Engine Acceleration Range - Tier One")]
    public float accelerationEngineTierOneMin;
    public float accelerationEngineTierOneMax;
    [Header("Randomly Generated Engine Accelerationr Range - Tier Two")]
    public float accelerationEngineTierTwoMin;
    public float accelerationEngineTierTwoMax;
    [HideInInspector]
    public float turnSpeedEngine;
    [Header("Randomly Generated Engine Turn Speed Range - Tier One")]
    public float turnSpeedEngineTierOneMin;
    public float turnSpeedEngineTierOneMax;
    [Header("Randomly Generated Engine Turn Speed Range - Tier Two")]
    public float turnSpeedEngineTierTwoMin;
    public float turnSpeedEngineTierTwoMax;
    [HideInInspector]
    public float boostSpeedEngine;
    [Header("Randomly Generated Engine Boost Speed Range - Tier One")]
    public float boostSpeedEngineTierOneMin;
    public float boostSpeedEngineTierOneMax;
    [Header("Randomly Generated Engine Boost Speed Range - Tier Two")]
    public float boostSpeedEngineTierTwoMin;
    public float boostSpeedEngineTierTwoMax;
    [HideInInspector]
    public float boostEnergyCostEngine;
    [Header("Randomly Generated Engine Boost Energy Cost Range - Tier One")]
    public float boostEnergyCostEngineTierOneMin;
    public float boostEnergyCostEngineTierOneMax;
    [Header("Randomly Generated Engine Boost Energy Cost Range - Tier Two")]
    public float boostEnergyCostEngineTierTwoMin;
    public float boostEnergyCostEngineTierTwoMax;
    [HideInInspector]
    public float boostCoolDownEngine;
    [Header("Randomly Generated Engine Boost Cooldown Range - Tier One")]
    public float boostCoolDownEngineTierOneMin;
    public float boostCoolDownEngineTierOneMax;
    [Header("Randomly Generated Engine Boost Cooldown Range - Tier Two")]
    public float boostCoolDownEngineTierTwoMin;
    public float boostCoolDownEngineTierTwoMax;

    //Shield
    [HideInInspector]
    public Sprite[] shieldSprites;
    [HideInInspector]
    public List<string> shieldTypesTierOne;
    [HideInInspector]
    public List<string> shieldTypesTierTwo;
    [HideInInspector]
    public Shield shield;
    [HideInInspector]
    public string shieldName;
    [HideInInspector]
    public string shieldDescription;
    [HideInInspector]
    public string shieldType;
    [HideInInspector]
    public int maxShields;
    [Header("SHIELDS")]
    [HideInInspector]
    public float baseMonetaryValueShield;
    [Header("Base Monetary Value Range")]
    public float baseMonetaryValueShieldMinTierOne;
    public float baseMonetaryValueShieldMaxTierOne;
    public float baseMonetaryValueShieldMinTierTwo;
    public float baseMonetaryValueShieldMaxTierTwo;
    [Header("Randomly Generated Max Shield Range - Tier One")]
    public float maxShieldMinTierOne;
    public float maxShieldMaxTierOne;
    [Header("Randomly Generated Max Shield Range - Tier Two")]
    public float maxShieldMinTierTwo;
    public float maxShieldMaxTierTwo;
    [HideInInspector]
    public float shieldRechargeRate;
    [Header("Randomly Generated Shield Recharge Range (Per 2 Seconds) - Tier One")]
    public float shieldRechargeMinTierOne;
    public float shieldRechargeMaxTierOne;
    [Header("Randomly Generated Shield Recharge Range (Per 2 Seconds) - Tier Two")]
    public float shieldRechargeMinTierTwo;
    public float shieldRechargeMaxTierTwo;
    [HideInInspector]
    public float shieldRechargeDelay;
    [Header("Randomly Generated Shield Recharge Delay Range (In seconds) - Tier One")]
    public float shieldRechargeDelayMinTierOne;
    public float shieldRechargeDelayMaxTierOne;
    [Header("Randomly Generated hield Recharge Delay Range (In secondS) - Tier Two")]
    public float shieldRechargeMinDelayTierTwo;
    public float shieldRechargeMaxDelayTierTwo;
    [HideInInspector]
    public Shield.DamageType dmgTypeWeaknessShield;
    [HideInInspector]
    public float dmgTypeWeaknesseNumShield;
    [Header("Randomly Generated Shield DmgType Weakness Range (1.01-2) - Tier One")]
    public float dmgTypeWeaknessTierOneMin;
    public float dmgTypeWeaknessTierOneMax;
    [Header("Randomly Generated Shield DmgType Weakness Range (1.01-2) - Tier Two")]
    public float dmgTypeWeaknessTierTwoMin;
    public float dmgTypeWeaknessTierTwoMax;
    [HideInInspector]
    public Shield.DamageType dmgTypeResistanceShield;
    [HideInInspector]
    public float dmgTypeResistanceNumShield;
    [Header("Randomly Generated Shield DmgType Resistance Range (1.01-2) - Tier One")]
    public float dmgTypeResistanceTierOneMin;
    public float dmgTypeResistanceTierOneMax;
    [Header("Randomly Generated Shield DmgType Resistance Range (1.01-2) - Tier Two")]
    public float dmgTypeResistanceTierTwoMin;
    public float dmgTypeResistanceTierTwoMax;

    //Armor
    [HideInInspector]
    public Sprite[] armorSprites;
    [HideInInspector]
    public string armorDescription;
    [HideInInspector]
    public Armor armor;
    [HideInInspector]
    public List<string> armorTypesTierOne;
    [HideInInspector]
    public List<string> armorTypesTierTwo;
    [HideInInspector]
    public string armorName;
    [HideInInspector]
    public string armorType;
    [HideInInspector]
    public float baseArmorLevel;
    [Header("ARMOR")]
    [HideInInspector]
    public float baseMonetaryValueArmor;
    [Header("Base Monetary Value Range")]
    public float baseMonetaryValueArmorMinTierOne;
    public float baseMonetaryValueArmorMaxTierOne;
    public float baseMonetaryValueArmorMinTierTwo;
    public float baseMonetaryValueArmorMaxTierTwo;
    [Header("Randomly Generated Base Armor Level Resistance Range (1.01-2) - Tier One")]
    public float baseArmorLevelTierOneMinArmor;
    public float baseArmorLevelTierOneMaxArmor;
    [Header("Randomly Generated Base Armor Level Resistance Range (1.01-2) - Tier Two")]
    public float baseArmorLevelTierTwoMinArmor;
    public float baseArmorLevelTierTwoMaxArmor;
    [HideInInspector]
    public Armor.DamageType dmgTypeWeaknessArmor;
    [HideInInspector]
    public float dmgTypeWeaknesseNumArmor;
    [Header("Randomly Generated Armor DmgType Weakness Range (1.01-2) - Tier One")]
    public float dmgTypeWeaknessTierOneMinArmor;
    public float dmgTypeWeaknessTierOneMaxArmor;
    [Header("Randomly Generated Armor DmgType Weakness Range (1.01-2) - Tier Two")]
    public float dmgTypeWeaknessTierTwoMinArmor;
    public float dmgTypeWeaknessTierTwoMaxArmor;
    [HideInInspector]
    public Armor.DamageType dmgTypeResistanceArmor;
    [HideInInspector]
    public float dmgTypeResistanceNumArmor;
    [Header("Randomly Generated Armor DmgType Resistance Range (1.01-2) - Tier One")]
    public float dmgTypeResistanceTierOneMinArmor;
    public float dmgTypeResistanceTierOneMaxArmor;
    [Header("Randomly Generated Armor DmgType Resistance Range (1.01-2) - Tier Two")]
    public float dmgTypeResistanceTierTwoMinArmor;
    public float dmgTypeResistanceTierTwoMaxArmor;

    //Weapon
    [HideInInspector]
    public Sprite[] weaponSprites;
    [HideInInspector]
    public string weaponName;
    [HideInInspector]
    public string weaponType = "";
    [HideInInspector]
    public string weaponDescription;
    [HideInInspector]
    public Weapon weapon;
    [HideInInspector]
    public string[] weaponTypesTierOne;
    [HideInInspector]
    public List<string> weaponTypesTierTwo;
    [HideInInspector]
    public float minDamageWeapon;
    [Header("WEAPON")]
    [HideInInspector]
    public float baseMonetaryValueWeapon;
    [Header("Base Monetary Value Range")]
    public float baseMonetaryValueWeaponMinTierOne;
    public float baseMonetaryValueWeaponMaxTierOne;
    public float baseMonetaryValueWeaponMinTierTwo;
    public float baseMonetaryValueWeaponMaxTierTwo;
    [Header("Randomly Generated Weapon Min Damage Range - Tier One")]
    public float minDamageMinWeaponTierOne;
    public float minDamageMaxWeaponTierOne;
    [Header("Randomly Generated Weapon Min Damage Range - Tier Two")]
    public float minDamageMinWeaponTierTwo;
    public float minDamageMaxWeaponTierTwo;
    [HideInInspector]
    private float maxDamageWeapon;
    [Header("Randomly Generated Weapon Max Damage Range - Tier One")]
    public float maxDamageMinWeaponTierOne;
    public float maxDamageMaxWeaponTierOne;
    [Header("Randomly Generated Weapon Max Damage Range - Tier Two")]
    public float maxDamageMinWeaponTierTwo;
    public float maxDamageMaxWeaponTierTwo;
    [HideInInspector]
    public float refireRateWeapon;
    [Header("Randomly Generated Weapon Refire Rate Range - Tier One")]
    public float refireRateMinWeaponTierOne;
    public float refireRateMaxWeaponTierOne;
    [Header("Randomly Generated Weapon Refire Rate Range - Tier Two")]
    public float refireRateMinWeaponTierTwo;
    public float refireRateMaxWeaponTierTwo;
    [HideInInspector]
    public float energyCostWeapon;
    [Header("Randomly Generated Weapon Energy Cost Range - Tier One")]
    public float energyCostMinWeaponTierOne;
    public float energyCostMaxWeaponTierOne;
    [Header("Randomly Generated Weapon Energy Cost Range - Tier Two")]
    public float energyCostMinWeaponTierTwo;
    public float energyCostMaxWeaponTierTwo;
    [HideInInspector]
    public float projectilvelocity;
    [Header("Randomly Generated Weapon Energy Cost Range - Tier One")]
    public float projectileVelocityMinWeaponTierOne;
    public float projectileVelocityMaxWeaponTierOne;
    [Header("Randomly Generated Weapon Energy Cost Range - Tier Two")]
    public float projectileVelocityMinWeaponTierTwo;
    public float projectileVelocityMaxWeaponTierTwo;
    [HideInInspector]
    public Weapon.DamageType dmgTypeWeapon;
    [HideInInspector]
    public Projectile projectileModelWeapon;
    [HideInInspector]
    private Projectile[] gaussCannonProj;
    [HideInInspector]
    private Projectile[] phasedPulseCannonProj;
    [HideInInspector]
    private Projectile[] MaserProj;
    [HideInInspector]
    private Projectile[] plasmaCannonProj;
    [HideInInspector]
    private Projectile[] photonCannonProj;
    [HideInInspector]
    private Projectile[] ionCannonProj;
    [HideInInspector]
    private Projectile[] disruptorProj;
    [HideInInspector]
    private Projectile[] lightLaserCannonProj;
    [HideInInspector]
    private Projectile[] heavyLaserCannonProj;

    public Inventory playerInv;

    private void Awake()
    {
     //   playerInv = FindObjectOfType<Inventory>();
        weapon = new Weapon();
        armor = new Armor();
        shield = new Shield();
        reactor = new Reactor();
        engine = new Engine();
        armorSprites = Resources.LoadAll<Sprite>("Sprites/ArmorSprites");
        weaponSprites = Resources.LoadAll<Sprite>("Sprites/WeaponSprites");      
        engineSprites = Resources.LoadAll<Sprite>("Sprites/EngineSprites");
        shieldSprites = Resources.LoadAll<Sprite>("Sprites/ShieldSprites");
        reactorSprites = Resources.LoadAll<Sprite>("Sprites/ReactorSprites");
        weaponSprites = Resources.LoadAll<Sprite>("Sprites/WeaponSprites");
        gaussCannonProj = Resources.LoadAll<Projectile>("Weapon/GaussCannonProjectiles");
        phasedPulseCannonProj = Resources.LoadAll<Projectile>("Weapon/PhasedPulseCannonProjectiles");
        MaserProj = Resources.LoadAll<Projectile>("Weapon/MaserProjectiles");
        plasmaCannonProj = Resources.LoadAll<Projectile>("Weapon/PhasedPlasmaCannonProjectiles");
        photonCannonProj = Resources.LoadAll<Projectile>("Weapon/PhotonCannonProjectiles");
        ionCannonProj = Resources.LoadAll<Projectile>("Weapon/IonCannonProjectiles");
        disruptorProj = Resources.LoadAll<Projectile>("Weapon/DisruptorProjectiles");
        lightLaserCannonProj = Resources.LoadAll<Projectile>("Weapon/LightLaserProjectiles");
        heavyLaserCannonProj = Resources.LoadAll<Projectile>("Weapon/HeavyLaserProjectiles");
        

        PopulateNameLists();

    }

    /// <summary>
    /// Populates the name lists.
    /// </summary>
    private void PopulateNameLists()
    {
        namePrefixCommon.Add("Offbrand");
        namePrefixCommon.Add("Well Used");
        namePrefixCommon.Add("Budget");
        namePrefixCommon.Add("Knockoff");
        namePrefixCommon.Add("Worn Out");
        namePrefixCommon.Add("Starter");
        namePrefixCommon.Add("Damaged");
        namePrefixCommon.Add("Refurbished");

        namePrefixUncommon.Add("Solid");
        namePrefixUncommon.Add("Decent");
        namePrefixUncommon.Add("Reliable");
        namePrefixUncommon.Add("Mid-Range");
        namePrefixUncommon.Add("Proven");
        namePrefixUncommon.Add("Used");
        namePrefixUncommon.Add("Recertified");

        namePrefixRare.Add("Flawless");
        namePrefixRare.Add("High End");
        namePrefixRare.Add("Customized");
        namePrefixRare.Add("Calibrated");
        namePrefixRare.Add("Upgraded");
        namePrefixRare.Add("Military Grade");
        namePrefixRare.Add("Improved");
        namePrefixRare.Add("Advanced");

        namePrefixEpic.Add("Peerless");
        namePrefixEpic.Add("Prototype");
        namePrefixEpic.Add("Cutting Edge");
        namePrefixEpic.Add("High End");
        namePrefixEpic.Add("Custom Built");
        namePrefixEpic.Add("Heavily Modified");
        namePrefixEpic.Add("Legacy");
        namePrefixEpic.Add("Incomparable");

        armorTypesTierOne.Add("Reactive Armor"); //levels 1-60 - Strong Against:Kinetic Weak Against: Heat
        armorTypesTierOne.Add("Electro-Reactive Armor"); //levels 1-60 - Strong Against: Weak Against: Radiation
        armorTypesTierTwo.Add("Coated Reactive Armor"); //levels 20-60 - Strong Against:Kinetic Weak Against: Heat
        armorTypesTierTwo.Add("Advanced Electro-Reactive Armor"); //levels 20-60 - Strong Against: Weak Against: Radiation
        armorTypesTierOne.Add("Ablative Armor"); //levels 1-60 -  Strong Against:EM Weak Against:Kinetic
        armorTypesTierOne.Add("Insulated Ablative Armor"); //levels 1-60 - Strong Against:Radiation Weak Against:Kinetic
        armorTypesTierTwo.Add("Advanced Ablative Armor"); //levels 20-60 - Strong Against: EM Weak Against:Kinetic
        armorTypesTierTwo.Add("Advanced Insulated Ablative Armor"); //levels 20-60 - Strong Against:Radiation Weak Against:Kinetic

        shieldTypesTierOne.Add("Absorptive Shield Generator"); //levels 1-60 - Strong Against:Heat Weak Against:Radiation
        shieldTypesTierTwo.Add("Advanced Absorptive Shield Generator"); //levels 20-60 - Strong Against:Heat Weak Against:Radiation
        shieldTypesTierTwo.Add("Multi-Phasic Adaptive Shield Generator"); // levels 20-60 - Strong Against:Radiation Weak Against:Heat
        shieldTypesTierOne.Add("Adaptive Shield Generator"); // levels 1-60 - Strong Against:Radiation Weak Against:Heat
        shieldTypesTierOne.Add("Graviton Field Generator");//levels 1-60 - Strong Against:Heat Weak Against:EM
        shieldTypesTierTwo.Add("Bi-Drectional Graviton Field Generator"); //levels 20-60 - Strong Against:Heat Weak Against:EM
        shieldTypesTierTwo.Add("Tri-Phasial Shield Generator"); //levels 1-60 - - Strong Against:EM Weak Against:Heat
        shieldTypesTierOne.Add("Bi-Phasial Shield Generator"); //levels 20-60 - Strong Against:EM Weak Against:Heat

        weaponTypesTierOne = new string[] { "Gauss Cannon", "Maser", "Ion Cannon" , "Light Laser" };
     //   weaponTypesTierOne.Add("Gauss Cannon"); //levels 1-60 - Damage Type: Kinetic
        weaponTypesTierTwo.Add("Phased Pulse Cannon"); //levels 20-60 - Damage Type: Kinetic
        //weaponTypesTierOne.Add("Maser"); //levels 1-60 - Damage Type: Radiation
        weaponTypesTierTwo.Add("Plasma Cannon"); // levels 20-60 - Damage Type: Heat
        weaponTypesTierTwo.Add("Photon Cannon");//levels 20-60 - Damage Type: Radiation
      //  weaponTypesTierOne.Add("Ion Cannon"); //levels 1-60 - Damage Type: EM
        weaponTypesTierTwo.Add("Disruptor");//levels 20-60 - Damage Type: EM
     //   weaponTypesTierOne.Add("Light Laser"); //levels 1-60 - Damage Type: Heat
        weaponTypesTierTwo.Add("Heavy Laser");//levels 20-60 - Damage Type: Heat


        reactorTypesTierTwo.Add("Molten Salt Reactor"); //mid range, 20-60
        reactorTypesTierOne.Add("Pebble-Bed Reactor"); //lowest end, levels 1-60
        reactorTypesTierTwo.Add("Fusion Reactor"); //High end, levels 20-60
        reactorTypesTierOne.Add("Heavy Water Reactor"); //lowest end, levels 1-60

        engineTypesTierOne.Add("Ion Engines"); //slowest, level 1-60
        engineTypesTierTwo.Add("Quantum Vacuum Thrusters"); //High end, levels 20-60
        engineTypesTierOne.Add("RF Resonance Thrusters"); //mid range, 1-60
        engineTypesTierTwo.Add("Magnetoplasma Impulse Engines"); //mid range, 20-60
     
    }

    /// <summary>
    /// Generates a new weapon on a set quality.
    /// </summary>
    /// <param name="quality">Sets the quality of the generated weapon. Accepts the following strings: Epic, Rare, Uncommon, Common.</param>
    private void GenerateWeapon(string quality)
    {
        GenerateWeaponBaseStats();
        float maxdamageweapon = 0;
        float mindamageweapon = 0;
        float refirerateweapon = 0;
        float energycostweapon = 0;
        float projectilvelocity = 0;
        float monetaryvalueweapon = 0;


        switch (quality)
        {
            case "Epic":
                maxdamageweapon = maxDamageWeapon * epicStatModifier;
                mindamageweapon = minDamageWeapon * epicStatModifier;
                refirerateweapon = (2 - epicStatModifier) * refireRateWeapon;
                energycostweapon = (2 - epicStatModifier) * energyCostWeapon;
                monetaryvalueweapon = baseMonetaryValueWeapon *  epicStatModifier;
                weaponName = namePrefixEpic[Random.Range(0, namePrefixEpic.Count() + 1)] + " " + weaponType;           
                weapon.itemQuality = "Epic";
                break;
            case "Rare":
                maxdamageweapon = maxDamageWeapon * rareStatModifier;
                mindamageweapon = minDamageWeapon * rareStatModifier;
                refirerateweapon = (2 - rareStatModifier) * refireRateWeapon;
                energycostweapon = (2 - rareStatModifier) * energyCostWeapon;
                monetaryvalueweapon = baseMonetaryValueWeapon * rareStatModifier;
                weaponName = namePrefixCommon[Random.Range(0, namePrefixCommon.Count())] + " " + weaponType;
                weapon.itemQuality = "Rare";
                break;
            case "Uncommon":
                maxdamageweapon = maxDamageWeapon * uncommonStatModifier;
                mindamageweapon = minDamageWeapon * uncommonStatModifier;
                refirerateweapon = (2 - uncommonStatModifier) * refireRateWeapon;
                energycostweapon = (2 - uncommonStatModifier) * energyCostWeapon;
                monetaryvalueweapon = baseMonetaryValueWeapon *  uncommonStatModifier;
                weaponName = namePrefixUncommon[Random.Range(0, namePrefixUncommon.Count())] + " " + weaponType;
               weapon.itemQuality = "Uncommon";
                break;
            case "Common":
                maxdamageweapon = maxDamageWeapon * commonStatModifier;
                mindamageweapon = minDamageWeapon * commonStatModifier;
                refirerateweapon = (2 - commonStatModifier) * refireRateWeapon;
                energycostweapon = (2 - commonStatModifier) * energyCostWeapon;
                monetaryvalueweapon = baseMonetaryValueWeapon * commonStatModifier;
                weaponName = namePrefixCommon[Random.Range(0, namePrefixCommon.Count())] + " " + weaponType;
                weapon.itemQuality = "Common";
                break;
        }

        weapon.InitializeEquipment(Mathf.Round(mindamageweapon),Mathf.Round(maxdamageweapon), dmgTypeWeapon, refirerateweapon, energycostweapon, projectilvelocity, projectileModelWeapon, weaponSprites[Random.Range(0, weaponSprites.Count())], 
            ItemType.Weapon, weaponName, true, weaponDescription, Mathf.Round(monetaryvalueweapon));
    }

    /// <summary>
    /// Generates the weapon base stats using user defined parameters.
    /// </summary>
    private void GenerateWeaponBaseStats()
    {
        if (generateTierTwo)
        {
            int chooseTierToCreate = Random.Range(0, 1);

            if (chooseTierToCreate == 0)
            {
                weaponType = weaponTypesTierOne[Random.Range(0, weaponTypesTierOne.Count() + 1)];
                minDamageWeapon = Random.Range(minDamageMinWeaponTierOne, maxDamageMinWeaponTierOne);
                maxDamageWeapon = Random.Range(minDamageMaxWeaponTierOne, maxDamageMaxWeaponTierOne);
                refireRateWeapon = Random.Range(refireRateMinWeaponTierOne, refireRateMaxWeaponTierOne);
                energyCostWeapon = Random.Range(energyCostMinWeaponTierOne, energyCostMaxWeaponTierOne);
                baseMonetaryValueWeapon = Random.Range(baseMonetaryValueWeaponMinTierOne, baseMonetaryValueWeaponMaxTierOne);
                projectilvelocity = Random.Range(projectileVelocityMinWeaponTierOne, projectileVelocityMaxWeaponTierOne);
            }
            else
            {
                weaponType = weaponTypesTierTwo[Random.Range(0, weaponTypesTierTwo.Count() + 1)];
                minDamageWeapon = Random.Range(minDamageMinWeaponTierTwo, maxDamageMinWeaponTierTwo);
                maxDamageWeapon = Random.Range(minDamageMaxWeaponTierTwo, maxDamageMaxWeaponTierTwo);
                refireRateWeapon = Random.Range(refireRateMinWeaponTierTwo, refireRateMaxWeaponTierTwo);
                energyCostWeapon = Random.Range(energyCostMinWeaponTierTwo, energyCostMaxWeaponTierTwo);
                baseMonetaryValueWeapon = Random.Range(baseMonetaryValueWeaponMinTierTwo, baseMonetaryValueWeaponMaxTierTwo);
                projectilvelocity = Random.Range(projectileVelocityMinWeaponTierTwo, projectileVelocityMaxWeaponTierTwo);
            }
        }

        else
        {
            Debug.Log(weaponTypesTierOne[Random.Range(0, 3)]);
            weaponType = weaponTypesTierOne[Random.Range(0, weaponTypesTierOne.Length)];
            minDamageWeapon = Random.Range(minDamageMinWeaponTierOne, maxDamageMinWeaponTierOne);
            maxDamageWeapon = Random.Range(minDamageMaxWeaponTierOne, maxDamageMaxWeaponTierOne);
            refireRateWeapon = Random.Range(refireRateMinWeaponTierOne, refireRateMaxWeaponTierOne);
            energyCostWeapon = Random.Range(energyCostMinWeaponTierOne, energyCostMaxWeaponTierOne);
            baseMonetaryValueWeapon = Random.Range(baseMonetaryValueWeaponMinTierOne, baseMonetaryValueWeaponMaxTierOne);
        }

        if (weaponType == ("Gauss Cannon"))
        {
            Debug.Log("Weapon if statement passed");
            dmgTypeWeapon = Weapon.DamageType.Kinetic;
            projectileModelWeapon = gaussCannonProj[Random.Range(0, gaussCannonProj.Count())];
            weaponDescription = "The Gauss cannon uses superconducting magnets to accelerate alloy slugs to astronmical speeds.";
        }
        if (weaponType == ("Particle Pulse Cannon"))
        {
            Debug.Log("Weapon if statement passed");
            dmgTypeWeapon = Weapon.DamageType.Kinetic;
            projectileModelWeapon = phasedPulseCannonProj[Random.Range(0, phasedPulseCannonProj.Count())];
            weaponDescription = "One of Humanities first attempts at particle weaponry, clearly it was quite successful";
        }
        if (weaponType == ("Maser"))
        {
            Debug.Log("Weapon if statement passed");
            dmgTypeWeapon = Weapon.DamageType.Radiation;
            projectileModelWeapon = MaserProj[Random.Range(0, MaserProj.Count())];
            weaponDescription = "Emits deadly levels of high energy radiation.  Useful against electronics such as sub-systems, and shield emitters.";
        }
        if (weaponType == ("Plasma Cannon"))
        {
            Debug.Log("Weapon if statement passed");
            dmgTypeWeapon = Weapon.DamageType.Heat;
            projectileModelWeapon = plasmaCannonProj[Random.Range(0, plasmaCannonProj.Count())];
            weaponDescription = "Utilizes an advanced magnetic resonance chamber to contain and focus superheated plasma into a projectile.";
        }
        if (weaponType == ("Photon Cannon"))
        {
            Debug.Log("Weapon if statement passed");
            dmgTypeWeapon = Weapon.DamageType.Radiation;
            projectileModelWeapon = photonCannonProj[Random.Range(0, photonCannonProj.Count())];
            weaponDescription = "Release large bursts of directed Gamma radiation similiar to the Maser.";
        }
        if (weaponType == ("Ion Cannon"))
        {
            Debug.Log("Weapon if statement passed");
            dmgTypeWeapon = Weapon.DamageType.EM;
            projectileModelWeapon = ionCannonProj[Random.Range(0, ionCannonProj.Count())];
            weaponDescription = "Fires ionically charged particles releasing electromag-     entic radiation on impact, effective against energy shielding.";
        }
        if (weaponType == ("Disruptor"))
        {
            Debug.Log("Weapon if statement passed");
            dmgTypeWeapon = Weapon.DamageType.EM;
            projectileModelWeapon = disruptorProj[Random.Range(0, disruptorProj.Count())];
            weaponDescription = "Similiar to the ion cannon the Disrupter deals EM damage, though it's slower projectiles do far greater damage.";
        }
        if (weaponType == ("Light Laser"))
        {
            Debug.Log("Weapon if statement passed");
            dmgTypeWeapon = Weapon.DamageType.Heat;
            projectileModelWeapon = lightLaserCannonProj[Random.Range(0, lightLaserCannonProj.Count())];
            weaponDescription = "The long favored weapon of modern day space comb-     at. Cheap, reliable, and effective. ";
        }
        if (weaponType == ("Heavy Laser"))
        {
            Debug.Log("Weapon if statement passed");
            dmgTypeWeapon = Weapon.DamageType.Heat;
            projectileModelWeapon = heavyLaserCannonProj[Random.Range(0, heavyLaserCannonProj.Count())];
            weaponDescription = "A far more capable version of the Light Laser Cannon featuring upgraded beam emmiters and larger capacitors";
        }
    
    }
    /// <summary>
    /// Generates the reactor base stats using user defined parameters.
    /// </summary>
    private void GenerateReactorBaseStats()
    {
        if (generateTierTwo)
        {
            int chooseTierToCreate = Random.Range(0, 1);

            if (chooseTierToCreate == 0)
            {
                reactorType = reactorTypesTierOne[Random.Range(0, reactorTypesTierOne.Count())];
                maxPowerReactor = Random.Range(maxPowerReactorMinTierOne, maxPowerReactorMaxTierOne);
                rechargeRateReactor = Random.Range(rechargeRateReactorMinTierOne, rechargeRateReactorMaxTierOne);
                baseMonetaryValueReactor = Random.Range(baseMonetaryValueReactorMinTierOne, baseMonetaryValueReactorMaxTierOne);
            }
            else
            {
                reactorType = armorTypesTierTwo[Random.Range(0, reactorTypesTierTwo.Count())];
                maxPowerReactor = Random.Range(maxPowerReactorMinTierTwo, maxPowerReactorMaxTierTwo);
                rechargeRateReactor = Random.Range(rechargeRateReactorMinTierTwo, rechargeRateReactorMaxTierTwo);
                baseMonetaryValueReactor = Random.Range(baseMonetaryValueReactorMinTierTwo, baseMonetaryValueReactorMaxTierOne);
            }
        }

        else
        {
            reactorType = reactorTypesTierOne[Random.Range(0, reactorTypesTierOne.Count())];
            maxPowerReactor = Random.Range(maxPowerReactorMinTierOne, maxPowerReactorMaxTierOne);
            rechargeRateReactor = Random.Range(rechargeRateReactorMinTierOne, rechargeRateReactorMaxTierOne);
            baseMonetaryValueReactor = Random.Range(baseMonetaryValueReactorMinTierOne, baseMonetaryValueReactorMaxTierOne);
        }

        if (reactorType.Contains("Molten Salt Reactor"))
        {
            reactorDescription = "A variation of one of the first commercially developed liquid fuel nuclear fission reactors, capable of consuming up to 99% of supplied fuel.";
        }
        if (reactorType.Contains("Pebble-Bed Reactor"))
        {
            reactorDescription = "The final variation of solid fuel fission reactors develo-     ped before the technology was abadoned for more ef-     ficient nuclear reactor types.";
        }
        if (reactorType.Contains("Heavy Water Reactor"))
        {
            reactorDescription = "The oldest and least efficicent fission reactor design        still in use. Requires highly refined fuel rods which      become useless after consuming less than 5% of the-     ir total yield.";
        }
        if (reactorType.Contains("Fusion Reactor"))
        {
            reactorDescription = "One of humanities most significant achievements. Fusion reactors provide limitless, clean and cheap energy. ";
        }
    }

    /// <summary>
    /// Generates reactor.
    /// </summary>
    /// <param name="quality">The quality. Accepts the following strings: Epic, Rare, Uncommon, Common.</param>
    private void GenerateReactor(string quality)
    {
        GenerateReactorBaseStats();

        float maxpower = 0;
        float rechargeratereactor = 0;
        float monetaryvaluereactor = 0;

        switch (quality)
        {
            case "Epic":
                maxpower = maxPowerReactor *  epicStatModifier;
                GenerateRandomModifiers();
                rechargeratereactor = rechargeRateReactor * epicStatModifier;
                GenerateRandomModifiers();
                monetaryvaluereactor = baseMonetaryValueReactor * epicStatModifier;
                reactorName = namePrefixEpic[Random.Range(0, namePrefixEpic.Count())] + " " + reactorType;
                reactor.itemQuality = "Epic";
                break;
            case "Rare":
                maxpower = maxPowerReactor * rareStatModifier;
                GenerateRandomModifiers();
                rechargeratereactor = rechargeRateReactor *  rareStatModifier;
                GenerateRandomModifiers();
                monetaryvaluereactor = baseMonetaryValueReactor * rareStatModifier;
                reactorName = namePrefixRare[Random.Range(0, namePrefixRare.Count())] + " " + reactorType;
                reactor.itemQuality = "Rare";
                break;
            case "Uncommon":
                maxpower = maxPowerReactor * uncommonStatModifier;
                GenerateRandomModifiers();
                rechargeratereactor = rechargeRateReactor *  uncommonStatModifier;
                GenerateRandomModifiers();
                monetaryvaluereactor = baseMonetaryValueReactor * uncommonStatModifier;
                reactorName = namePrefixUncommon[Random.Range(0, namePrefixUncommon.Count())] + " " + reactorType;
                reactor.itemQuality = "Uncommon";
                break;
            case "Common":
                maxpower = maxPowerReactor * commonStatModifier;
                GenerateRandomModifiers();
                rechargeratereactor = rechargeRateReactor * commonStatModifier;
                GenerateRandomModifiers();
                monetaryvaluereactor = baseMonetaryValueReactor * commonStatModifier;
                reactorName = namePrefixCommon[Random.Range(0, namePrefixCommon.Count())] + " " + reactorType;
                reactor.itemQuality = "Common";
                break;
        }
        reactor.InitializeEquipment(Mathf.Round(maxpower), rechargeratereactor, reactorSprites[Random.Range(0, reactorSprites.Count())], //removed +1 from afetr reactorsprites.count
            ItemType.Reactor, reactorName, true, reactorDescription, Mathf.Round(monetaryvaluereactor));

    }

    /// <summary>
    /// Generates the engine base stats using user defined parameters.
    /// </summary>
    private void GenerateEngineBaseStats()
    {
        if (generateTierTwo)
        {
            int chooseTierToCreate = Random.Range(0, 1);

            if (chooseTierToCreate == 0)
            {
                engineType = engineTypesTierOne[Random.Range(0, engineTypesTierOne.Count)];
                maxSpeedEngine = Random.Range(maxSpeedEngineTierOneMin, maxSpeedEngineTierOneMax);
                accelerationEngine = Random.Range(accelerationEngineTierOneMin, accelerationEngineTierOneMax);
                turnSpeedEngine = Random.Range(turnSpeedEngineTierOneMin, turnSpeedEngineTierOneMax);
                boostSpeedEngine = Random.Range(boostSpeedEngineTierOneMin, boostSpeedEngineTierOneMax);
                boostCoolDownEngine = Random.Range(boostCoolDownEngineTierOneMin, boostCoolDownEngineTierOneMax);
                boostEnergyCostEngine = Random.Range(boostEnergyCostEngineTierOneMin, boostEnergyCostEngineTierOneMax);
                baseMonetaryValueEngine = Random.Range(baseMonetaryValueEngineMinTierOne, baseMonetaryValueEngineMaxTierOne);
            }
            else
            {
                engineType = engineTypesTierTwo[Random.Range(0, engineTypesTierTwo.Count)];
                maxSpeedEngine = Random.Range(maxSpeedEngineTierTwoMin, maxSpeedEngineTierTwoMax);
                accelerationEngine = Random.Range(accelerationEngineTierTwoMin, accelerationEngineTierTwoMax);
                turnSpeedEngine = Random.Range(turnSpeedEngineTierTwoMin, turnSpeedEngineTierTwoMax);
                boostSpeedEngine = Random.Range(boostSpeedEngineTierTwoMin, boostSpeedEngineTierTwoMax);
                boostCoolDownEngine = Random.Range(boostCoolDownEngineTierTwoMin, boostCoolDownEngineTierTwoMax);
                boostEnergyCostEngine = Random.Range(boostEnergyCostEngineTierTwoMin, boostEnergyCostEngineTierTwoMax);
                baseMonetaryValueEngine = Random.Range(baseMonetaryValueEngineMinTierTwo, baseMonetaryValueEngineMaxTierTwo);
            }
        }

        else
        {
            engineType = engineTypesTierOne[Random.Range(0, engineTypesTierOne.Count)];
            maxSpeedEngine = Random.Range(maxSpeedEngineTierOneMin, maxSpeedEngineTierOneMax);
            accelerationEngine = Random.Range(accelerationEngineTierOneMin, accelerationEngineTierOneMax);
            turnSpeedEngine = Random.Range(turnSpeedEngineTierOneMin, turnSpeedEngineTierOneMax);
            boostSpeedEngine = Random.Range(boostSpeedEngineTierOneMin, boostSpeedEngineTierOneMax);
            boostCoolDownEngine = Random.Range(boostCoolDownEngineTierOneMin, boostCoolDownEngineTierOneMax);
            boostEnergyCostEngine = Random.Range(boostEnergyCostEngineTierOneMin, boostEnergyCostEngineTierOneMax);
            baseMonetaryValueEngine = Random.Range(baseMonetaryValueEngineMinTierOne, baseMonetaryValueEngineMaxTierOne);
        }

        if (engineType.Contains("Ion Engines"))
        {            
            engineDescription = "These engines generate thrust by firing beams of electrically charged atoms called Ions.";
        }
        if (engineType.Contains("Quantum Vacuum Thrusters"))
        {
            engineDescription = "Quantum Vacuum Thrusters utilize the Casimir effect to create thrust proportional the the amount of energy provided.";
        }
        if (engineType.Contains("RF Resonance Thrusters"))
        {
            engineDescription = "These thrusters make use of channeled microwaves       to propel the space craft.";
        }
        if (engineType.Contains("Magnetoplasma Impulse Engines"))
        {
            engineDescription = "The most effective engines available, these engines utizile super heated plasma focues by a magnetic field to move the space craft.";
        }
       
    }

    /// <summary>
    /// Generates engine.
    /// </summary>
    /// <param name="quality">The quality. Accepts the following strings: Epic, Rare, Uncommon, Common.</param>
    private void GenerateEngine(string quality)
    {
        GenerateEngineBaseStats();
        float maxspeed = 0;
        float accelaration = 0;
        float turnspeed = 0;
        float boostspeed = 0;
        float boostcooldown = 0;
        float boostenergycost = 0;
        float monetaryvalueengine = 0;

        switch (quality)
        {
            case "Epic":
                maxspeed = maxSpeedEngine *  epicStatModifier;
                GenerateRandomModifiers();
                accelaration = accelerationEngine * epicStatModifier;
                GenerateRandomModifiers();
                turnspeed = turnSpeedEngine * epicStatModifier;
                GenerateRandomModifiers();
                boostspeed = boostSpeedEngine * epicStatModifier;
                GenerateRandomModifiers();
                boostcooldown =  (2 - epicStatModifier) * boostCoolDownEngine;
                GenerateRandomModifiers();
                boostenergycost = (2 - epicStatModifier) * boostEnergyCostEngine;
                engineName = namePrefixEpic[Random.Range(0, namePrefixEpic.Count())] + " " + engineType;
                monetaryvalueengine = baseMonetaryValueEngine * epicStatModifier;
                engine.itemQuality = "Epic";
                break;
            case "Rare":
                maxspeed = maxSpeedEngine * rareStatModifier;
                GenerateRandomModifiers();
                accelaration = accelerationEngine * rareStatModifier;
                GenerateRandomModifiers();
                turnspeed = turnSpeedEngine * rareStatModifier;
                GenerateRandomModifiers();
                boostspeed = boostSpeedEngine * rareStatModifier;
                GenerateRandomModifiers();
                boostcooldown =  (2 - rareStatModifier) * boostCoolDownEngine;
                GenerateRandomModifiers();
                boostenergycost = (2 - rareStatModifier) * boostEnergyCostEngine;
                engineName = namePrefixRare[Random.Range(0, namePrefixRare.Count())] + " " + engineType;
                monetaryvalueengine = baseMonetaryValueEngine * rareStatModifier;
                engine.itemQuality = "Rare";
                break;
            case "Uncommon":
                maxspeed = maxSpeedEngine * uncommonStatModifier;
                GenerateRandomModifiers();
                accelaration = accelerationEngine * uncommonStatModifier;
                GenerateRandomModifiers();
                turnspeed = turnSpeedEngine * uncommonStatModifier;
                GenerateRandomModifiers();
                boostspeed = boostSpeedEngine * uncommonStatModifier;
                GenerateRandomModifiers();
                boostcooldown = (2 - uncommonStatModifier) * boostCoolDownEngine;
                GenerateRandomModifiers();
                boostenergycost = (2 - uncommonStatModifier)  * boostEnergyCostEngine;
                engineName = namePrefixUncommon[Random.Range(0, namePrefixUncommon.Count())] + " " + engineType;
                monetaryvalueengine = baseMonetaryValueEngine * uncommonStatModifier;
                engine.itemQuality = "Uncommon";
                break;
            case "Common":
                maxspeed = maxSpeedEngine * commonStatModifier;
                GenerateRandomModifiers();
                accelaration = accelerationEngine * commonStatModifier;
                GenerateRandomModifiers();
                turnspeed = turnSpeedEngine * commonStatModifier;
                GenerateRandomModifiers();
                boostspeed = boostSpeedEngine * commonStatModifier;
                GenerateRandomModifiers();
                boostcooldown =  (2 - commonStatModifier) * boostCoolDownEngine;
                GenerateRandomModifiers();
                boostenergycost = (2 - commonStatModifier) * boostEnergyCostEngine;
                engineName = namePrefixCommon[Random.Range(0, namePrefixCommon.Count())] + " " + engineType;
                monetaryvalueengine = baseMonetaryValueEngine * commonStatModifier;
                engine.itemQuality = "Common";
                break;
        }

        engine.InitializeEquipment(Mathf.Round(maxspeed),Mathf.Round(turnspeed), Mathf.Round(accelaration),Mathf.Round(boostspeed), boostenergycost, boostcooldown, engineSprites[Random.Range(0, engineSprites.Count())], 
            ItemType.Engine, engineName, true, engineDescription, Mathf.Round(monetaryvalueengine));

    }


    /// <summary>
    /// Generates the armor base stats using user defined parameters.
    /// </summary>
    private void GenerateArmorBaseStats()
    {

        if (generateTierTwo)
        {
            int chooseTierToCreate = Random.Range(0, 1);

            if (chooseTierToCreate == 0)
            {
                armorType = armorTypesTierOne[Random.Range(0, armorTypesTierOne.Count())];
                baseArmorLevel = Random.Range(baseArmorLevelTierOneMinArmor, baseArmorLevelTierOneMaxArmor);
                baseMonetaryValueArmor = Random.Range(baseMonetaryValueArmorMinTierOne, baseMonetaryValueArmorMaxTierOne);
            }
            else
            {
                armorType = armorTypesTierTwo[Random.Range(0, armorTypesTierTwo.Count())];
                baseArmorLevel = Random.Range(baseArmorLevelTierTwoMinArmor, baseArmorLevelTierTwoMaxArmor);
                baseMonetaryValueArmor = Random.Range(baseMonetaryValueArmorMinTierTwo, baseMonetaryValueArmorMaxTierTwo);
            }
        }

        else
        {
            armorType = armorTypesTierOne[Random.Range(0, armorTypesTierOne.Count())];
            baseArmorLevel = Random.Range(baseArmorLevelTierOneMinArmor, baseArmorLevelTierOneMaxArmor);
            baseMonetaryValueArmor = Random.Range(baseMonetaryValueArmorMinTierOne, baseMonetaryValueArmorMaxTierOne);
        }

        if (armorType.Contains("Reactive Armor"))
        {
            dmgTypeResistanceArmor = Armor.DamageType.Kinetic;
            dmgTypeWeaknessArmor = Armor.DamageType.Heat;
            dmgTypeWeaknesseNumArmor = Random.Range(dmgTypeWeaknessTierOneMin, dmgTypeWeaknessTierOneMax);
            dmgTypeResistanceNumArmor = Random.Range(dmgTypeResistanceTierOneMin, dmgTypeResistanceTierOneMax);
            armorDescription = "Reactive armor is specially designed to withstand      extreme kinect impact.";
        }
        if (armorType.Contains("Electro-Reactive Armor"))
        {
            dmgTypeResistanceArmor = Armor.DamageType.Kinetic;
            dmgTypeWeaknessArmor = Armor.DamageType.Radiation;
            dmgTypeWeaknesseNumArmor = Random.Range(dmgTypeWeaknessTierOneMin, dmgTypeWeaknessTierOneMax);
            dmgTypeResistanceNumArmor = Random.Range(dmgTypeResistanceTierOneMin, dmgTypeResistanceTierOneMax);
            armorDescription = "This Reactive Armor variation uses an electic charge       and huge capactiors to help mitigate kinect impact.";
        }
        if (armorType.Contains("Ablative Armor"))
        {
            dmgTypeResistanceArmor = Armor.DamageType.EM;
            dmgTypeWeaknessArmor = Armor.DamageType.Kinetic;
            dmgTypeWeaknesseNumArmor = Random.Range(dmgTypeWeaknessTierOneMin, dmgTypeWeaknessTierOneMax);
            dmgTypeResistanceNumArmor = Random.Range(dmgTypeResistanceTierOneMin, dmgTypeResistanceTierOneMax);
            armorDescription = "Ablative armor protects your ship against cosmic electromagnetic radiation.";
        }
        if (armorType.Contains("Insulated Ablative Armor"))
        {
            dmgTypeResistanceArmor = Armor.DamageType.Radiation;
            dmgTypeWeaknessArmor = Armor.DamageType.Kinetic;
            dmgTypeWeaknesseNumArmor = Random.Range(dmgTypeWeaknessTierOneMin, dmgTypeWeaknessTierOneMax);
            dmgTypeResistanceNumArmor = Random.Range(dmgTypeResistanceTierOneMin, dmgTypeResistanceTierOneMax);
            armorDescription = "This armor variation is insulated against high energy      radiation";
        }
        if (armorType.Contains("Coated Reactive Armor"))
        {
            dmgTypeResistanceArmor = Armor.DamageType.Kinetic;
            dmgTypeWeaknessArmor = Armor.DamageType.Heat;
            dmgTypeWeaknesseNumArmor = Random.Range(dmgTypeWeaknessTierTwoMin, dmgTypeWeaknessTierTwoMax);
            dmgTypeResistanceNumArmor = Random.Range(dmgTypeResistanceTierTwoMin, dmgTypeResistanceTierTwoMax);
            armorDescription = "Reactive armor is specially designed to withstand      extreme kinect impact.";
        }
        if (armorType.Contains("Advanced Electro-Reactive Armor"))
        {
            dmgTypeResistanceArmor = Armor.DamageType.Kinetic;
            dmgTypeWeaknessArmor = Armor.DamageType.Radiation;
            dmgTypeWeaknesseNumArmor = Random.Range(dmgTypeWeaknessTierTwoMin, dmgTypeWeaknessTierTwoMax);
            dmgTypeResistanceNumArmor = Random.Range(dmgTypeResistanceTierTwoMin, dmgTypeResistanceTierTwoMax);
            armorDescription = "This Reactive Armor variation uses an electic charge and huge capactiors to help mitigate kinect impact.";
        }
        if (armorType.Contains("Advanced Ablative Armor"))
        {
            dmgTypeResistanceArmor = Armor.DamageType.EM;
            dmgTypeWeaknessArmor = Armor.DamageType.Kinetic;
            dmgTypeWeaknesseNumArmor = Random.Range(dmgTypeWeaknessTierTwoMin, dmgTypeWeaknessTierTwoMax);
            dmgTypeResistanceNumArmor = Random.Range(dmgTypeResistanceTierTwoMin, dmgTypeResistanceTierTwoMax);
            armorDescription = "Ablative armor protects your ship against cosmic electromagnetic radiation.";
        }
        if (armorType.Contains("Advanced Insulated Ablative Armor"))
        {
            dmgTypeResistanceArmor = Armor.DamageType.Radiation;
            dmgTypeWeaknessArmor = Armor.DamageType.Kinetic;
            dmgTypeWeaknesseNumArmor = Random.Range(dmgTypeWeaknessTierTwoMin, dmgTypeWeaknessTierTwoMax);
            dmgTypeResistanceNumArmor = Random.Range(dmgTypeResistanceTierTwoMin, dmgTypeResistanceTierTwoMax);
            armorDescription = "This armor variation is insulated against high energy radiation";
        }        

    }

    /// <summary>
    /// Generates armor.
    /// </summary>
    /// <param name="quality">The quality. Accepts the following strings: Epic, Rare, Uncommon, Common.</param>
    private void GenerateArmor(string quality)
    {

        GenerateArmorBaseStats();
        float armorlevel = 0;
        float monetaryvaluearmor = 0;
        float dmgresistarmor = 0;
        float dmgweaknessarmor = 0;


        switch (quality)
        {
            case "Epic":
                armorlevel = baseArmorLevel * epicStatModifier;
                GenerateRandomModifiers();
                dmgweaknessarmor = (2 - epicStatModifier) * dmgTypeWeaknesseNumArmor;
                GenerateRandomModifiers();
                dmgresistarmor = dmgTypeResistanceNumArmor * epicStatModifier;
                GenerateRandomModifiers();
                monetaryvaluearmor = baseMonetaryValueArmor * epicStatModifier;
                armorName = namePrefixEpic[Random.Range(0, namePrefixEpic.Count())] + " " + armorType;
                armor.itemQuality = "Epic";
                break;
            case "Rare":
                armorlevel = baseArmorLevel * rareStatModifier;
                GenerateRandomModifiers();
                dmgweaknessarmor = (2 - rareStatModifier) * dmgTypeWeaknesseNumArmor;
                GenerateRandomModifiers();
                dmgresistarmor = dmgTypeResistanceNumArmor * rareStatModifier;
                GenerateRandomModifiers();
                monetaryvaluearmor = baseMonetaryValueArmor * rareStatModifier;
                armorName = namePrefixRare[Random.Range(0, namePrefixRare.Count())] + " " + armorType;
                armor.itemQuality = "Rare";
                break;
            case "Uncommon":
                armorlevel = baseArmorLevel * uncommonStatModifier;
                GenerateRandomModifiers();
                dmgweaknessarmor = (2 - uncommonStatModifier) * dmgTypeWeaknesseNumArmor;
                GenerateRandomModifiers();
                dmgresistarmor = dmgTypeResistanceNumArmor * uncommonStatModifier;
                GenerateRandomModifiers();
                monetaryvaluearmor = baseMonetaryValueArmor * uncommonStatModifier; ;
                armorName = namePrefixUncommon[Random.Range(0, namePrefixUncommon.Count())] + " " + armorType;
                armor.itemQuality = "Uncommon";
                break;
            case "Common":
                armorlevel = baseArmorLevel * commonStatModifier;
                GenerateRandomModifiers();
                dmgweaknessarmor = (2 - commonStatModifier) * dmgTypeWeaknesseNumArmor;
                GenerateRandomModifiers();
                dmgresistarmor = dmgTypeResistanceNumArmor * commonStatModifier;
                GenerateRandomModifiers();
                monetaryvaluearmor  = baseMonetaryValueArmor * commonStatModifier;
                armorName = namePrefixCommon[Random.Range(0, namePrefixCommon.Count())] + " " + armorType;
                armor.itemQuality = "Common";
                break;
        }

        armor.InitializeEquipment(armorlevel * 10,dmgTypeResistanceArmor, dmgresistarmor * 10, dmgTypeWeaknessArmor, dmgweaknessarmor * 10, 
            armorSprites[Random.Range(0, armorSprites.Count())], ItemType.Armor, armorName, true, armorDescription, Mathf.Round(monetaryvaluearmor));

    }

    /// <summary>
    /// Generates a shield.
    /// </summary>
    /// <param name="quality">The quality. Accepts the following strings: Epic, Rare, Uncommon, Common.</param>
    private void GenerateShield(string quality)
    {
        GenerateShieldBaseStats();
        float maxshields = 0;
        float shieldrechargerate = 0;
        float shieldrechargedelay = 0;
        float monetaryvalueshield = 0;
        float dmgresistshield = 0;
        float dmgweaknessshield = 0;

        switch (quality)
        {
            case "Epic":
                maxshields += maxShields * epicStatModifier;
                GenerateRandomModifiers();
                shieldrechargerate += shieldRechargeRate * epicStatModifier;
                GenerateRandomModifiers();
                shieldrechargedelay += shieldRechargeDelay * (2 - epicStatModifier);
                GenerateRandomModifiers();
                monetaryvalueshield += baseMonetaryValueShield * epicStatModifier;
                GenerateRandomModifiers();
                dmgweaknessshield += dmgTypeWeaknesseNumShield * epicStatModifier;
                GenerateRandomModifiers();
                dmgresistshield += dmgTypeResistanceNumShield + epicStatModifier;
                shieldName = namePrefixEpic[Random.Range(0, namePrefixEpic.Count())] + " " + shieldType;
                shield.itemQuality = "Epic";
                break;
            case "Rare":
                maxshields += maxShields * rareStatModifier;
                GenerateRandomModifiers();
                shieldrechargerate += shieldRechargeRate * rareStatModifier;
                GenerateRandomModifiers();
                shieldrechargedelay += shieldRechargeDelay * (2 - rareStatModifier);
                GenerateRandomModifiers();
                monetaryvalueshield += baseMonetaryValueShield * rareStatModifier;
                GenerateRandomModifiers();
                dmgweaknessshield += dmgTypeWeaknesseNumShield * rareStatModifier;
                GenerateRandomModifiers();
                dmgresistshield += dmgTypeResistanceNumShield + rareStatModifier;
                shieldName = namePrefixRare[Random.Range(0, namePrefixRare.Count())] + " " + shieldType;
                shield.itemQuality = "Rare";
                break;
            case "Uncommon":
                maxshields += maxShields * uncommonStatModifier;
                GenerateRandomModifiers();
                shieldrechargerate += shieldRechargeRate * uncommonStatModifier;
                GenerateRandomModifiers();
                shieldrechargedelay += shieldRechargeDelay * (2 - uncommonStatModifier);
                GenerateRandomModifiers();
                monetaryvalueshield += baseMonetaryValueShield * uncommonStatModifier;
                GenerateRandomModifiers();
                dmgweaknessshield += dmgTypeWeaknesseNumShield * uncommonStatModifier;
                GenerateRandomModifiers();
                dmgresistshield += dmgTypeResistanceNumShield + uncommonStatModifier;
                shieldName = namePrefixUncommon[Random.Range(0, namePrefixUncommon.Count())] + " " + shieldType;
                shield.itemQuality = "Uncommon";
                break;
            case "Common":
                maxshields += maxShields * commonStatModifier;
                GenerateRandomModifiers();
                shieldrechargerate += shieldRechargeRate * commonStatModifier;
                GenerateRandomModifiers();
                shieldrechargedelay += shieldRechargeDelay * (2 - commonStatModifier);
                GenerateRandomModifiers();
                monetaryvalueshield += baseMonetaryValueShield * commonStatModifier;
                GenerateRandomModifiers();
                dmgweaknessshield += dmgTypeWeaknesseNumShield * commonStatModifier;
                GenerateRandomModifiers();
                dmgresistshield += dmgTypeResistanceNumShield + commonStatModifier;
                shieldName = namePrefixCommon[Random.Range(0, namePrefixCommon.Count())] + " " + shieldType;
                shield.itemQuality = "Common";
                break;
        }

        shield.InitializeEquipment(Mathf.Round(maxshields), Mathf.Round(shieldrechargerate), shieldrechargedelay, dmgTypeResistanceShield, Mathf.Round(dmgresistshield), dmgTypeWeaknessShield, 
            Mathf.Round(dmgweaknessshield), shieldSprites[Random.Range(0, shieldSprites.Count())], ItemType.Shield, shieldName, true, shieldDescription, Mathf.Round(monetaryvalueshield));

    }


    /// <summary>
    /// Generates the shield base stats using user defined parameters.
    /// </summary>
    private void GenerateShieldBaseStats()
    {

        if (generateTierTwo)
        {
            int chooseTierToCreate = Random.Range(0, 1);

            if (chooseTierToCreate == 0)
            {
                shieldType = shieldTypesTierOne[Random.Range(0, shieldTypesTierOne.Count())];
                maxShields = (int)Random.Range(maxShieldMinTierOne, maxShieldMaxTierOne);
                shieldRechargeDelay = Random.Range(shieldRechargeDelayMinTierOne, shieldRechargeDelayMaxTierOne);
                shieldRechargeRate = Random.Range(shieldRechargeMinTierOne, shieldRechargeMaxTierOne);
                baseMonetaryValueShield = Random.Range(baseMonetaryValueShieldMinTierOne, baseMonetaryValueShieldMaxTierOne);

            }
            else
            {
                shieldType = shieldTypesTierTwo[Random.Range(0, shieldTypesTierTwo.Count())];
                maxShields = (int)Random.Range(maxShieldMinTierTwo, maxShieldMaxTierTwo);
                shieldRechargeDelay = Random.Range(shieldRechargeMinDelayTierTwo, shieldRechargeMaxDelayTierTwo);
                shieldRechargeRate = Random.Range(shieldRechargeMinTierTwo, shieldRechargeMaxTierTwo);
                baseMonetaryValueShield = Random.Range(baseMonetaryValueShieldMinTierTwo, baseMonetaryValueShieldMaxTierTwo);
            }
        }

        else
        {
            shieldType = shieldTypesTierOne[Random.Range(0, shieldTypesTierOne.Count())];
            maxShields = (int)Random.Range(maxShieldMinTierOne, maxShieldMaxTierOne);
            shieldRechargeDelay = Random.Range(shieldRechargeDelayMinTierOne, shieldRechargeDelayMaxTierOne);
            shieldRechargeRate = Random.Range(shieldRechargeMinTierOne, shieldRechargeMaxTierOne);
            baseMonetaryValueShield = Random.Range(baseMonetaryValueShieldMinTierOne, baseMonetaryValueShieldMaxTierOne);
        }

        if (shieldType.Contains("Absorptive Shield Generator"))
        {
            dmgTypeResistanceShield = Shield.DamageType.Heat;
            dmgTypeWeaknessShield = Shield.DamageType.Radiation;
            dmgTypeWeaknesseNumShield = Random.Range(dmgTypeWeaknessTierOneMin, dmgTypeWeaknessTierOneMax);
            dmgTypeResistanceNumShield = Random.Range(dmgTypeResistanceTierOneMin, dmgTypeResistanceTierOneMax);             
            shieldDescription = "Absorptive shields store energy collected from enemy      fire in large capicitor banks which require time to      discharge once at capactity.";
        }
        if (shieldType.Contains("Advanced Absorptive Shield Generator"))
        {
            dmgTypeResistanceShield = Shield.DamageType.Heat;
            dmgTypeWeaknessShield = Shield.DamageType.Radiation;
            dmgTypeWeaknesseNumShield = Random.Range(dmgTypeWeaknessTierTwoMin, dmgTypeWeaknessTierTwoMax);
            dmgTypeResistanceNumShield = Random.Range(dmgTypeResistanceTierTwoMin, dmgTypeResistanceTierTwoMax);
            shieldDescription = "Improved capacitors allow for additional energy collection and quicker disipation over these shields standard counterpart.";
        }
        if (shieldType.Contains("Multi-Phasic Adaptive Shield Generator"))
        {
            dmgTypeResistanceShield = Shield.DamageType.Radiation;
            dmgTypeWeaknessShield = Shield.DamageType.Heat;
            dmgTypeWeaknesseNumShield = Random.Range(dmgTypeWeaknessTierTwoMin, dmgTypeWeaknessTierTwoMax);
            dmgTypeResistanceNumShield = Random.Range(dmgTypeResistanceTierTwoMin, dmgTypeResistanceTierTwoMax);
            shieldDescription = "These improved Adaptive shields are capable of projecting multiple layers of shielding at different frequencies increasing their efficiency.";
        }
        if (shieldType.Contains("Adaptive Shield Generator"))
        {
            dmgTypeResistanceShield = Shield.DamageType.Radiation;
            dmgTypeWeaknessShield = Shield.DamageType.Heat;
            dmgTypeWeaknesseNumShield = Random.Range(dmgTypeWeaknessTierOneMin, dmgTypeWeaknessTierOneMax);
            dmgTypeResistanceNumShield = Random.Range(dmgTypeResistanceTierOneMin, dmgTypeResistanceTierOneMax);
            shieldDescription = "Adaptive shields quicky rotate their frequencies      protecting the ship from high energy radiation.";
        }
        if (shieldType.Contains("Graviton Field Generator"))
        {
            dmgTypeResistanceShield = Shield.DamageType.Heat;
            dmgTypeWeaknessShield = Shield.DamageType.EM;
            dmgTypeWeaknesseNumShield = Random.Range(dmgTypeWeaknessTierOneMin, dmgTypeWeaknessTierOneMax);
            dmgTypeResistanceNumShield = Random.Range(dmgTypeResistanceTierOneMin, dmgTypeResistanceTierOneMax);
            shieldDescription = "Generates gravimetric distortions capable of dissapa-      ting the excess heat generated by incoming weapons      fire.";
        }
        if (shieldType.Contains("Multi-Phasic Adaptive Shield Generator"))
        {
            dmgTypeResistanceShield = Shield.DamageType.Heat;
            dmgTypeWeaknessShield = Shield.DamageType.EM;
            dmgTypeWeaknesseNumShield = Random.Range(dmgTypeWeaknessTierTwoMin, dmgTypeWeaknessTierTwoMax);
            dmgTypeResistanceNumShield = Random.Range(dmgTypeResistanceTierTwoMin, dmgTypeResistanceTierTwoMax);
            shieldDescription = "Utilizing upgraded Graviton emmiters these shields can dissapate far more intense heat for longer periods of time";
        }
        if (shieldType.Contains("Tri-Phasial Shield Generator"))
        {
            dmgTypeResistanceShield = Shield.DamageType.EM;
            dmgTypeWeaknessShield = Shield.DamageType.Heat;
            dmgTypeWeaknesseNumShield = Random.Range(dmgTypeWeaknessTierTwoMin, dmgTypeWeaknessTierTwoMax);
            dmgTypeResistanceNumShield = Random.Range(dmgTypeResistanceTierTwoMin, dmgTypeResistanceTierTwoMax);
            shieldDescription = "These shields have been expanded beyond their original purpose of cosmic radiation defense to include defense against deadly, military grade radiation weaponry";
        }
        if (shieldType.Contains("Bi-Phasial Shield Generator"))
        {
            dmgTypeResistanceShield = Shield.DamageType.EM;
            dmgTypeWeaknessShield = Shield.DamageType.Heat;
            dmgTypeWeaknesseNumShield = Random.Range(dmgTypeWeaknessTierOneMin, dmgTypeWeaknessTierOneMax);
            dmgTypeResistanceNumShield = Random.Range(dmgTypeResistanceTierOneMin, dmgTypeResistanceTierOneMax);
            shieldDescription = "These shield systems were specially engineered and       tuned to mitigate dangerous radiation types during        early forays into deep space";
        }

    }

    /// <summary>
    /// Generates the random modifiers.
    /// </summary>
    private void GenerateRandomModifiers()
    {


        commonStatModifier = Random.Range(((commonModifierMinPercent / 100) + 1 ), ((commonModifierMaxPercent / 100) + 1));
        uncommonStatModifier = Random.Range(((uncommonModifierMinPercent / 100) + 1), ((uncommonModifierMaxPercent / 100) + 1));
        rareStatModifier = Random.Range(((rareModifierMinPercent / 100) + 1), ((rareModifierMaxPercent / 100) + 1));
        epicStatModifier = Random.Range(((epicModifierMinPercent / 100) + 1), ((epicModifierMaxPercent / 100) + 1));
    }

    /// <summary>
    /// Adds the random item to inventory.
    /// </summary>
    public void AddRandomItemToInventory() 
    {
        _POC.AddItemToInventory(RandomlyGenerateEquipment());
    }

    /// <summary>
    /// Adds the random item of type to inventory.
    /// </summary>
    /// <param name="moduleType">Type of equipment. Accepts ItemType enum.</param>
    public void AddRandomItemOfTypeToInventory(ItemType moduleType)
    {
        _POC.AddItemToInventory(RandomlyGenerateEquipment(moduleType));
    }

    /// <summary>
    /// Adds the random item of type to inventory.
    /// </summary>
    /// <param name="moduleType">Type of the module. Accepts the following strings: Armor, Engine, Shield, Weapon, Weapon1.</param>
    public void AddRandomItemOfTypeToInventory(string moduleType)
    {
        switch (moduleType)
        {
            case "Armor":
                _POC.AddItemToInventory(RandomlyGenerateEquipment(ItemType.Armor));
                break;
            case "Engine":
                _POC.AddItemToInventory(RandomlyGenerateEquipment(ItemType.Engine));
                break;
            case "Shield":
                _POC.AddItemToInventory(RandomlyGenerateEquipment(ItemType.Shield));
                break;
            case "Weapon":
                _POC.AddItemToInventory(RandomlyGenerateEquipment(ItemType.Weapon));
                break;
            case "Reactor":
                _POC.AddItemToInventory(RandomlyGenerateEquipment(ItemType.Reactor));
                break;
        }
        _POC.AddItemToInventory(RandomlyGenerateEquipment(moduleType));
    }

    /// <summary>
    /// Adds the random item of specified rarity to inventory.
    /// </summary>
    /// <param name="specifiedRarity">The specified rarity. Accepts the following strings: Epic, Rare, Uncommon, Common. </param>
    public void AddRandomItemOfRarityToInventory(string specifiedRarity)
    {
        _POC.AddItemToInventory(RandomlyGenerateEquipment(specifiedRarity));
    }

    /// <summary>
    /// Adds the random item of specified type and specified rarity to inventory.
    /// </summary>
    /// <param name="moduleType">Type of equipment. Accepts ItemType enum.</param>
    /// <param name="specifiedRarity">The specified rarity. Accepts the following strings: Epic, Rare, Uncommon, Common.</param>
    public void AddRandomItemOfTypeAndRarityToInventory(ItemType moduleType, string specifiedRarity) 
    {
        _POC.AddItemToInventory(RandomlyGenerateEquipment(moduleType, specifiedRarity));
    }

    /// <summary>
    /// Randomly generates a piece of equipment of a random type of a random rarity.
    /// </summary>
    /// <returns> Item </returns>
    public Item RandomlyGenerateEquipment()
    {
        float randomNumberQuality = Random.Range(.5f, 101);
        int randomNumberEquipmentSlot = Random.Range(1, 6);

        if (_POC.GetPlayerLevel() >= 20)
        {
            generateTierTwo = true;
        }

        GenerateRandomModifiers();

        if (randomNumberQuality >= .5f && randomNumberQuality <= 2) //Epic
        {
            switch (randomNumberEquipmentSlot)
            {
                case 1: //Armor
                    GenerateArmor("Epic");
                    return armor;
                case 2: //Engine
                    GenerateEngine("Epic");
                    return engine;
                case 3: //Shield
                    GenerateShield("Epic");
                    return shield;
                case 4: //Weapon
                    GenerateWeapon("Epic");
                    return weapon;
                case 5://Reactor
                    GenerateReactor("Epic");
                    return reactor;
                    //RepairBot  case 6: 
                    //RepairBot    break;
            }
        }

        if (randomNumberQuality > 2 && randomNumberQuality <= 8) //Rare
        {

            switch (randomNumberEquipmentSlot)
            {
                case 1:
                    GenerateArmor("Rare");
                    return armor;

                case 2:
                    GenerateEngine("Rare");
                    return engine;
                case 3:
                    GenerateShield("Rare");
                    return shield;
                case 4:
                    GenerateWeapon("Rare");
                    return weapon;
                case 5:
                    GenerateReactor("Rare");
                    return reactor;
                    //RepairBot  case 6:
                    //RepairBot   break;
            }
        }
        if (randomNumberQuality > 8 && randomNumberQuality <= 28) //Uncommon
        {

            switch (randomNumberEquipmentSlot)
            {
                case 1:
                    GenerateArmor("Uncommon");
                    return armor;
                case 2:
                    GenerateEngine("Uncommon");
                    return engine;
                case 3:
                    GenerateShield("Uncommon");
                    return shield;
                case 4:
                    GenerateWeapon("Uncommon");
                    return weapon;
                case 5:
                    GenerateReactor("Uncommon");
                    return reactor;
                    //RepairBot case 6:
                    //RepairBot    break;
            }
        }
        if (randomNumberQuality > 28) //Common
        {

            switch (randomNumberEquipmentSlot)
            {
                case 1:
                    GenerateArmor("Common");
                    return armor;
                case 2:
                    GenerateEngine("Common");
                    return engine;
                case 3:
                    GenerateShield("Common");
                    return shield;
                case 4:
                    GenerateWeapon("Common");
                    return weapon;
                case 5:
                    GenerateReactor("Common");
                    return reactor;
                    //RepairBot case 6:
                    //RepairBot   break;
            }
        }
        return null;
    }

    /// <summary>
    /// Randomly generate equipment of specified rarity.
    /// </summary>
    /// <param name="rarity">The rarity. Accepts the following strings: Epic, Rare, Uncommon, Common.</param>
    /// <returns> Item</returns>
    public Item RandomlyGenerateEquipment(string rarity) 
    {
        float randomNumberQuality = 0;
        int randomNumberEquipmentSlot = 0;
        if (_POC.GetPlayerLevel() >= 20)
        {
            generateTierTwo = true;
        }

        GenerateRandomModifiers();
        switch (rarity)
        {
            case "Epic":
                randomNumberQuality = 1;
                break;
            case "Rare":
                randomNumberQuality = 2;
                break;
            case "Uncommon":
                randomNumberQuality = 3;
                break;
            case "Common":
                randomNumberQuality = 4;
                break;
        }

        if (randomNumberEquipmentSlot == 1) //Epic
        {
            switch (randomNumberEquipmentSlot)
            {
                case 1: //Armor
                    GenerateArmor("Epic");
                    return armor;
                case 2: //Engine
                    GenerateEngine("Epic");
                    return engine;
                case 3: //Shield
                    GenerateShield("Epic");
                    return shield;
                case 4: //Weapon
                    GenerateWeapon("Epic");
                    return weapon;
                case 5://Reactor
                    GenerateReactor("Epic");
                    return reactor;
                    //RepairBot  case 6: 
                    //RepairBot    break;
            }
        }

        if (randomNumberEquipmentSlot == 2) //Rare
        {

            switch (randomNumberEquipmentSlot)
            {
                case 1:
                    GenerateArmor("Rare");
                    return armor;

                case 2:
                    GenerateEngine("Rare");
                    return engine;
                case 3:
                    GenerateShield("Rare");
                    return shield;
                case 4:
                    GenerateWeapon("Rare");
                    return weapon;
                case 5:
                    GenerateReactor("Rare");
                    return reactor;
                    //RepairBot  case 6:
                    //RepairBot   break;
            }
        }
        if (randomNumberEquipmentSlot == 3) //Uncommon
        {

            switch (randomNumberEquipmentSlot)
            {
                case 1:
                    GenerateArmor("Uncommon");
                    return armor;
                case 2:
                    GenerateEngine("Uncommon");
                    return engine;
                case 3:
                    GenerateShield("Uncommon");
                    return shield;
                case 4:
                    GenerateWeapon("Uncommon");
                    return weapon;
                case 5:
                    GenerateReactor("Uncommon");
                    return reactor;
                    //RepairBot case 6:
                    //RepairBot    break;
            }
        }
        if (randomNumberEquipmentSlot == 4) //Common
        {

            switch (randomNumberEquipmentSlot)
            {
                case 1:
                    GenerateArmor("Common");
                    return armor;
                case 2:
                    GenerateEngine("Common");
                    return engine;
                case 3:
                    GenerateShield("Common");
                    return shield;
                case 4:
                    GenerateWeapon("Common");
                    return weapon;
                case 5:
                    GenerateReactor("Common");
                    return reactor;
                    //RepairBot case 6:
                    //RepairBot   break;
            }
        }
        return null;
    }

    /// <summary>
    /// Randomly generate equipment of specified type.
    /// </summary>
    /// <param name="moduleType">Type of equipment. Accepts ItemType enum</param>
    /// <returns> Item </returns>
    public Item RandomlyGenerateEquipment(ItemType moduleType) 
    {
        float randomNumberQuality = Random.Range(.5f, 101);
        int randomNumberEquipmentSlot = 0;
        if (_POC.GetPlayerLevel() >= 20)
        {
            generateTierTwo = true;
        }

        GenerateRandomModifiers();
        switch (moduleType)
        {
            case ItemType.Armor:
                randomNumberEquipmentSlot = 1;
                break;
            case ItemType.Engine:
                randomNumberEquipmentSlot = 2;
                break;
            case ItemType.Shield:
                randomNumberEquipmentSlot = 3;
                break;
            case ItemType.Weapon:
                randomNumberEquipmentSlot = 4;
                break;
            case ItemType.Reactor:
                randomNumberEquipmentSlot = 5;
                break;
            default:
                break;
        }

        if (randomNumberQuality >= .5f && randomNumberQuality <= 2) //Epic
        {
            switch (randomNumberEquipmentSlot)
            {
                case 1: //Armor
                    GenerateArmor("Epic");
                    return armor;
                case 2: //Engine
                    GenerateEngine("Epic");
                    return engine;
                case 3: //Shield
                    GenerateShield("Epic");
                    return shield;
                case 4: //Weapon
                    GenerateWeapon("Epic");
                    return weapon;
                case 5://Reactor
                    GenerateReactor("Epic");
                    return reactor;
                    //RepairBot  case 6: 
                    //RepairBot    break;
            }
        }

        if (randomNumberQuality > 2 && randomNumberQuality <= 8) //Rare
        {

            switch (randomNumberEquipmentSlot)
            {
                case 1:
                    GenerateArmor("Rare");
                    return armor;

                case 2:
                    GenerateEngine("Rare");
                    return engine;
                case 3:
                    GenerateShield("Rare");
                    return shield;
                case 4:
                    GenerateWeapon("Rare");
                    return weapon;
                case 5:
                    GenerateReactor("Rare");
                    return reactor;
                    //RepairBot  case 6:
                    //RepairBot   break;
            }
        }
        if (randomNumberQuality > 8 && randomNumberQuality <= 28) //Uncommon
        {

            switch (randomNumberEquipmentSlot)
            {
                case 1:
                    GenerateArmor("Uncommon");
                    return armor;
                case 2:
                    GenerateEngine("Uncommon");
                    return engine;
                case 3:
                    GenerateShield("Uncommon");
                    return shield;
                case 4:
                    GenerateWeapon("Uncommon");
                    return weapon;
                case 5:
                    GenerateReactor("Uncommon");
                    return reactor;
                    //RepairBot case 6:
                    //RepairBot    break;
            }
        }
        if (randomNumberQuality > 28) //Common
        {

            switch (randomNumberEquipmentSlot)
            {
                case 1:
                    GenerateArmor("Common");
                    return armor;
                case 2:
                    GenerateEngine("Common");
                    return engine;
                case 3:
                    GenerateShield("Common");
                    return shield;
                case 4:
                    GenerateWeapon("Common");
                    return weapon;
                case 5:
                    GenerateReactor("Common");
                    return reactor;
                    //RepairBot case 6:
                    //RepairBot   break;
            }
        }
        return null;
    }

    /// <summary>
    /// Randomly generates equipment of specified type and rarity.
    /// </summary>
    /// <param name="moduleType">Type of equipment. Accepts ItemType enum.</param>
    /// <param name="rarity">The rarity. Accepts the following strings: Epic, Rare, Uncommon, common. </param>
    /// <returns></returns>
    public Item RandomlyGenerateEquipment(ItemType moduleType, string rarity) 
    {
        float randomNumberQuality = 0;
        int randomNumberEquipmentSlot = 0;
        if (_POC.GetPlayerLevel() >= 20)
        {
            generateTierTwo = true;
        }

        GenerateRandomModifiers();
        switch (rarity)
        {
            case "Epic":
                randomNumberQuality = 1;
                break;
            case "Rare":
                randomNumberQuality = 2;
                break;
            case "Uncommon":
                randomNumberQuality = 3;
                break;
            case "Common":
                randomNumberQuality = 4;
                break;
        }
        GenerateRandomModifiers();
        switch (moduleType.ToString())
        {
            case "Armor":
                randomNumberEquipmentSlot = 1;
                break;
            case "Engine":
                randomNumberEquipmentSlot = 2;
                break;
            case "Shield":
                randomNumberEquipmentSlot = 3;
                break;
            case "Weapon":
                randomNumberEquipmentSlot = 4;
                break;
            case "Reactor":
                randomNumberEquipmentSlot = 5;
                break;
            default:
                break;
        }

        if (randomNumberEquipmentSlot == 1) //Epic
        {
            switch (randomNumberEquipmentSlot)
            {
                case 1: //Armor
                    GenerateArmor("Epic");
                    return armor;
                case 2: //Engine
                    GenerateEngine("Epic");
                    return engine;
                case 3: //Shield
                    GenerateShield("Epic");
                    return shield;
                case 4: //Weapon
                    GenerateWeapon("Epic");
                    return weapon;
                case 5://Reactor
                    GenerateReactor("Epic");
                    return reactor;
                    //RepairBot  case 6: 
                    //RepairBot    break;
            }
        }

        if (randomNumberEquipmentSlot == 2) //Rare
        {

            switch (randomNumberEquipmentSlot)
            {
                case 1:
                    GenerateArmor("Rare");
                    return armor;

                case 2:
                    GenerateEngine("Rare");
                    return engine;
                case 3:
                    GenerateShield("Rare");
                    return shield;
                case 4:
                    GenerateWeapon("Rare");
                    return weapon;
                case 5:
                    GenerateReactor("Rare");
                    return reactor;
                    //RepairBot  case 6:
                    //RepairBot   break;
            }
        }
        if (randomNumberEquipmentSlot == 3) //Uncommon
        {

            switch (randomNumberEquipmentSlot)
            {
                case 1:
                    GenerateArmor("Uncommon");
                    return armor;
                case 2:
                    GenerateEngine("Uncommon");
                    return engine;
                case 3:
                    GenerateShield("Uncommon");
                    return shield;
                case 4:
                    GenerateWeapon("Uncommon");
                    return weapon;
                case 5:
                    GenerateReactor("Uncommon");
                    return reactor;
                    //RepairBot case 6:
                    //RepairBot    break;
            }
        }
        if (randomNumberEquipmentSlot == 4) //Common
        {

            switch (randomNumberEquipmentSlot)
            {
                case 1:
                    GenerateArmor("Common");
                    return armor;
                case 2:
                    GenerateEngine("Common");
                    return engine;
                case 3:
                    GenerateShield("Common");
                    return shield;
                case 4:
                    GenerateWeapon("Common");
                    return weapon;
                case 5:
                    GenerateReactor("Common");
                    return reactor;
                    //RepairBot case 6:
                    //RepairBot   break;
            }
        }
        return null;
    }

}

