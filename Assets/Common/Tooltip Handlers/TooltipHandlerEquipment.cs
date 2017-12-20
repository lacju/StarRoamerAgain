using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EquipmentType
{
    Engine, Armor, Shield, Reactor, Weapon0, Weapon1, Inventory
}

public class TooltipHandlerEquipment : MonoBehaviour
{

    public EquipmentType EquipmentSlot;

    public Font font;
    public FontStyle fontStyle;

    public Color
        weightColor,
        descriptionColor,
        typeColor,
        commonColor,
        uncommonColor,
        rareColor,
        epicColor,
        uniqueColor,
        statColor,
        questColor;

    private Color

        titleColor,
        valueColor,
        qualityColor;






    public Image Slot;
    public Rect windowRect;
    private Tooltip tooltipScriptItem;
    private Engine engine;
    private bool engineTooltipSet = false;
    [HideInInspector]
    public Item item;
    public int inventorySlotNumber;
    private bool inventoryToolTipSet = false;
    private Weapon weapon0;
    private bool weapon0TooltipSet = false;
    private Weapon weapon1;
    private bool weapon1TooltipSet = false;
    private Armor armor;
    private bool armorTooltipSet = false;
    private Shield shield;
    private bool shieldTooltipSet = false;
    private Reactor reactor;
    private bool reactorTooltipSet = false;
    private PlayerObject _POC;
    private Inventory playerInve;
    private Image slotOccupied;

    private Item tempItem;


    private void Awake()
    {
        playerInve = FindObjectOfType<Inventory>();
        tooltipScriptItem = transform.GetComponent<Tooltip>() as Tooltip;
        _POC = FindObjectOfType<PlayerObject>();
      //  windowRect = new Rect(Slot.transform.position.x, Slot.transform.position.y, 64, 64);
    }

    private void Start()
    {
        tooltipScriptItem.SetInvSlot(inventorySlotNumber);
    }

    

