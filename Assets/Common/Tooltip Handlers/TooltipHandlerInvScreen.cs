//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

////public enum EquipmentType
////{
////    Engine, Armor, Shield, Reactor, Weapon0, Weapon1
////}

//public class TooltipHandlerInvScreen : MonoBehaviour
//{

//    public EquipmentType EquipmentSlot;

//    public Font font;
//    public FontStyle fontStyle;

//    public Color
//        defaultColor,
//        rarityColor,
//        bonusColor;

//    // public Rect windowRect; //Sword icon rectangle
//    private Tooltip tooltipScript;
//    private Engine engine;
//    private Tooltip enginetooltipScript;
//    public bool engineIsEquipped;
//    private bool engineTooltipSet = false;
//    public bool engineNull;
//    private Weapon weapon0;
//    private Tooltip weapon0tooltipScript;
//    private bool weapon0TooltipSet = false;
//    private Weapon weapon1;
//    private Tooltip weapon1tooltipScript;
//    private bool weapon1TooltipSet = false;
//    private Armor armor;
//    private Tooltip armortooltipScript;
//    private bool armorTooltipSet = false;
//    private Shield shield;
//    private Tooltip shieldtooltipScript;
//    private bool shieldTooltipSet = false;
//    private Reactor reactor;
//    private Tooltip reactortooltipScript;
//    private bool reactorTooltipSet = false;
//    private PlayerEquipmentHandler playerEqHandler;
//    private Image slotOccupied;

//    void GenerateEngineTooltip()
//    {

//        //   tooltipScript.guiItemRect = windowRect; //Set the mouse recognation rect in the tooltip script to windowRect (sword icon rectangle)

//        //Adds 5 lines to the left side (text, font, fontStyle, color)
//        tooltipScript.leftSideText.Add(new TooltipProperties(engine.itemName, font, fontStyle, rarityColor));
//        tooltipScript.leftSideText.Add(new TooltipProperties(engine.itemType, font, fontStyle, defaultColor));
//        tooltipScript.leftSideText.Add(new TooltipProperties("Speed: " + engine.maxSpeed, font, fontStyle, defaultColor));
//        tooltipScript.leftSideText.Add(new TooltipProperties("Boost: " + engine.boostSpeed, font, fontStyle, bonusColor));
//        tooltipScript.leftSideText.Add(new TooltipProperties("Boost Cost: " + (engine.boostEnergyCost).ToString(), font, fontStyle, bonusColor));

//    }

//    void GenerateReactorTooltip()
//    {

//        //   tooltipScript.guiItemRect = windowRect; //Set the mouse recognation rect in the tooltip script to windowRect (sword icon rectangle)

//        //Adds 5 lines to the left side (text, font, fontStyle, color)
//        tooltipScript.leftSideText.Add(new TooltipProperties(reactor.itemName, font, fontStyle, rarityColor));
//        tooltipScript.leftSideText.Add(new TooltipProperties(reactor.itemType, font, fontStyle, defaultColor));
//        tooltipScript.leftSideText.Add(new TooltipProperties("Maxium Energy Capactity: " + reactor.maxPower, font, fontStyle, defaultColor));
//        reactortooltipScript.leftSideText.Add(new TooltipProperties("Recharge Rate: " + reactor.RechargeRate() + (reactor.RechargeRate() / 2) + " Per Second", font, fontStyle, bonusColor));

//    }

//    void GenerateShieldTooltip()
//    {

//        //  tooltipScript.guiItemRect = windowRect; //Set the mouse recognation rect in the tooltip script to windowRect (sword icon rectangle)

//        //Adds 5 lines to the left side (text, font, fontStyle, color)
//        shieldtooltipScript.leftSideText.Add(new TooltipProperties(shield.itemName, font, fontStyle, rarityColor));
//        shieldtooltipScript.leftSideText.Add(new TooltipProperties(shield.itemType, font, fontStyle, defaultColor));
//        shieldtooltipScript.leftSideText.Add(new TooltipProperties("Maxium Shield Capactity: " + shield.MaxCapacity(), font, fontStyle, defaultColor));
//        shieldtooltipScript.leftSideText.Add(new TooltipProperties("Recharge Rate: " + shield.RechargeRate() + (shield.RechargeRate() / 2) + " Per Second", font, fontStyle, bonusColor));
//        shieldtooltipScript.leftSideText.Add(new TooltipProperties("Recharge Delay: " + shield.rechargeDelay + " Seconds", font, fontStyle, bonusColor));

