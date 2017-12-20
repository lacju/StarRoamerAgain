using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DarkTonic.CoreGameKit;
using Rewired;
using System;

public class PlayerObject : MonoBehaviour
{


    //Player Data
    private Vector3 playerShipVelocity;
    private Vector3 playerLocation;
    public void MovePlayerToLocation(Vector3 pl)
    {
        playerLocation = pl;
        gameObject.transform.position = playerLocation;
    }
    public string playerName; //Player Name
    public void SetPlayerName(string name)
    {
        playerName = name;
    }
    public string GetPlayerName()
    {
        return playerName;
    }
    void SetPlayerShipVelocity()
    {
        playerShipVelocity = rb.velocity;
    }
    public Vector3 GetPlayerShipVelocity()
    {
        return playerShipVelocity;
    }
    public Sprite playerImage; //Player Image
    public void SetPlayerImage(Sprite image)
    {
        playerImage = image;
    }
    public Sprite GetPlayerImage()
    {
        return playerImage;
    }
    public int playerLevel; //Player Level
    public int GetPlayerLevel()
    {
        return playerLevel;
    }
    private float playerExperience; //Player Experience
    private float experienceToNextLevel;
    public float GetExperienceToNextLevel()
    {
        return experienceToNextLevel;
    }
    public float GetCurrentExperience()
    {
        return playerExperience;
    }
    public void RemoveExperiencePoints(float expToRemove)
    {
        playerExperience -= expToRemove;
    }
    public void AddExperiencePoints(float expToAdd)
    {
        playerExperience += expToAdd;
    }
    private float weightOfCargo = 0; //Cargo Weight
    public float GetCurrentCargoWeight()
    {
        return weightOfCargo;
    }
    public void SetPlayerCargoWeight(float weightofcargo)
    {
        weightOfCargo = weightofcargo;
    }
    public void AddToCurrentCargoWeight(float addtocargoweight)
    {
        weightOfCargo += addtocargoweight;
    }
    private float playerCredits = 687459; //Available currency
    public float GetCurrentCredits()
    {
        return playerCredits;
    }
    public void SetPlayerCredits(float playercredits)
    {
        playerCredits = playercredits;
    }
    public void AddToCurrentCredits(float addcredits)
    {
        playerCredits += addcredits;
    }

    #region Player Skills
    public List<PlayerSkill> playerSkills = new List<PlayerSkill>();
    public int availableSkillPoints;
    public int totalSkillPoints;
    public void RemoveAvailableSkillPoints(int spToRemove)
    {
        availableSkillPoints -= spToRemove;
    }
    public void AddAvailableSkillPoints(int spToAdd)
    {
        availableSkillPoints += spToAdd;
    }
    public int GetAvailableSkillPoints()
    {
        return availableSkillPoints;
    }
    public void SetAvailableSkillPoints(int availSp)
    {
        availableSkillPoints = availSp;
    }
    public void GetPlayerSkillsFromGameManager()
    {
        playerSkills = GameManager.Instance.playerSkills;
    }
    public void SetPlayerSkillsToGameManager()
    {
        GameManager.Instance.SetPlayerSkills(playerSkills);
    }
    #endregion


    #region Player Inventory
    public GameObject playerInvWindow;
    public Inventory playerInvClass;
    public void OpenInventoryWindow()
    {
        playerInvWindow.SetActive(true);
    }
    public void CloseInventoryWindow()
    {
        playerInvWindow.SetActive(false);
    }
    public void AddItemToInventory(Item itemToAdd)
    {
        playerInvClass.AddItem(itemToAdd);
    }
    public void TakeItemFromInventoryByID(Guid itemID, int itemQuant = 0)
    {
        playerInvClass.RetrieveItem(itemID, itemQuant);
    }
    public void TakeItemFromInventoryBySlot(int slot, int itemQuant = 0)
    {
        playerInvClass.RetrieveItemByIndex(slot, itemQuant);
    }
    public void DeleteItemFromInventoryByID(Guid itemID)
    {
        playerInvClass.RemoveItemByID(itemID);
    }
    public void RemoveItemFromInventoryByIndex(int index)
    {
        playerInvClass.RemoveItemByIndex(index);
    }
    public List<Item> GetPlayerInventoryContents()
    {
        return playerInvClass.GetPlayerInventoryContents();
    }
    #endregion

