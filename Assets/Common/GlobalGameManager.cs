using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class GlobalGameManager : MonoBehaviour {


    private static GlobalGameManager instance;
    public string currentScene; //current scene
    public Vector3 locationInScene; //current location within current scene
    public Vector3 playerStartingLocationFirstScene;
    public string playerName; //player name
    public float credits; //available credits
    public float playerLevel; //current player level
    public PlayerObject playerObject;
    public float experiencePoints; //current experience points
    public float totalExperiencePointsEarned;
    public float availableSkillPoints; //available SP
    public float totalSkillPointsEarned;
    public float starterWeaponMinDmg;
    public float starterWeaponMaxDmg = 0;
    public float starterWeaponRefireRate;
    public float starterWeaponEnergyCost;
    public float starterWeaponProjectileVelocity;
    public float starterShieldMaxCapacity;
    public float starterShieldRechargeRate;
    public float starterRechargeDelay;
    public float starterShieldDmgTypeResistRate;
    public float starterShieldDmgTypeWeaknessRate;
    public float starterArmorLevel;
    public float starterArmorDmgTypeResistRate;
    public float starterArmorDmgTypeWeaknessRate;
    public float starterEngineSpeed;
    public float starterEngineTurnSpeed;
    public float starterEngineBoostSpeed;
    public float starterEngineBoostCost;
    public float starterEngineBoostCooldown;
    public float starterReactorMaxEnergy;
    public float starterReactorRechargeRate;
    public Projectile starterWeaponProjectile;
    public Sprite starterReactorIcon;
    public Sprite starterArmorIcon;
    public Sprite starterShieldIcon;
    public Sprite starterWeaponIcon;
    public Sprite starterEngineIcon;
    public GameObject persistentObjectToAdd;
    public List<GameObject> persistentObjects;
    public GameObject playerInvWindow;
    public GameObject playerEqWindow;
    public GameObject menuBar;
    public GameObject vitalsBar;
    public GameObject cameraZoom;
    public Hull playerShip;
    public List<Hull> hullListTierOne; //Contains preassambled tier one hull/ship objects populated at run time and pulled from this list during play;
    public Hull hullToAddToTierOne;
    public List<Hull> hullListTierTwo; //Contains preassambled tier two hull/ship objects populated at run time and pulled from this list during play;
    public Hull hullToAddToTierTwo;
    public List<PlayerSkill> playerSkills;
    public Dictionary<string, Item> starterEquipment;
    public Sprite playerAvater;
    public GameObject messageToPlayerWindow;
    private GameSettingsController gms;



    public void AddPersistentObjectToList()
    {
        if (persistentObjects != null)
        {
            persistentObjects.Add(persistentObjectToAdd);
            persistentObjectToAdd = null;
        }
        else
        {
            persistentObjects = new List<GameObject>();
            persistentObjects.Add(persistentObjectToAdd);
            persistentObjectToAdd = null;
        }
    }

    public void ClearPersistentObjectList()
    {
        persistentObjects.Clear();
    }

    public void AddHullToTierOneList()
    {
        if (hullListTierOne != null)
        {
            hullListTierOne.Add(hullToAddToTierOne);
            hullToAddToTierOne = null;
        }
        else
        {
            hullListTierOne = new List<Hull>();
            hullListTierOne.Add(hullToAddToTierOne);
            hullToAddToTierOne = null;
        }
    }

    public void ClearHullToTierOneList()
    {
        hullListTierOne.Clear();
    }

    public void AddHullToTierTwoList()
    {
        if (persistentObjects != null)
        {
            hullListTierTwo.Add(hullToAddToTierTwo);
            hullToAddToTierTwo = null;
        }
        else
        {
            hullListTierTwo = new List<Hull>();
            hullListTierTwo.Add(hullToAddToTierTwo);
            hullToAddToTierTwo = null;
        }
    }

    public void ClearHullToTierTwoList()
    {
        hullListTierTwo.Clear();
    }

   
    public void StartNewGameTesting()
    {
        playerShip = hullListTierOne.Find(x => x.hullModel == "Boar");
        playerShip.shipPersonalName = "Testing Ship";
        playerObject.EquipHull(playerShip);
        //playerObject.GetPlayerSkillsFromGameManager();
        vitalsBar.SetActive(true);
        menuBar.SetActive(true);
        cameraZoom.SetActive(true);
        playerObject.MovePlayerToLocation(playerStartingLocationFirstScene);
    }

    public Vector3 locationToMovePlayerTo;
    public void MovePlayerObjectToLocation()
    {
        playerObject.MovePlayerToLocation(locationToMovePlayerTo);
    }

    public static GlobalGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GlobalGameManager").AddComponent<GlobalGameManager>();
            }

            return instance;
        }
    }

    public Hull GetHullOfType(string hulltype)
    {

        foreach (Hull hull in hullListTierTwo)
        {
            if (hull.hullModel == hulltype)
            {
                return hull;
            }

        }

        foreach (Hull hull in hullListTierOne)
        {
            if (hull.hullModel == hulltype)
            {
                return hull;
            }

        }
        return null;
    }
    public Hull GetRandomHull(bool tierTwo)
    {
        int shipToReturn;
        if (tierTwo)
        {
            shipToReturn = UnityEngine.Random.Range(0, hullListTierTwo.Count);
            return hullListTierTwo[shipToReturn];
        }
        shipToReturn = UnityEngine.Random.Range(0, hullListTierOne.Count);
        return hullListTierOne[shipToReturn];
    }
    public void PopulateHullList()
    {
        #region Hull(Boar - T1 - Fighter)
        Hull boar = ScriptableObject.CreateInstance<Hull>();
        boar.InitializeHull(ShipType.Frigate, "Boar", false, 230000, 6, 10, 2, 0, 1, Resources.Load("FighterT1Boar") as GameObject, Resources.Load("BoarIcon") as Sprite, false);
        boar.EquipWeapon0((Weapon)starterEquipment["starterWeapon"]);
        boar.EquipShield((Shield)starterEquipment["starterShield"]);
        boar.EquipArmor((Armor)starterEquipment["starterArmor"]);
        boar.EquipEngine((Engine)starterEquipment["starterEngines"]);
        boar.EquipReactor((Reactor)starterEquipment["starterReactor"]);
        hullListTierOne.Add(boar);
        #endregion
        #region Hull(Mule - T1 - Freighter)
        Hull mule = ScriptableObject.CreateInstance<Hull>();
        mule.InitializeHull(ShipType.Freighter, "Mule", false, 230000, 16, 6, 1, 1, 0, Resources.Load("FreighterT1Mule") as GameObject, Resources.Load("MuleIcon") as Sprite, false);
        mule.EquipWeapon0((Weapon)starterEquipment["starterWeapon"]);
        mule.EquipShield((Shield)starterEquipment["starterShield"]);
        mule.EquipArmor((Armor)starterEquipment["starterArmor"]);
        mule.EquipEngine((Engine)starterEquipment["starterEngines"]);
        mule.EquipReactor((Reactor)starterEquipment["starterReactor"]);
        hullListTierOne.Add(mule);
        #endregion
    }

    public void PopulateStarterEquipment()
    {
        starterEquipment = new Dictionary<string, Item>();

        Weapon starterWeapon = ScriptableObject.CreateInstance<Weapon>();
        starterWeapon.InitializeEquipment(starterWeaponMinDmg, starterWeaponMaxDmg, Weapon.DamageType.Heat, starterWeaponRefireRate, starterWeaponEnergyCost, starterWeaponProjectileVelocity, starterWeaponProjectile, starterWeaponIcon,
            ItemType.Weapon, "Run-Down Laser Cannon", true, "This laser cannon has seen better days but it's better than nothing. You should look into upgrading sooner rather than later.", 500);
        starterWeapon.itemQuality = "Common";
        starterEquipment.Add("starterWeapon", starterWeapon);
        Shield starterShield = ScriptableObject.CreateInstance<Shield>();
        starterShield.InitializeEquipment(starterShieldMaxCapacity, starterShieldRechargeRate, starterRechargeDelay, Shield.DamageType.Heat, starterShieldDmgTypeResistRate, Shield.DamageType.EM, starterShieldDmgTypeWeaknessRate, starterShieldIcon,
            ItemType.Shield, "Barely Functional Shield Generator", true, "Most of the emitters may have been burned out from over use, but it still projects a barrier. Just don't expect it to hold up to much.", 1500);
        starterShield.itemQuality = "Common";
        starterEquipment.Add("starterShield", starterShield);
        Armor starterArmor = ScriptableObject.CreateInstance<Armor>();
        starterArmor.InitializeEquipment(starterArmorLevel, Armor.DamageType.Kinetic, .95f, Armor.DamageType.Radiation, .99f, starterArmorIcon,
            ItemType.Armor, "Tattered Armor Plating", true, "Beneficial by virtue of putting something between the damage and your hull, just don't expect much protection", 250);
        starterArmor.itemQuality = "Common";
        starterEquipment.Add("starterArmor", starterArmor);
        Engine starterEngines = ScriptableObject.CreateInstance<Engine>();
        starterEngines.InitializeEquipment(starterEngineSpeed, starterEngineTurnSpeed, 1, starterEngineBoostSpeed, starterEngineBoostCost, starterEngineBoostCooldown, starterEngineIcon,
            ItemType.Engine, "Salvaged Ion Thrusters", true, "These engines have clearly had a long service life and while they may not be the quickest thrusters on the market they'll get you where you need to go.", 650);
        starterEngines.itemQuality = "Common";
        starterEquipment.Add("starterEngines", starterEngines);
        Reactor starterReactor = ScriptableObject.CreateInstance<Reactor>();
        starterReactor.InitializeEquipment(starterReactorMaxEnergy, starterReactorRechargeRate, starterReactorIcon,
            ItemType.Reactor, "Over-Worked Fission Reactor", true, "This outdated reactor is probably the last of it's kind, it's low power output, and fuel inefficiencies make it an artifact of a by-gone era", 475);
        starterReactor.itemQuality = "Common";
        starterEquipment.Add("starterReactor", starterReactor);
    }
    public void SetPlayerSkills(List<PlayerSkill> pskills)
    {
        playerSkills = pskills;
    }
    public void SetPlayerAvatar(Sprite pavatar)
    {
        playerAvater = pavatar;
    }

    private void Awake()
    {
        gms = FindObjectOfType<GameSettingsController>();
        hullListTierOne = new List<Hull>();
        hullListTierTwo = new List<Hull>();
        //PopulateStartSettings();
        PopulateStarterEquipment();
        PopulateHullList();
        persistentObjects.ForEach(x => DontDestroyOnLoad(x));
    }


    public void SetScene(string scene)
    {
        currentScene = scene;
    }
    public string GetScene()
    {
        return currentScene;
    }
    public void SetLocationInScene(Vector3 location)
    {
        locationInScene = location;
    }
    public Vector3 GetLoctionInScene()
    {
        return locationInScene;
    }
    public void SetName(string pName)
    {
        playerName = pName;
    }
    public string GetName()
    {
        return playerName;
    }
    public float GetCredits()
    {
        return credits;
    }
    public void SetCredits(float totalCredits)
    {
        credits = totalCredits;
    }
    public void AddCredits(float creditsToAdd)
    {
        credits += creditsToAdd;
    }
    public float GetExperience()
    {
        return experiencePoints;
    }
    public void AddExperiencePoints(float xpAdd)
    {
        experiencePoints += xpAdd;
    }
    public void SetAvailableSkillPoints(int asp)
    {
        availableSkillPoints = asp;
    }
}