//    }

//    void GenerateArmorTooltip()
//    {

//        //  tooltipScript.guiItemRect = windowRect; //Set the mouse recognation rect in the tooltip script to windowRect (sword icon rectangle)

//        //Adds 5 lines to the left side (text, font, fontStyle, color)
//        armortooltipScript.leftSideText.Add(new TooltipProperties(armor.itemName, font, fontStyle, rarityColor));
//        armortooltipScript.leftSideText.Add(new TooltipProperties(armor.itemType, font, fontStyle, defaultColor));
//        armortooltipScript.leftSideText.Add(new TooltipProperties("Armor Effictivness: " + (armor.armorLevel * 100) + "% Reduction", font, fontStyle, defaultColor));
//        armortooltipScript.leftSideText.Add(new TooltipProperties("Bonus Effictivness to" + armor.damageResistance + ": " + (armor.resistanceModifier * 100) + "% Reduction", font, fontStyle, bonusColor));
//     //   armortooltipScript.leftSideText.Add(new TooltipProperties("Reduced Effectivness to" + armor.damageWeakness + ": " + (armor.weaknessModifier * 100) + "% Reduction", font, fontStyle, bonusColor));

//    }

//    void GenerateWeapon0Tooltip()
//    {

//        // tooltipScript.guiItemRect = windowRect; //Set the mouse recognation rect in the tooltip script to windowRect (sword icon rectangle)

//        //Adds 5 lines to the left side (text, font, fontStyle, color)
//        weapon0tooltipScript.leftSideText.Add(new TooltipProperties(weapon0.itemName, font, fontStyle, rarityColor));
//        weapon0tooltipScript.leftSideText.Add(new TooltipProperties(weapon0.itemType, font, fontStyle, defaultColor));
//        weapon0tooltipScript.leftSideText.Add(new TooltipProperties("Damage: " + weapon0.MinDamage() + " - " + weapon0.MaxDamage(), font, fontStyle, defaultColor));
//        weapon0tooltipScript.leftSideText.Add(new TooltipProperties("Cooldown: " + weapon0.RefireRate() + " Second(s)", font, fontStyle, bonusColor));
//        weapon0tooltipScript.leftSideText.Add(new TooltipProperties("Energy Cost: " + weapon0.EnergyCost() + " Per Shot", font, fontStyle, bonusColor));

//    }

//    void GenerateWeapon1Tooltip()
//    {

//        //  tooltipScript.guiItemRect = windowRect; //Set the mouse recognation rect in the tooltip script to windowRect (sword icon rectangle)

//        //Adds 5 lines to the left side (text, font, fontStyle, color)
//        weapon1tooltipScript.leftSideText.Add(new TooltipProperties(weapon1.itemName, font, fontStyle, rarityColor));
//        weapon1tooltipScript.leftSideText.Add(new TooltipProperties(weapon1.itemType, font, fontStyle, defaultColor));
//        weapon1tooltipScript.leftSideText.Add(new TooltipProperties("Damage: " + weapon1.MinDamage() + " - " + weapon1.MaxDamage(), font, fontStyle, defaultColor));
//        weapon1tooltipScript.leftSideText.Add(new TooltipProperties("Cooldown: " + weapon1.RefireRate() + " Second(s)", font, fontStyle, bonusColor));
//        weapon1tooltipScript.leftSideText.Add(new TooltipProperties("Energy Cost: " + weapon1.EnergyCost() + " Per Shot", font, fontStyle, bonusColor));

//    }

//    private void Update()
//    {
//        switch (EquipmentSlot)
//        {
//            case EquipmentType.Engine:
//                engine = playerEqHandler.GetEngine();
//                enginetooltipScript = transform.GetComponent<Tooltip>() as Tooltip;
//                //  tooltipScript.guiItemRect = windowRect;
//                if (!engineTooltipSet)
//                {
//                    if (engine != null)
//                    {
//                        GenerateEngineTooltip();
//                        engineTooltipSet = true;
//                    }
//                }
//                if (engine = null)
//                {
//                    engineTooltipSet = false;
//                }

//                break;
//            case EquipmentType.Armor:
//                armor = playerEqHandler.GetArmor();
//                armortooltipScript = transform.GetComponent<Tooltip>() as Tooltip;