    #region Hull
    [SerializeField]
    public Hull hull { get; private set; }
    private float maxHullPoints;
    private float currentHullPoints;
    private float hullMaxSpeed;
    private int cargoCapacity;
    private float hullTurnSpeed;
    public string currentHullModel;
    public GameObject boarModel;
    public GameObject muleModel;
    public Hull GetHull()
    {
        return hull;
    }
    public void EquipHull(Hull hullIn)
    {
        hull = hullIn;
        maxHullPoints = hullIn.maxHullPoints;
        currentHullPoints = maxHullPoints;
        hullMaxSpeed = hullIn.maxSpeed;
        hullTurnSpeed = hullIn.turnSpeed;
        hull.CheckForEquipment();

        switch (hull.hullModel)
        {
            case "Boar":
                boarModel.SetActive(true);
                currentHullModel = "Boar";
                break;
            case "Mule":
                muleModel.SetActive(true);
                currentHullModel = "Mule";
                break;
        }
    }
    public float GetMaxHullPoints()
    {
        return maxHullPoints;
    }
    public float GetCurrentHullPoints()
    {
        return currentHullPoints;
    }
    public void SetCurrentHull(float ch)
    {
        currentHullPoints = ch;
    }
    #endregion

    #region Shields
    public Shield shield; //Shields
    public float maxShields;
    public float currentShieldPoints;
    public float shieldRechargeRate;
    public float shieldRechargeDelay;
    public GameObject energyShieldEffect;
    public void EquipShield(Shield Shield)
    {
        shield = Shield;

        if (shield != null)
        {
            shieldRechargeDelay = shield.rechargeDelay;
            shieldRechargeRate = shield.rechargeRate;
        }
        else
        {
            shieldRechargeDelay = 0;
            shieldRechargeRate = 0;
        }

    }
    public void DisableShieldEffect()
    {
        energyShieldEffect.SetActive(false);
    }
    public void EnableShieldEffect()
    {
        energyShieldEffect.SetActive(true);
    }
    public float GetCurrentShieldPoints()
    {
        return currentShieldPoints;
    }
    public void SetCurrentShieldPoints(float sp)
    {
        currentShieldPoints = sp;
    }
    public void ReduceCurrentShieldBy(float rsp)
    {
        currentShieldPoints -= rsp;
    }
    public void SetMaxShields(float ms)
    {
        maxShields = ms;
    }
    public float GetMaxShields()
    {
        return maxShields;
    }
    public void AddToCurrentShields(float atcs)
    {
        currentShieldPoints += atcs;
    }
    #endregion

    #region Armor
    public Armor armor; //Armor
    private float resistanceMod;
    private float weaknessModifier;
    public void EquipArmor(Armor Armor)
    {
        armor = Armor;
        if (armor != null)
        {
            resistanceMod = armor.resistanceModifier;
            weaknessModifier = Armor.weaknessModifier;
        }
        else
        {
            resistanceMod = 0;
            weaknessModifier = 0;
        }


    }
    public Reactor reactor; //Reactor
    public float maxEnergy;
    public float energyRechargeRate;
    //public void EquipReactor(Reactor Reactor)
    //{
    //    reactor = Reactor;
    //    availEnergy = 0;
    //    if (reactor != null)
    //    {
    //        maxEnergy = Reactor.maxPower;
    //        energyRechargeRate = Reactor.rechargeRate;
    //        StartCoroutine(ReactorRegenerate());
    //    }
    //    else
    //    {
    //        maxEnergy = 0;
    //        energyRechargeRate = 0;
    //        StopCoroutine(ReactorRegenerate());
    //    }

    //}
    public void UnequipReactor(Reactor Reactor)
    {
        reactor = Reactor;
        maxEnergy = Reactor.maxPower;
        energyRechargeRate = Reactor.rechargeRate;
        StopCoroutine(hull.equippedReactor.ReactorRegenerate());

    }
    
    #endregion