    void GenerateEngineTooltip()
    {
        tooltipScriptItem.leftSideText.Clear();
        tooltipScriptItem.rightSideText.Clear();

        SetColors(engine.itemQuality);
        //Adds 5 lines to the left side (text, font, fontStyle, color)
        tooltipScriptItem.leftSideText.Add(new TooltipProperties(engine.itemName, font, fontStyle, titleColor, 1));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties(engine.itemType.ToString(), font, fontStyle, typeColor, 2));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties("Speed: " + engine.maxSpeed, font, fontStyle, statColor, 3));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties("Boost: " + engine.boostSpeed, font, fontStyle, statColor, 4));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties("Boost Cost: " + (engine.boostEnergyCost).ToString("F2"), font, fontStyle, statColor, 5));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties(engine.itemDescription, font, fontStyle, descriptionColor, 6)); //.Replace("\\n", "\n")
        tooltipScriptItem.leftSideText.Add(new TooltipProperties("Weight: " + engine.itemWeight.ToString(), font, fontStyle, weightColor, 7));
        tooltipScriptItem.rightSideText.Add(new TooltipRightSideProperties(engine.itemQuality, font, fontStyle, qualityColor, 1));
        tooltipScriptItem.rightSideText.Add(new TooltipRightSideProperties(engine.baseCostCredits + "Cr", font, fontStyle, valueColor, 2));

    }
    void GenerateReactorTooltip()
    {
        tooltipScriptItem.leftSideText.Clear();
        tooltipScriptItem.rightSideText.Clear();
        //   tooltipScript.guiItemRect = windowRect; //Set the mouse recognation rect in the tooltip script to windowRect (sword icon rectangle)
        SetColors(reactor.itemQuality);
        //Adds 5 lines to the left side (text, font, fontStyle, color)
        tooltipScriptItem.leftSideText.Add(new TooltipProperties(reactor.itemName, font, fontStyle, titleColor, 1));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties(reactor.itemType.ToString(), font, fontStyle, typeColor, 2));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties("Maxium Energy Capactity: " + reactor.maxPower, font, fontStyle, statColor, 3));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties("Recharge Rate: " + (reactor.RechargeRate() / 2).ToString("F2") + " / Second", font, fontStyle, statColor, 4));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties(reactor.itemDescription, font, fontStyle, descriptionColor, 5));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties("", font, fontStyle, descriptionColor, 6));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties("Weight: " + reactor.itemWeight.ToString(), font, fontStyle, weightColor, 7));
        tooltipScriptItem.rightSideText.Add(new TooltipRightSideProperties(reactor.itemQuality, font, fontStyle, qualityColor, 1));
        tooltipScriptItem.rightSideText.Add(new TooltipRightSideProperties(reactor.baseCostCredits +"Cr", font, fontStyle, valueColor, 2));

    }
    void GenerateShieldTooltip()
    {
        tooltipScriptItem.leftSideText.Clear();
        tooltipScriptItem.rightSideText.Clear();
        //  tooltipScript.guiItemRect = windowRect; //Set the mouse recognation rect in the tooltip script to windowRect (sword icon rectangle)
        SetColors(shield.itemQuality);
        //Adds 5 lines to the left side (text, font, fontStyle, color)
        tooltipScriptItem.leftSideText.Add(new TooltipProperties(shield.itemName, font, fontStyle, titleColor, 1));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties(shield.itemType.ToString(), font, fontStyle, typeColor, 2));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties("Maxium Shield Capactity: " + shield.MaxCapacity(), font, fontStyle, statColor, 3));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties("Recharge Rate: " + (shield.RechargeRate() / 2).ToString("F2") + " / Second", font, fontStyle, statColor, 4));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties("Recharge Delay: " + shield.rechargeDelay.ToString("F2") + " Second(s)", font, fontStyle, statColor, 5));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties(shield.itemDescription, font, fontStyle, descriptionColor, 6));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties("Weight: " + shield.itemWeight.ToString(), font, fontStyle, weightColor, 7));
        tooltipScriptItem.rightSideText.Add(new TooltipRightSideProperties(shield.itemQuality, font, fontStyle, qualityColor, 1));
        tooltipScriptItem.rightSideText.Add(new TooltipRightSideProperties(shield.baseCostCredits + "Cr", font, fontStyle, valueColor, 2));

    }
    void GenerateArmorTooltip()
    {
        tooltipScriptItem.leftSideText.Clear();
        tooltipScriptItem.rightSideText.Clear();
        //  tooltipScript.guiItemRect = windowRect; //Set the mouse recognation rect in the tooltip script to windowRect (sword icon rectangle)
        SetColors(armor.itemQuality);
        //Adds 5 lines to the left side (text, font, fontStyle, color)
        tooltipScriptItem.leftSideText.Add(new TooltipProperties(armor.itemName, font, fontStyle, titleColor, 1));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties(armor.itemType.ToString(), font, fontStyle, typeColor,2));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties("Armor Rating: " + armor.armorLevel.ToString("F2") + "% Reduction", font, fontStyle, statColor, 3));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties(armor.resistanceModifier.ToString("F2") + "%" + " Reduction Against  " + armor.damageResistance, font, fontStyle, statColor, 4));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties(armor.weaknessModifier.ToString("F2") + "%" + " Reduction Against  " + armor.damageWeakness, font, fontStyle, statColor, 5)); 
        tooltipScriptItem.leftSideText.Add(new TooltipProperties(armor.itemDescription, font, fontStyle, descriptionColor, 6));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties("Weight: " + armor.itemWeight.ToString(), font, fontStyle, weightColor, 7));
        tooltipScriptItem.rightSideText.Add(new TooltipRightSideProperties(armor.itemQuality, font, fontStyle, qualityColor, 1));
        tooltipScriptItem.rightSideText.Add(new TooltipRightSideProperties(armor.baseCostCredits + "Cr", font, fontStyle, valueColor, 2));

    }
    void GenerateWeaponTooltip()
    {
        // tooltipScript.guiItemRect = windowRect; //Set the mouse recognation rect in the tooltip script to windowRect (sword icon rectangle)
        SetColors(weapon0.itemQuality);
        tooltipScriptItem.leftSideText.Clear();
        tooltipScriptItem.rightSideText.Clear();
        tooltipScriptItem.leftSideText.Add(new TooltipProperties(weapon0.itemName, font, fontStyle, titleColor,1 ));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties(weapon0.itemType.ToString(), font, fontStyle, typeColor, 2));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties("Damage: " + weapon0.minDamage + " - " + weapon0.maxDamage, font, fontStyle, statColor, 3));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties("Cooldown: " + weapon0.refireRate.ToString("F2") + " Second(s)", font, fontStyle, statColor,4 ));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties("Energy Cost: " + weapon0.energyCost.ToString("F2") + " / Shot", font, fontStyle, statColor, 5));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties(weapon0.itemDescription, font, fontStyle, descriptionColor, 6));
        tooltipScriptItem.leftSideText.Add(new TooltipProperties("Weight: " + weapon0.itemWeight.ToString(), font, fontStyle, weightColor, 7));
        tooltipScriptItem.rightSideText.Add(new TooltipRightSideProperties(weapon0.itemQuality, font, fontStyle, qualityColor, 1));
        tooltipScriptItem.rightSideText.Add(new TooltipRightSideProperties(weapon0.baseCostCredits + "Cr", font, fontStyle, valueColor, 2));

    }
    void SetColors(string quality)
    {
        switch (item.itemQuality)
        {
            case "Epic":
                qualityColor = epicColor;
                titleColor = epicColor;
                break;
            case "Rare":
                qualityColor = rareColor;
                titleColor = rareColor;
                break;
            case "Uncommon":
                qualityColor = uncommonColor;
                titleColor = uncommonColor;
                break;
            case "Common":
                qualityColor = commonColor;
                titleColor = commonColor;
                break;
        }
    }
    void GenerateInventoryTooltip()
    {
        valueColor = typeColor;

        if (item.isEquipment)
        {
            string equiptype = item.itemType.ToString();
            
            switch (equiptype)
            {
                case "Engine":
                    engine = item as Engine;
                    GenerateEngineTooltip();
                    break;
                case "Shield":
                    shield = item as Shield;
                    GenerateShieldTooltip();
                    break;
                case "Armor":
                    armor = item as Armor;
                    GenerateArmorTooltip();
                    break;
                case "Weapon":
                    weapon0 = item as Weapon;
                    GenerateWeaponTooltip();
                    break;
                case "Reactor":
                    reactor = item as Reactor;
                    GenerateReactorTooltip();
                    break;
            }
        }
        else
        {
            tooltipScriptItem.leftSideText.Add(new TooltipProperties(item.itemName, font, fontStyle, titleColor, 1));
            tooltipScriptItem.leftSideText.Add(new TooltipProperties(item.itemType.ToString(), font, fontStyle, typeColor, 2));
            tooltipScriptItem.leftSideText.Add(new TooltipProperties("Weight: " + item.itemWeight, font, fontStyle, statColor, 3));
            tooltipScriptItem.leftSideText.Add(new TooltipProperties(item.itemDescription, font, fontStyle, descriptionColor, 4));
            tooltipScriptItem.rightSideText.Add(new TooltipRightSideProperties(item.itemQuality, font, fontStyle, qualityColor, 1));
            tooltipScriptItem.rightSideText.Add(new TooltipRightSideProperties(item.baseCostCredits + "Cr", font, fontStyle, valueColor, 2));
        }

        //  tooltipScript.guiItemRect = windowRect; //Set the mouse recognation rect in the tooltip script to windowRect (sword icon rectangle)

        //Adds 5 lines to the left side (text, font, fontStyle, color)

    }

    private void Update()
    {

        switch (EquipmentSlot)
        {
            case EquipmentType.Engine:
                item = _POC.hull.equippedEngine;
                // tooltipScript = transform.GetComponent<Tooltip>() as Tooltip;
                //  tooltipScript.guiItemRect = windowRect;
                if (!inventoryToolTipSet)
                {
                    if (item != null)
                    {

                        GenerateInventoryTooltip();
                        engineTooltipSet = true;
                    }
                    if (item = null)
                    {
                        engineTooltipSet = false;
                    }
                }

                break;
            case EquipmentType.Armor:
                item = _POC.hull.equippedArmor;
                //     tooltipScript = transform.GetComponent<Tooltip>() as Tooltip;

                //tooltipScript.guiItemRect = windowRect;
                if (!inventoryToolTipSet)
                {
                    if (item != null)
                    {

                        GenerateInventoryTooltip();
                        armorTooltipSet = true;
                    }
                    if (item = null)
                    {
                        armorTooltipSet = false;
                    }
                }
                break;
            case EquipmentType.Shield:
                item = _POC.hull.equippedShields;
                //   tooltipScript = transform.GetComponent<Tooltip>() as Tooltip;
                //tooltipScript.guiItemRect = windowRect;
                if (!inventoryToolTipSet)
                {
                    if (item != null)
                    {

                        GenerateInventoryTooltip();
                        shieldTooltipSet = true;
                    }
                    if (item = null)
                    {
                        shieldTooltipSet = false;
                    }
                }
                break;
            case EquipmentType.Reactor:
                item = _POC.hull.equippedReactor;
                //   tooltipScript = transform.GetComponent<Tooltip>() as Tooltip;
                //tooltipScript.guiItemRect = windowRect;
                if (!inventoryToolTipSet)
                {
                    if (item != null)
                    {

                        GenerateInventoryTooltip();
                        reactorTooltipSet = true;
                    }
                    if (item = null)
                    {
                        reactorTooltipSet = false;
                    }
                }
                break;
            case EquipmentType.Weapon0:
                item = _POC.hull.equippedWeapon0;
                //    tooltipScript = transform.GetComponent<Tooltip>() as Tooltip;
                //tooltipScript.guiItemRect = windowRect;
                if (!inventoryToolTipSet)
                {
                    if (item != null)
                    {

                        GenerateInventoryTooltip();
                        weapon0TooltipSet = true;
                    }
                    if (item = null)
                    {
                        weapon0TooltipSet = false;
                    }
                }
                break;
            case EquipmentType.Weapon1:
                item = _POC.hull.equippedWeapon1;
                //    tooltipScript = transform.GetComponent<Tooltip>() as Tooltip;
                //tooltipScript.guiItemRect = windowRect;
                if (!weapon1TooltipSet)
                {
                    if (weapon1 != null)
                    {

                           GenerateWeaponTooltip();
                        weapon1TooltipSet = true;
                    }
                }
                if (weapon1 == null)
                {
                    weapon1TooltipSet = false;
                }
                break;
            case EquipmentType.Inventory:

                if (!inventoryToolTipSet)
                {
                    if (playerInve.items[inventorySlotNumber] != null)
                    {
                        item = playerInve.items[inventorySlotNumber];
                        tempItem = playerInve.items[inventorySlotNumber];
                        GenerateInventoryTooltip();
                        inventoryToolTipSet = true;
                    }
                }
                else if (playerInve.items[inventorySlotNumber] == null || (playerInve.items[inventorySlotNumber] != tempItem))
                {
                    inventoryToolTipSet = false;
                }


                break;
        }
        //     tooltipScript = transform.GetComponent<Tooltip>() as Tooltip;
        //    tooltipScript2 = transform.GetComponent<Tooltip>() as Tooltip;

  
    
        
    }


    private void OnEnable()
    {
        //  windowRect = windowRect = new Rect(1260, 543, 60, 60);
        _POC = FindObjectOfType<PlayerObject>();

    }

    //=
    //void Start()
    //{

    //    tooltipScript.guiItemRect = windowRect; //Set the mouse recognation rect in the tooltip script to windowRect (sword icon rectangle)

    //    //Adds 5 lines to the left side (text, font, fontStyle, color)
    //    tooltipScript.leftSideText.Add(new TooltipProperties(itemName, font, fontStyle, rarityColor));
    //    tooltipScript.leftSideText.Add(new TooltipProperties(type, font, fontStyle, defaultColor));
    //    tooltipScript.leftSideText.Add(new TooltipProperties("Damage: " + damage, font, fontStyle, defaultColor));
    //    tooltipScript.leftSideText.Add(new TooltipProperties("+" + strengthBonus + " Strength", font, fontStyle, bonusColor));
    //    tooltipScript.leftSideText.Add(new TooltipProperties("+" + staminaBonus + " Stamina", font, fontStyle, bonusColor));

    //    //Adds 1 line to the right side (text, font, fontStyle, color, line)
    //    tooltipScript.rightSideText.Add(new TooltipRightSideProperties(slot, font, fontStyle, defaultColor, 2));
    //}
}
