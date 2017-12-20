using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsController : MonoBehaviour {

    [Header("Update during Runtime")]
    bool runtimeChange;

    public Vector3 playerStartLocation;
    public float playerStartingCredits;
    public  float playerStartingLevel;
    public  float playerStartingSkillPoints;
    public  float playerStarterWeaponMinDmg;
    public float playerStarterWeaponMaxDmg;
    public float playerStarterWeaponRefireRate;
    public  float playerStarterWeaponEnergyCost;
    public  float playerStarterShieldMaxCapacity;
    public  float playerStarterShieldRechargeRate;
    public  float playerStarterRechargeDelay;
    public  float playerStarterShieldDmgTypeResistRate;
    public  float playerStarterShieldDmgTypeWeaknessRate;
    public  float playerStarterArmorLevel;
    public  float playerStarterEngineSpeed;
    public  float playerStarterEngineTurnSpeed;
    public  float playerStarterEngineBoostSpeed;
    public  float playerStarterEngineBoostCost;
    public  float playerStarterEngineBoostCooldown;
    public  float playerStarterReactorMaxEnergy;
    public  float playerStarterReactorRechargeRate;
    public  Sprite playerStarterReactorIcon;
    public  Sprite playerStarterArmorIcon;
    public  Sprite playerStarterShieldIcon;
    public  Sprite playerStarterWeaponIcon;
    public  Sprite playerStarterEngineIcon;
    public  GameObject playerInvWindow;
    public  GameObject playerEqWindow;
    public  GameObject menuBar;
    public  GameObject vitalsBar;
    public  GameObject cameraZoom;

    private void Update()
    {
        if (runtimeChange)
        {
            
        }
    }
}