    #region Engine
    public Engine engine; //Engine
    public float maxEngineSpeed;
    public float engineTurnSpeed;
    public float engineBoostSpeed;
    public float engineBoostEnergyCost;
    public float engineBoostCoolDown;
    public float nextEngineBoost;
    public bool boostOnCoolDown = false;
    public void EquipEngine(Engine Engine)
    {
        engine = Engine;
        if (engine != null)
        {
            maxEngineSpeed = engine.maxSpeed;
            engineTurnSpeed = engine.turnSpeed;
            engineBoostSpeed = engine.boostSpeed;
            engineBoostEnergyCost = engine.boostEnergyCost;
            engineBoostCoolDown = engine.boostCoolDown;
        }
        else
        {
            maxEngineSpeed = 0;
            engineTurnSpeed = 0;
            engineBoostSpeed = 0;
            engineBoostEnergyCost = 0;
            engineBoostCoolDown = 0;
        }


    }
    public float GetMaxSpeed()
    {
        return maxEngineSpeed;
    }
    public float GetTurnSpeed()
    {
        return engineTurnSpeed;
    }
    public float GetBoostSpeed()
    {
        return engineBoostSpeed;
    }
    public float GetBoostEnergyCost()
    {
        return engineBoostEnergyCost;
    }
    public float GetBoostCoolDown()
    {
        return engineBoostCoolDown;
    }
    #endregion

    #region Weapon0
    public Weapon weapon0; //Weapon0
    private float minDamageW0;
    private float maxDamageW0;
    private float refireRateW0;
    private float energyCostShotW0;
    private Weapon.DamageType damageTypeW0;
    private float refireTimerW0;
    private float nextFireW0 = 0;
    public GameObject projectileSpawnPointW0;
    private int weapon0PoolCapactiy = 50;
    public void EquipWeapon(Weapon weapon, int slot = -1)
    {
        if (weapon != null)
        {
            if (weapon0 == null || (weapon0 == null && slot == 0))
            {
                weapon0 = weapon;
                minDamageW0 = weapon0.minDamage;
                maxDamageW0 = weapon0.maxDamage;
                refireRateW0 = weapon0.refireRate;
                energyCostShotW0 = weapon0.energyCost;
                damageTypeW0 = weapon0.dmgType;
            }
            else if (weapon1 == null || (weapon1 == null && slot == 1))
            {
                weapon1 = weapon;
                minDamageW1 = weapon1.minDamage;
                maxDamageW1 = weapon1.maxDamage;
                refireRateW1 = weapon1.refireRate;
                energyCostShotW1 = weapon1.energyCost;
                damageTypeW1 = weapon1.dmgType;
            }
        }
        else
        {
            if (slot == 0)
            {
                minDamageW0 = 0;
                maxDamageW0 = 0;
                refireRateW0 = 0;
                energyCostShotW0 = 0;
                damageTypeW0 = 0;
            }
            else if (slot == 1)
            {
                weapon1 = weapon;
                minDamageW1 = 0;
                maxDamageW1 = 0;
                refireRateW1 = 0;
                energyCostShotW1 = 0;
                damageTypeW1 = 0;
            }
        }


    }
    public GameObject GetProjectileSpawnPointWeapon0()
    {
        return projectileSpawnPointW0;
    }
    public float GetWeapon0MinDamage()
    {
        return minDamageW0;
    }
    public float GetWeapon0MaxDamage()
    {
        return maxDamageW0;
    }
    public float GetRefireRateWeapon0()
    {
        return refireRateW0;
    }
    public float GetEnergyCostShotWeapon0()
    {
        return energyCostShotW0;
    }
    public Weapon.DamageType GetDamageTypeWeapon0()
    {
        return damageTypeW0;
    }
    #endregion

