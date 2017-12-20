using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoHandler : MonoBehaviour {

    public Text playerName;
    public Text availableSkillPoints;
    public Text availableXP;
    public Text XPToNextLevel;
    public Image XPToNextLevelBar;
    public Text currentLevel;
    public Text reputation;
    public Text faction;
    public Text debt;
    public Text netWorth;
    public Text availableCredits;
    public Text currentQuest;
    public Image playerImage;
    public Sprite shipImage;
    public Text shipName;
    public Text shipClass;
    public Text shipModel;
    public Text hullPoints;
    public Text maxSpeed;
    public Text cargoCapacity;
    public Image weapon0;
    public Weapon weapon0Obj;
    public Image weapon1;
    public Weapon weapon1Obj;
    public Image shield;
    public Shield shieldObj;
    public Image reactor;
    public Reactor reactorObj;
    public Image armor;
    public Armor armorObj;
    public Image engine;
    public Engine engineObj;

    private PlayerObject _POC;

    private void Awake()
    {
        _POC = FindObjectOfType<PlayerObject>();
    }

    private void OnEnable()
    {
        SetNonUpdatingText();
    }
    private void Update()
    {
        SetUpdatingText();
    }

    public void SetNonUpdatingText()
    {
        Hull playerhull = _POC.GetHull();
        shipClass.text = playerhull.GetShipClass().ToString();
        shipName.text = playerhull.GetPersonalName();
        shipModel.text = playerhull.GetModel();
        hullPoints.text = playerhull.GetMaxHullPoints().ToString();
        maxSpeed.text = playerhull.GetMaxSpeed().ToString();
        cargoCapacity.text = playerhull.GetCargoCapacity().ToString();
        shipImage = playerhull.shipIcon;
        weapon0.sprite = playerhull.equippedWeapon0.sprite;
        weapon0Obj = playerhull.equippedWeapon0;
        weapon1.sprite = playerhull.equippedWeapon1.sprite;
        weapon1Obj = playerhull.equippedWeapon1;
        shield.sprite = playerhull.equippedShields.sprite;
        shieldObj = playerhull.equippedShields;
        reactor.sprite = playerhull.equippedReactor.sprite;
        reactorObj = playerhull.equippedReactor;
        armor.sprite = playerhull.equippedArmor.sprite;
        armorObj = playerhull.equippedArmor;
        engine.sprite = playerhull.equippedEngine.sprite;
        engineObj = playerhull.equippedEngine;
        playerName.text = _POC.GetPlayerName();
        availableCredits.text = _POC.GetCurrentCredits().ToString();
        playerImage.sprite = _POC.GetPlayerImage();
        currentLevel.text = _POC.GetPlayerLevel().ToString();
        XPToNextLevel.text = _POC.GetExperienceToNextLevel().ToString();
        XPToNextLevelBar.fillAmount = (_POC.GetCurrentExperience() / _POC.GetExperienceToNextLevel());
    }
    public void SetUpdatingText()
    {
        availableXP.text = _POC.GetCurrentExperience().ToString();
        availableSkillPoints.text = _POC.GetAvailableSkillPoints().ToString();
    }
}