//                //tooltipScript.guiItemRect = windowRect;
//                if (!armorTooltipSet)
//                {
//                    if (armor != null)
//                    {
//                        GenerateArmorTooltip();
//                        armorTooltipSet = true;
//                    }
//                }
//                if (engine = null)
//                {
//                    armorTooltipSet = false;
//                }
//                break;
//            case EquipmentType.Shield:
//                shield = playerEqHandler.GetShield();
//                shieldtooltipScript = transform.GetComponent<Tooltip>() as Tooltip;
//                //tooltipScript.guiItemRect = windowRect;
//                if (!shieldTooltipSet)
//                {
//                    if (shield != null)
//                    {
//                        GenerateShieldTooltip();
//                        shieldTooltipSet = true;
//                    }
//                }
//                if (engine = null)
//                {
//                    shieldTooltipSet = false;
//                }
//                break;
//            case EquipmentType.Reactor:
//                reactor = playerEqHandler.GetReactor();
//                reactortooltipScript = transform.GetComponent<Tooltip>() as Tooltip;
//                //tooltipScript.guiItemRect = windowRect;
//                if (!reactorTooltipSet)
//                {
//                    if (reactor != null)
//                    {
//                        GenerateReactorTooltip();
//                        reactorTooltipSet = true;
//                    }
//                }
//                if (engine = null)
//                {
//                    reactorTooltipSet = false;
//                }
//                break;
//            case EquipmentType.Weapon0:
//                weapon0 = playerEqHandler.GetWeapon0();
//                weapon0tooltipScript = transform.GetComponent<Tooltip>() as Tooltip;
//                Debug.Log("weapon0: " + weapon0 + "collect");
//                //tooltipScript.guiItemRect = windowRect;
//                if (!weapon0TooltipSet)
//                {
//                    if (weapon0 != null)
//                    {

//                        GenerateWeapon0Tooltip();
//                        weapon0TooltipSet = true;
//                        Debug.Log("tooltip should be generated/displaying");
//                    }
//                }
//                if (engine = null)
//                {
//                    weapon0TooltipSet = false;
//                }
//                break;
//            case EquipmentType.Weapon1:
//                weapon1 = playerEqHandler.GetWeapon1();
//                weapon1tooltipScript = transform.GetComponent<Tooltip>() as Tooltip;
//                Debug.Log("weapon1: " + weapon1 + "collect");
//                //tooltipScript.guiItemRect = windowRect;
//                if (!weapon1TooltipSet)
//                {
//                    if (weapon1 != null)
//                    {

//                        GenerateWeapon1Tooltip();
//                        weapon1TooltipSet = true;
//                        Debug.Log("tooltip should be generated/displaying");
//                    }
//                }
//                if (engine = null)
//                {
//                    weapon1TooltipSet = false;
//                }
//                break;

//        }
//    }

//    private void Awake()
//    {
//        playerEqHandler = FindObjectOfType<PlayerEquipmentHandler>();

//    }

//    private void OnEnable()
//    {
//        //  windowRect = windowRect = new Rect(1260, 543, 60, 60);
//        playerEqHandler = FindObjectOfType<PlayerEquipmentHandler>();

//    }

//    //=
//    //void Start()
//    //{

//    //    tooltipScript.guiItemRect = windowRect; //Set the mouse recognation rect in the tooltip script to windowRect (sword icon rectangle)

//    //    //Adds 5 lines to the left side (text, font, fontStyle, color)
//    //    tooltipScript.leftSideText.Add(new TooltipProperties(itemName, font, fontStyle, rarityColor));
//    //    tooltipScript.leftSideText.Add(new TooltipProperties(type, font, fontStyle, defaultColor));
//    //    tooltipScript.leftSideText.Add(new TooltipProperties("Damage: " + damage, font, fontStyle, defaultColor));
//    //    tooltipScript.leftSideText.Add(new TooltipProperties("+" + strengthBonus + " Strength", font, fontStyle, bonusColor));
//    //    tooltipScript.leftSideText.Add(new TooltipProperties("+" + staminaBonus + " Stamina", font, fontStyle, bonusColor));

//    //    //Adds 1 line to the right side (text, font, fontStyle, color, line)
//    //    tooltipScript.rightSideText.Add(new TooltipRightSideProperties(slot, font, fontStyle, defaultColor, 2));
//    //}
//}