    #region Weapon1
    public Weapon weapon1; //Weapon1
    private float minDamageW1;
    private float maxDamageW1;
    private float refireRateW1;
    private float energyCostShotW1;
    private Weapon.DamageType damageTypeW1;
    private float refireTimerW1;
    private float nextFireW1 = 0;
    public GameObject projectileSpawnPointW1;
    private int weapon1PoolCapactiy = 50;
    public void EquipWeapon1(Weapon weapon1)
    {
        minDamageW1 = weapon1.minDamage;
        maxDamageW1 = weapon1.maxDamage;
        refireRateW1 = weapon1.refireRate;
        energyCostShotW1 = weapon1.energyCost;
        damageTypeW1 = weapon1.dmgType;

    }
    public GameObject GetProjectileSpawnPointWeapon1()
    {
        return projectileSpawnPointW1;
    }
    public float GetWeapon1MinDamage()
    {
        return minDamageW1;
    }
    public float GetWeapon1MaxDamage()
    {
        return maxDamageW1;
    }
    public float GetRefireRateWeapon1()
    {
        return refireRateW1;
    }
    public float GetEnergyCostShotWeapon1()
    {
        return energyCostShotW1;
    }
    public Weapon.DamageType GetDamageTypeWeapon1()
    {
        return damageTypeW1;
    }
    #endregion

    //Player Equipment
    public void EquipModule(Item equipment)
    {

        Debug.Log("PEH: Item to be equipeed: " + equipment);
        if (!equipment.isEquipped)
        {
            Debug.Log("PEH: EQ is NOT equipped if broke");
            // equipment.isEquipped = true;


            Debug.Log("PEH equipm0ent type, Item: " + equipment.itemType.ToString());
            switch (equipment.itemType)
            {
                case ItemType.Engine:
                    if (hull.equippedEngine != null)
                    {
                        //   UnEquipItem("Engine");
                    }
                    hull.EquipEngine(equipment as Engine);
                    hull.engineEquipped = true;
                    break;
                case ItemType.Armor:
                    if (hull.equippedArmor != null)
                    {
                        //   UnEquipItem("Engine");
                    }
                    hull.EquipArmor(equipment as Armor);
                    hull.armorEquipped = true;
                    break;
                case ItemType.Shield:
                    if (hull.equippedShields != null)
                    {
                        //     UnEquipItem("Engine");
                    }
                    hull.EquipShield(equipment as Shield);
                    hull.shieldEquipped = true;
                    break;
                case ItemType.Reactor:
                    if (hull.equippedReactor != null)
                    {
                        //     UnEquipItem("Engine");
                    }
                    hull.EquipReactor(equipment as Reactor);
                    hull.reactorEquipped = true;
                    break;
                case ItemType.Weapon:
                    if (hull.equippedWeapon0 == null && hull.equippedWeapon1 == null)
                    {
                        hull.EquipWeapon0(equipment as Weapon);
                        hull.weapon0Equipped = true;
                        break;
                    }
                    if (hull.equippedWeapon0 != null && hull.equippedWeapon1 == null)
                    {
                        hull.EquipWeapon1(equipment as Weapon);
                        hull.weapon1Equipped = true;
                        break;
                    }
                    break;
            }
        }
    }
    public void UnequipItem(string itemToUnequip)
    {
        Debug.Log("POC: string of module to uneq: " + itemToUnequip);
        // Debug.Log("POC: item returned by uneq command: " + _PEH.UnEquipItem(itemToUnequip).GetType().ToString());
        AddItemToInventory(hull.UnequipItem(itemToUnequip));
    }
    public bool CheckIfAlreadyEquipped(string moduleType)
    {
        switch (moduleType)
        {
            case "Armor":
                if (armor != null)
                {
                    return true;
                }
                return false;
            case "Reactor":
                if (reactor != null)
                {
                    return true;
                }
                return false;
            case "Engine":
                if (engine != null)
                {
                    return true;
                }
                return false;
            case "Shield":
                if (shield != null)
                {
                    return true;
                }
                return false;
            case "Weapon":
                if (weapon0 != null && weapon1 != null)
                {
                    return true;
                }
                return false;
        }
        return false;
    }

    //Equipment tracking variables
   
    private void RegenerateEquipment()
    {
        if (hull.equippedReactor != null && !hull.equippedReactor.reactorRegenOnCoolDown)
        {

            StartCoroutine(hull.equippedReactor.ReactorRegenerate());
        }

        if (hull.equippedShields != null && !hull.equippedShields.shieldRegenOnCoolDown && !hull.equippedShields.shieldRechargeDelayInEffect)
        {

            StartCoroutine(hull.equippedShields.ShieldRegenerate());
        }
    }


   


