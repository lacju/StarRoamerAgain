//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class TooltipHandler : MonoBehaviour {

//    public Font font;
//    public FontStyle fontStyle;

//    public Color
//        defaultColor,
//        rarityColor,
//        bonusColor;

//    public Rect windowRect = new Rect(5, 5, 64, 64); //Sword icon rectangle
//    public Texture2D itemIcon; //Sword icon
//    private Tooltip tooltipScript;
//    private Engine engine;
//    private Weapon weapon0;
//    private Weapon weapon1;
//    private Armor armor;
//    private Shield shield;
//    private Reactor reactor;
//    private PlayerEquipmentHandler playerEqHandler;
//    private Image slotOccupied;

//    private void Update()
//    {
//        if (true)
//        {

//        }
//    }

//    private void Awake()
//    {
//        playerEqHandler = FindObjectOfType<PlayerEquipmentHandler>();
//        engine = playerEqHandler.GetEngine();
//        weapon0 = transform.GetComponent<Weapon>();
//        weapon1 = transform.GetComponent<Weapon>();
//        armor = transform.GetComponent<Armor>();
//        shield = transform.GetComponent<Shield>();
//        reactor = transform.GetComponent<Reactor>();
//        tooltipScript = transform.GetComponent<Tooltip>() as Tooltip; //Get the tooltip script
//    }

//    //void Start()
//    //{
//    //    tooltipScript = transform.GetComponent<Tooltip>() as Tooltip; //Get the tooltip script

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
