﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class VendorHandler : MonoBehaviour {

   // private InventoryDisplay invDisp;
    private Inventory playerInv;
    public Vector2 itemOffset;
    public Vector2 itemIconSize = new Vector2(60.0f, 60.0f);
    public Vector2 windowSize = new Vector2(450, 525);
    public Vector2 Offset = new Vector2(7, 12);
    private List<Transform> currentInv;
    private Rect windowRect = new Rect(200, 200, 108, 130);
    public GUISkin invSkinVendorScreen;
    private bool displayInv = false;
    public float adjustIconRows;
    private GUIContent itemToolTip;
    private string toolTipString;
    private int[] priceModifiers;
    private PlayerObject _POC;

    [Header("Good One")]
    public Sprite GoodOneSprite;
    public Text GoodOneName;
    public Text GoodOneDescription;
    public Text GoodOneSingleGoodPrice;
    public Text GoodOneFiveGoodPrice;
    public Text GoodOneStackPrice;
  //  public Reactor GoodOne; //test Item
    public Item GoodOne;
    private string goodOneDescription = " Assorted pieces of heavy equipment ranging \\n from industrial robotic components to \\n specialized starcraft repair tools, and \\n everything in between. There's never a \\n shortage of buyers looking for this stuff.";
    private float GoodOneBaseCost = 2500;
    private int GoodOneStackSize = 5;
    private float GoodOneWeight = 35; // in Kg


    [Header("Good Two")]
    public Sprite GoodTwoSprite;
    public Text GoodTwoName;
    public Text GoodTwoDescription;
    public Text GoodTwoSingleGoodPrice;
    public Text GoodTwoFiveGoodPrice;
    public Text GoodTwoStackPrice;
    public Item GoodTwo;
    private string goodTwoDescription = "A cornerstone of space colonization. It \\n fulfills all of the bodies protein \\n requirements and many of it's other \\n nutritional needs. Just try not to think \\n about where it comes from.";
    private float GoodTwoBaseCost = 250;
    private int GoodTwoStackSize = 20;
    private float GoodTwoWeight = 25;

    [Header("Good Three")]
    public Sprite GoodThreeSprite;
    public Text GoodThreeName;
    public Text GoodThreeDescription;
    public Text GoodThreeSingleGoodPrice;
    public Text GoodThreeFiveGoodPrice;
    public Text GoodThreeStackPrice;
    public Item GoodThree;
    private string goodThreeDescription = "Beloved by all of humanity for thousands of years which despite technological improvments over the centuries, hasn't changed much the last few centuries. We can however thank modern technology for eliminating the hangover.";
    private float GoodThreeBaseCost = 500;
    private int GoodThreeStackSize = 20;
    private float GoodThreeWeight = 5;

    [Header("Good Four")]
    public Sprite GoodFourSprite;
    public Text GoodFourName;
    public Text GoodFourDescription;
    public Text GoodFourSingleGoodPrice;
    public Text GoodFourFiveGoodPrice;
    public Text GoodFourStackPrice;
    public Item GoodFour;
    private string goodFourDescription = "One of the core pieces of technology that made space colonization possible. The ability to mass produce these components allowed for the creation of computers capable of controlling large space installations, and performing complex navigational calculations.";
    private float GoodFourBaseCost = 5000;
    private int GoodFourStackSize = 25;
    private float GoodFourWeight = 15;

    [Header("Good Five")]
    public Sprite GoodFiveSprite;
    public Text GoodFiveName;
    public Text GoodFiveDescription;
    public Text GoodFiveSingleGoodPrice;
    public Text GoodFiveFiveGoodPrice;
    public Text GoodFiveStackPrice;
    public Item GoodFive;
    private string goodFiveDescription = "Capable of turning even the lowest grade processed meat into the most delectible meal you've ever eaten. There are few humans who have tasted a meal seasoned with anything beyond salt. The privelege has become an experience for the filthy rich.";
    private float GoodFiveBaseCost = 7500;
    private int GoodFiveStackSize = 4;
    private float GoodFiveWeight = 10;

    [Header("Good Six")]
    public Sprite GoodSixSprite;
    public Text GoodSixName;
    public Text GoodSixDescription;
    public Text GoodSixSingleGoodPrice;
    public Text GoodSixFiveGoodPrice;
    public Text GoodSixStackPrice;
    public Item GoodSix;
    private string goodSixDescription = "Misscelanous varieties of processed ores necesary to advanced civilization. Without regular access to resources such as processed gold, platinum, uranium, neodymium, and many others technology production and research would stop.";
    private float GoodSixBaseCost = 1000;
    private int GoodSixStackSize = 10;
    private float GoodSixWeight = 25;

    [Header("Good Seven")]
    public Sprite GoodSevenSprite;
    public Text GoodSevenName;
    public Text GoodSevenDescription;
    public Text GoodSevenSingleGoodPrice;
    public Text GoodSevenFiveGoodPrice;
    public Text GoodSevenStackPrice;
    public Item GoodSeven;
    private string goodSevenDescription = "The begining of humanities golden age over a century ago can be traced directly to the development and commcerialization of liquid thorium reactors. They ushered in clean, limitless energy allowing the eventual colonization of our solar system.";
    private float GoodSevenBaseCost  = 1500;
    private int GoodSevenStackSize = 10;
    private float GoodSevenWeight = 20; // in Kg

    [Header("Good Eight")]
    public Sprite GoodEightSprite;
    public Text GoodEightName;
    public Text GoodEightDescription;
    public Text GoodEightSingleGoodPrice;
    public Text GoodEightFiveGoodPrice;
    public Text GoodEightStackPrice;
    public Item GoodEight;
    private string goodEightDescription = "Very few stations operate hydroponics modules driving the price and demand for fresh veggies through the roof leaving plenty of room for profit, assuming you can resist the urge to eat them yourself.";
    private float GoodEightBaseCost = 2000;
    private int GoodEightStackSize = 5;
    private float GoodEightWeight = 5f; // in Kg



    private float modifierOne;
    private float modifierTwo;
    private float modifierThree;
    private float modifierFour;
    private float modifierFive;
    private float modifierSix;
    private float modifierSeven;
    private float modifierEight;

    

    private void Awake()
    {
        _POC = FindObjectOfType<PlayerObject>();
        priceModifiers = new int[30];
        RandomizePrices();


        GoodOneBaseCost = Mathf.Round(GoodOneBaseCost * (1 -(priceModifiers[Random.Range(1,30)] * .01f)));
        GoodTwoBaseCost = Mathf.Round(GoodTwoBaseCost * (1 - (priceModifiers[Random.Range(1, 30)] * .01f)));
        GoodThreeBaseCost = Mathf.Round(GoodThreeBaseCost * (1 - (priceModifiers[Random.Range(1, 30)] * .01f)));
        GoodFourBaseCost = Mathf.Round(GoodFourBaseCost * (1 - (priceModifiers[Random.Range(1, 30)] * .01f)));
        GoodFiveBaseCost = Mathf.Round(GoodFiveBaseCost * (1 - (priceModifiers[Random.Range(1, 30)] * .01f)));
        GoodSixBaseCost = Mathf.Round(GoodSixBaseCost * (1 - (priceModifiers[Random.Range(1, 30)] * .01f)));
        GoodSevenBaseCost = Mathf.Round(GoodSevenBaseCost * (1 - (priceModifiers[Random.Range(1, 30)] * .01f)));
        GoodEightBaseCost = Mathf.Round(GoodEightBaseCost * (1 - (priceModifiers[Random.Range(1, 30)] * .01f)));

        GoodOneName.text = "Heavy Equipment";
        GoodOneDescription.text = goodOneDescription;
        GoodOneSingleGoodPrice.text = GoodOneBaseCost.ToString();
        GoodOneFiveGoodPrice.text = (GoodOneBaseCost * 5).ToString();
        GoodOneStackPrice.text = (GoodOneBaseCost * GoodOneStackSize).ToString();

        GoodTwoName.text = "Processed Meat";
        GoodTwoDescription.text = goodTwoDescription;
        GoodTwoSingleGoodPrice.text = GoodTwoBaseCost.ToString();
        GoodTwoFiveGoodPrice.text = (GoodTwoBaseCost * 5).ToString();
        GoodTwoStackPrice.text = (GoodTwoBaseCost * GoodTwoStackSize).ToString();

        GoodThreeName.text = "Alcohol";
        GoodThreeDescription.text = goodThreeDescription;
        GoodThreeSingleGoodPrice.text = GoodThreeBaseCost.ToString();
        GoodThreeFiveGoodPrice.text = (GoodThreeBaseCost * 5).ToString();
        GoodThreeStackPrice.text = (GoodThreeBaseCost * GoodThreeStackSize).ToString();

        GoodFourName.text = "Quantum Processor";
        GoodFourDescription.text = goodFourDescription;
        GoodFourSingleGoodPrice.text = GoodFourBaseCost.ToString();
        GoodFourFiveGoodPrice.text = (GoodFourBaseCost * 5).ToString();
        GoodFourStackPrice.text = (GoodFourBaseCost * GoodFourStackSize).ToString();

        GoodFiveName.text = "Spices";
        GoodFiveDescription.text = goodFiveDescription;
        GoodFiveSingleGoodPrice.text = GoodFiveBaseCost.ToString();
        GoodFiveFiveGoodPrice.text = (GoodFiveBaseCost * 5).ToString();
        GoodFiveStackPrice.text = (GoodFiveBaseCost * GoodFiveStackSize).ToString();

        GoodSixName.text = "Processed Ore";
        GoodSixDescription.text = goodSixDescription;
        GoodSixSingleGoodPrice.text = GoodSixBaseCost.ToString();
        GoodSixFiveGoodPrice.text = (GoodSixBaseCost * 5).ToString();
        GoodSixStackPrice.text = (GoodSixBaseCost * GoodSixStackSize).ToString();

        GoodSevenName.text = "Liquid Thorium";
        GoodSevenDescription.text = goodSevenDescription;
        GoodSevenSingleGoodPrice.text = GoodSevenBaseCost.ToString();
        GoodSevenFiveGoodPrice.text = (GoodSevenBaseCost * 5).ToString();
        GoodSevenStackPrice.text = (GoodSevenBaseCost * GoodSevenStackSize).ToString();

        GoodEightName.text = "Fresh Vegtable";
        GoodEightDescription.text = goodEightDescription;
        GoodEightSingleGoodPrice.text = GoodEightBaseCost.ToString();
        GoodEightFiveGoodPrice.text = (GoodEightBaseCost * 5).ToString();
        GoodEightStackPrice.text = (GoodEightBaseCost * GoodEightStackSize).ToString();
    }

    public void ActivateVendorWindow()
    {
        gameObject.SetActive(true);
    }
    public void DeactivateVendorWindow()
    {
        gameObject.SetActive(false);
    }

    public float GetPriceModifier()
    {
        return (priceModifiers[Random.Range(1, 30)] * .01f);
    }

    public void RandomizePrices()
    {
        

        for (int i = 0; i < 30; i++)
        {
            int randomInt = Random.Range(1, 100);

            if (randomInt >= 1 && randomInt <= 4)
            {
                priceModifiers[i] =(Random.Range(50, 60));
            }
            if (randomInt >= 5 && randomInt <= 10)
            {
                priceModifiers[i] = (Random.Range(25, 40));
            }
            if (randomInt >= 11 && randomInt <= 20)
            {
                priceModifiers[i] = (Random.Range(20, 25));
            }
            if (randomInt >= 21 && randomInt <= 45)
            {
                priceModifiers[i] = (Random.Range(15, 20));
            }
            if (randomInt >= 46 && randomInt <= 100)
            {
                priceModifiers[i] = (Random.Range(10, 15));
            }

        }

    }

    private void OnEnable()
    {
        _POC.OpenInventoryWindow();
        


    }

    private void OnDisable()
    {
        _POC.CloseInventoryWindow();
    }

    public void BuyOneGood(int goodNumber)
    {
        switch (goodNumber)
        {
            case 1:
                GoodOne = ScriptableObject.CreateInstance("Item") as Item;
               // GoodOne = ScriptableObject.CreateInstance("Reactor") as Reactor; //test
                GoodOne.InitializeItem(GoodOneSprite, ItemType.Commodity, "Heavy Water", false, goodOneDescription, GoodOneBaseCost, GoodOneWeight, "Common", true, GoodOneStackSize);
               // GoodOne.InitializeEquipment(4, 4, GoodOneSprite, "Reactor", "Dick Reactor", 19, true, "ballin'", 99); //test
                if (_POC.GetCurrentCredits() >= GoodOneBaseCost)
                {
                    _POC.AddToCurrentCredits(-GoodOneBaseCost);
                    playerInv.AddItem(GoodOne, 1);
                  //  playerInv.AddItem(GoodOne); test
                }
                break;
            case 2:
                GoodTwo = ScriptableObject.CreateInstance("Item") as Item;
                GoodTwo.InitializeItem(GoodTwoSprite, ItemType.Commodity, "Processed Meat", false, goodTwoDescription, GoodTwoBaseCost, GoodTwoWeight, "Common", true, GoodTwoStackSize);

                if (_POC.GetCurrentCredits() >= GoodTwoBaseCost)
                {
                    _POC.AddToCurrentCredits(-GoodTwoBaseCost);
                    playerInv.AddItem(GoodTwo, 1);
                }
                break;
            case 3:
                GoodThree = ScriptableObject.CreateInstance("Item") as Item;
                GoodThree.InitializeItem(GoodThreeSprite, ItemType.Commodity, "Alcohol", false, goodThreeDescription, GoodThreeBaseCost, GoodThreeWeight, "Common", true, GoodThreeStackSize);

                if (_POC.GetCurrentCredits() >= GoodThreeBaseCost)
                {
                    _POC.AddToCurrentCredits(-GoodThreeBaseCost);
                    playerInv.AddItem(GoodThree, 1);
                }
                
                break;
            case 4:
                GoodFour = ScriptableObject.CreateInstance("Item") as Item;
                GoodFour.InitializeItem(GoodFourSprite, ItemType.Commodity, "Quantum Processor", false, goodFourDescription, GoodFourBaseCost, GoodFourWeight, "Common", true, GoodFourStackSize);

                if (_POC.GetCurrentCredits() >= GoodFourBaseCost)
                {
                    _POC.AddToCurrentCredits(-GoodFourBaseCost);
                    playerInv.AddItem(GoodFour, 1);
                }
                
                break;
            case 5:
                GoodFive = ScriptableObject.CreateInstance("Item") as Item;
                GoodFive.InitializeItem(GoodFiveSprite, ItemType.Commodity, "Spices", false, goodFiveDescription, GoodFiveBaseCost, GoodFiveWeight, "Common", true, GoodFiveStackSize);

                if (_POC.GetCurrentCredits() >= GoodFiveBaseCost)
                {
                    _POC.AddToCurrentCredits(-GoodFiveBaseCost);
                    playerInv.AddItem(GoodFive, 1);
                }
                
                break;
            case 6:
                GoodSix = ScriptableObject.CreateInstance("Item") as Item;
                GoodSix.InitializeItem(GoodSixSprite, ItemType.Commodity, "Processed Ore", false, goodSixDescription, GoodSixBaseCost, GoodSixWeight, "Common", true, GoodSixStackSize);

                if (_POC.GetCurrentCredits() >= GoodSixBaseCost)
                {
                    _POC.AddToCurrentCredits(-GoodSixBaseCost);
                    playerInv.AddItem(GoodSix, 1);
                }
               
                break;
            case 7:
                GoodSeven = ScriptableObject.CreateInstance("Item") as Item;
                GoodSeven.InitializeItem(GoodSevenSprite, ItemType.Commodity, "Liquid Thorium", false, goodSevenDescription, GoodSevenBaseCost, GoodSevenWeight, "Common", true, GoodSevenStackSize);

                if (_POC.GetCurrentCredits() >= GoodSevenBaseCost)
                {
                    _POC.AddToCurrentCredits(-GoodSevenBaseCost);
                    playerInv.AddItem(GoodSeven, 1);
                }
                
                break;
            case 8:
                GoodEight = ScriptableObject.CreateInstance("Item") as Item;
                GoodEight.InitializeItem(GoodOneSprite, ItemType.Commodity, "Fresh Vegtable", false, goodEightDescription, GoodEightBaseCost, GoodEightWeight, "Common", true, GoodEightStackSize);

                if (_POC.GetCurrentCredits() >= GoodEightBaseCost)
                {
                    _POC.AddToCurrentCredits(-GoodEightBaseCost);
                    playerInv.AddItem(GoodEight, 1); ;
                }
                break;
        }

    }

    public void BuyFiveGoods(int goodNumber)
    {
        switch (goodNumber)
        {
            case 1:
                 GoodOne = ScriptableObject.CreateInstance("Item") as Item;
                // Shield cake = ScriptableObject.CreateInstance("Shield") as Shield;
                //cake.InitializeEquipment(34, 87, 4,GoodOneSprite, "Shield", "Dick Shield", 19, true, "YOLO", 66);
              GoodOne.InitializeItem(GoodOneSprite, ItemType.Commodity, "Heavy Water", false, goodOneDescription, GoodOneBaseCost, GoodOneWeight, "Common", true, GoodOneStackSize);

                if (_POC.GetCurrentCredits() >= GoodOneBaseCost * 5)
                {
                    _POC.AddToCurrentCredits(-GoodOneBaseCost * 5);
                    playerInv.AddItem(GoodOne, 5);
                   // playerInv.AddItem(cake);
                }
                break;
            case 2:
                GoodTwo = ScriptableObject.CreateInstance("Item") as Item;
                GoodTwo.InitializeItem(GoodTwoSprite, ItemType.Commodity, "Processed Meat", false, goodTwoDescription, GoodTwoBaseCost, GoodTwoWeight, "Common", true, GoodTwoStackSize);

                if (_POC.GetCurrentCredits() >= GoodTwoBaseCost * 5)
                {
                    _POC.AddToCurrentCredits(-GoodTwoBaseCost * 5);
                    playerInv.AddItem(GoodTwo, 5);
                }
                
                break;
            case 3:
                GoodThree = ScriptableObject.CreateInstance("Item") as Item;
                GoodThree.InitializeItem(GoodThreeSprite, ItemType.Commodity, "Alcohol", false, goodThreeDescription, GoodThreeBaseCost, GoodThreeWeight, "Common", true, GoodThreeStackSize);

                if (_POC.GetCurrentCredits() >= GoodThreeBaseCost * 5)
                {
                    _POC.AddToCurrentCredits(-GoodThreeBaseCost * 5);
                    playerInv.AddItem(GoodThree, 5);
                }
               
                break;
            case 4:
                GoodFour = ScriptableObject.CreateInstance("Item") as Item;
                GoodFour.InitializeItem(GoodFourSprite, ItemType.Commodity, "Quantum Processor", false, goodFourDescription, GoodFourBaseCost, GoodFourWeight, "Common", true, GoodFourStackSize);

                if (_POC.GetCurrentCredits() >= GoodFourBaseCost * 5)
                {
                    _POC.AddToCurrentCredits(-GoodFourBaseCost * 5);
                    playerInv.AddItem(GoodFour, 5);
                }
                
                break;
            case 5:
                GoodFive = ScriptableObject.CreateInstance("Item") as Item;
                GoodFive.InitializeItem(GoodFiveSprite, ItemType.Commodity, "Spices", false, goodFiveDescription, GoodFiveBaseCost, GoodFiveWeight, "Common", true, GoodFiveStackSize);

                if (_POC.GetCurrentCredits() >= GoodFiveBaseCost * 5)
                {
                    _POC.AddToCurrentCredits(-GoodFiveBaseCost * 5);
                    playerInv.AddItem(GoodFive, 5);
                }
                
                break;
            case 6:
                GoodSix = ScriptableObject.CreateInstance("Item") as Item;
                GoodSix.InitializeItem(GoodSixSprite, ItemType.Commodity, "Processed Ore", false, goodSixDescription, GoodSixBaseCost, GoodSixWeight, "Common", true, GoodSixStackSize);

                if (_POC.GetCurrentCredits() >= GoodSixBaseCost * 5)
                {
                    _POC.AddToCurrentCredits(-GoodSixBaseCost * 5);
                    playerInv.AddItem(GoodSix, 5);
                }
                
                break;
            case 7:
                GoodSeven = ScriptableObject.CreateInstance("Item") as Item;
                GoodSeven.InitializeItem(GoodSevenSprite, ItemType.Commodity, "Liquid Thorium", false, goodSevenDescription, GoodSevenBaseCost, GoodSevenWeight, "Common", true, GoodSevenStackSize);

                if (_POC.GetCurrentCredits() >= GoodSevenBaseCost * 5)
                {
                    _POC.AddToCurrentCredits(-GoodSevenBaseCost * 5);
                    playerInv.AddItem(GoodSeven, 5);
                }
                
                break;
            case 8:
                GoodEight = ScriptableObject.CreateInstance("Item") as Item;
                GoodEight.InitializeItem(GoodOneSprite, ItemType.Commodity, "Fresh Vegtable", false, goodEightDescription, GoodEightBaseCost, GoodEightWeight, "Common", true, GoodEightStackSize);

                if (_POC.GetCurrentCredits() >= GoodEightStackSize * 5)
                {
                    _POC.AddToCurrentCredits(-GoodEightStackSize * 5);
                    playerInv.AddItem(GoodEight, 5);
                }
                
                break;
        }

    }

    

    public void BuyStackGoods(int goodNumber)
    {
        switch (goodNumber)
        {
            case 1:
            GoodOne = ScriptableObject.CreateInstance("Item") as Item;
                GoodOne.InitializeItem(GoodOneSprite, ItemType.Commodity, "Heavy Water",  false, goodOneDescription, GoodOneBaseCost, GoodOneWeight, "Common", true, GoodOneStackSize);

                if (_POC.GetCurrentCredits() >= GoodOneBaseCost * GoodOneStackSize)
                {
                    _POC.AddToCurrentCredits(-GoodOneBaseCost * GoodOneStackSize);
                    playerInv.AddItem(GoodOne, GoodOneStackSize);
                }
                
                break;
            case 2:
                GoodTwo = ScriptableObject.CreateInstance("Item") as Item;
                GoodTwo.InitializeItem(GoodTwoSprite, ItemType.Commodity, "Processed Meat", false, goodTwoDescription, GoodTwoBaseCost, GoodTwoWeight, "Common", true, GoodTwoStackSize);

                if (_POC.GetCurrentCredits() >= GoodTwoBaseCost * GoodTwoStackSize)
                {
                    _POC.AddToCurrentCredits(-GoodTwoBaseCost * GoodTwoStackSize);
                    playerInv.AddItem(GoodTwo, GoodTwoStackSize);
                }
                
                break;
            case 3:
                GoodThree = ScriptableObject.CreateInstance("Item") as Item;
                GoodThree.InitializeItem(GoodThreeSprite, ItemType.Commodity, "Alcohol", false, goodThreeDescription, GoodThreeBaseCost, GoodThreeWeight, "Common", true, GoodThreeStackSize);

                if (_POC.GetCurrentCredits() >= GoodThreeBaseCost * GoodThreeStackSize)
                {
                    _POC.AddToCurrentCredits(-GoodThreeBaseCost * GoodThreeStackSize);
                    playerInv.AddItem(GoodThree, GoodThreeStackSize);
                }            
                break;
            case 4:
                GoodFour = ScriptableObject.CreateInstance("Item") as Item;
                GoodFour.InitializeItem(GoodFourSprite, ItemType.Commodity, "Quantum Processor", false, goodFourDescription, GoodFourBaseCost, GoodFourWeight, "Common", true, GoodFourStackSize);

                if (_POC.GetCurrentCredits() >= GoodFourBaseCost * GoodFourStackSize)
                {
                    _POC.AddToCurrentCredits(-GoodFourBaseCost * GoodFourStackSize);
                    playerInv.AddItem(GoodFour, GoodFourStackSize);
                }
                break;
            case 5:
                GoodFive = ScriptableObject.CreateInstance("Item") as Item;
                GoodFive.InitializeItem(GoodFiveSprite, ItemType.Commodity, "Spices", false, goodFiveDescription, GoodFiveBaseCost, GoodFiveWeight, "Common", true, GoodFiveStackSize);

                if (_POC.GetCurrentCredits() >= GoodFiveBaseCost * GoodFiveStackSize)
                {
                    _POC.AddToCurrentCredits(-GoodFiveBaseCost * GoodFiveStackSize);
                    playerInv.AddItem(GoodFive, GoodFiveStackSize);
                }
                break;
            case 6:
                GoodSix = ScriptableObject.CreateInstance("Item") as Item;
                GoodSix.InitializeItem(GoodSixSprite, ItemType.Commodity, "Processed Ore", false, goodSixDescription, GoodSixBaseCost, GoodSixWeight, "Common", true, GoodSixStackSize);

                if (_POC.GetCurrentCredits() >= GoodSixBaseCost * GoodSixStackSize)
                {
                    _POC.AddToCurrentCredits(-GoodSixBaseCost * GoodSixStackSize);
                    playerInv.AddItem(GoodSix, GoodSixStackSize);
                }
                break;
            case 7:
                GoodSeven = ScriptableObject.CreateInstance("Item") as Item;
                GoodSeven.InitializeItem(GoodSevenSprite, ItemType.Commodity, "Liquid Thorium", false, goodSevenDescription, GoodSevenBaseCost, GoodSevenWeight, "Common", true, GoodSevenStackSize);

                if (_POC.GetCurrentCredits() >= GoodSevenBaseCost * GoodSevenStackSize)
                {
                    _POC.AddToCurrentCredits(-GoodSevenBaseCost * GoodSevenStackSize);
                    playerInv.AddItem(GoodSeven, GoodSevenStackSize);
                }
                break;
            case 8:
                GoodEight = ScriptableObject.CreateInstance("Item") as Item;
                GoodEight.InitializeItem(GoodOneSprite, ItemType.Commodity, "Fresh Vegtable",  false, goodEightDescription, GoodEightBaseCost, GoodEightWeight, "Common", true, GoodEightStackSize);

                if (_POC.GetCurrentCredits() >= GoodEightBaseCost * GoodEightStackSize)
                {
                    _POC.AddToCurrentCredits(-GoodEightBaseCost * GoodEightStackSize);
                    playerInv.AddItem(GoodEight, GoodEightStackSize);
                }
                break;
        }

    }

    
   

  

    

    

}