    //Engine Control Systems
    private void Movement()
        {

        moveVector.x = rewiredPlayer.GetAxis("Move Horizontal");
            moveVector.z = rewiredPlayer.GetAxis("Move Vertical");

        if (moveVector.x != 0.0001f || moveVector.z != 0.0001f )
            {
            if (hull.equippedEngine != null)
            {
                rb.AddForce(moveVector * hull.equippedEngine.maxSpeed * Time.deltaTime);
            }

            
        }
        }
    private void Rotate()
        {
            if (hull.equippedEngine != null)
            {
                if (moveVector.x != 0.001f || moveVector.z != 0.001f)
                {

                    //transform.position = new Vector3();
                    //tr.transform.Rotate(new Vector3(0, moveVector.z, 0) * Time.deltaTime * engineTurnSpeed);
                    //tr.transform.Rotate(new Vector3(0, moveVector.x, 0) * Time.deltaTime * engineTurnSpeed);

                    Vector3 targetDir = moveVector;
                    float step = hull.equippedEngine.turnSpeed * Time.deltaTime;
                    Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
                    // Debug.DrawRay(transform.position, newDir, Color.red);
                    transform.rotation = Quaternion.LookRotation(newDir);

                    //var newRotation = Quaternion.LookRotation(Camera.main.transform.position - transform.position).eulerAngles;
                    //newRotation.x = 0;
                    //newRotation.z = 0;
                    //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(newRotation), Time.deltaTime);
                }
            }
        }
    //public void BoostController()
    //    {
    //        if (rewiredPlayer.GetAxis("TurboBoost") > 0)
    //        {
    //            Debug.Log("boost trigger loop passed");
    //            if (hull.equippedEngine.boostEnergyCost < availEnergy && !boostOnCoolDown)
    //            {
    //                Debug.Log("boost cool down loop passed");
    //                availEnergy -= hull.equippedEngine.boostEnergyCost;
    //                rb.AddForce(moveVector.normalized * hull.equippedEngine.boostSpeed * Time.deltaTime, ForceMode.Impulse);
    //                Invoke("BoostCoolDownReset", (hull.equippedEngine.boostCoolDown + .5f));
    //                boostOnCoolDown = true;
    //            }
    //        }
    //    }
    private void BoostCoolDownReset()
        {
            boostOnCoolDown = false;
        }

    //radar
    private Radar radar;

    
    

    //Weapon2
    public Weapon Weapon2;
    private float minDamageW2;
    private float maxDamageW2;
    private float refireRateW2;
    private float energyCostShotW2;
    private Weapon.DamageType damageTypeW2;
    private float refireTimerW2;
    private float nextFireW2 = 0;
    public GameObject projectileSpawnPointW2;
    private int weapon2PoolCapactiy = 50;
    public void EquipWeapon2(Weapon weapon2)
    {
        minDamageW2 = weapon2.minDamage;
        maxDamageW2 = weapon2.maxDamage;
        refireRateW2 = weapon2.refireRate;
        energyCostShotW2 = weapon2.energyCost;
        damageTypeW2 = weapon2.dmgType;
    }
    public GameObject GetProjectileSpawnPointWeapon2()
    {
        return projectileSpawnPointW2;
    }
    public float GetWeapon2MinDamage()
    {
        return minDamageW2;
    }
    public float GetWeapon2MaxDamage()
    {
        return maxDamageW2;
    }
    public float GetRefireRateWeapon2()
    {
        return refireRateW2;
    }
    public float GetEnergyCostShotWeapon2()
    {
        return energyCostShotW2;
    }
    public Weapon.DamageType GetDamageTypeWeapon2()
    {
        return damageTypeW2;
    }

    //Weapon Systems

    private bool weaponOnCooldown = false;
    
    IEnumerator Fire()
        {

        if (hull.equippedReactor.availableEnergy >= hull.equippedWeapon0.energyCost && !weaponOnCooldown)
        {
            weaponOnCooldown = true;
            hull.equippedWeapon0.FireWeapon();
            hull.equippedReactor.ReduceAvailableEnergy(hull.equippedWeapon0.energyCost);
            yield return new WaitForSecondsRealtime(hull.equippedWeapon0.refireRate);
            weaponOnCooldown = false;
        }

        //if (hull.equippedReactor.availableEnergy >= hull.equippedWeapon0.energyCost && refireTimer <= 0) 
        //{
            
        //    //if ((nextFire >= GetRefireRate()) && GetEnergyCostShot() < GetAvailEnergy())
        //    //{
        //    //    GameObject obj = (GameObject)Instantiate(projectileSlot1);
        //    //    obj.SendMessage("ProjectileSpawned");
        //    //    SetAvailEnergy(GetAvailEnergy() - GetEnergyCostShot());
        //    //    nextFire = 0;
        //    //    Debug.Log("Projectile created . Life: " + projectileLife + "mindmg: " + minDamageW + "maxdmg: " + maxDamageW + "speed(force): " + projectileForce + " refirerate: " + GetRefireRate());
        //    //}
        //    //break;
        //    hull.equippedWeapon0.FireWeapon();
        //    hull.equippedReactor.ReduceAvailableEnergy(hull.equippedWeapon0.energyCost);
        //}


    }

    //Repair Bots
    private RepairBots repairBots;

    //Rewired
    public int rewiredPlayerId = 0;
    private Player rewiredPlayer;
    private Vector3 moveVector;
    private float rotate;
    private Vector3 rightTrigger;
    private Vector3 LeftTrigger;

    public GameObject camera;
    public GenerateDebrisOnDestroy modelToDestroy;
    private Rigidbody rb;
    private Transform tr;
    private Vector3 shipSpeed;

    private void Awake()
    {
       // EquipHull(GameManager.Instance.playerShip);
        rewiredPlayer = ReInput.players.GetPlayer(rewiredPlayerId);
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();

    }
    void Update()
    {
        if (rewiredPlayer.GetAxis("Fire") > 0)
        {
           StartCoroutine(Fire());
        }

        if (hull != null)
        {
            RegenerateEquipment();
        }
        

    }

    private void FixedUpdate()
    {
        if (rewiredPlayer == null)
        {
            rewiredPlayer = ReInput.players.GetPlayer(rewiredPlayerId);
        }
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        if (tr == null)
        {
            tr = GetComponent<Transform>();
        }
        if (rb != null && hull != null)
        {
            Movement();
            Rotate();
            SetPlayerShipVelocity();
            //BoostController();
        }


        //nextFireW0 += Time.deltaTime;
        nextEngineBoost += Time.deltaTime;
    }
    //public void TakeDamage(float damage)
    //{

    //    //if (currentShields > 0)
    //    //{
    //    //    if (currentShields < damage)
    //    //    {
    //    //        DamageHull(damage - currentShields);
    //    //        currentShields = (-1);
    //    //    }
    //    //    currentShields -= damage;
    //    //}
    //    else if (GetCurrentHullPoints() > 0)
    //    {
    //        DamageHull(damage);
    //    }
    //    else
    //    {
    //        DestroyShip();
    //    }

   // } //take damage
    private void DamageHull(float hullDmg)
    {
        SetCurrentHull(GetCurrentHullPoints() - hullDmg);
        //method will eventually handle subsystem damage
    }
    // called to destroy ship and generate explosion graphic


    public void ToggleCamera()
    {
        if (camera.activeInHierarchy)
        {
            camera.SetActive(true);
        }
        else
        {
            camera.SetActive(false);
        }
    }
    private void Start()
    {

        // rewiredPlayer = ReInput.players.GetPlayer(rewiredPlayerId);
        // Debug.Log("Rewiredplayer in Start: " + rewiredPlayer);
        //  tr = GetComponent<Transform>();
        //  rb = GetComponent<Rigidbody>();
    }
    void DestroyShip()
    {

        modelToDestroy.DestroyStarship();
        Destroy(gameObject);
    }
    public class Debug
    {
        public static void Log(object obj)
        {
            UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + obj);

        }
    } // time stamps debug    
}
