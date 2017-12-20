using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
	//Public
	public bool
		drawOnObject, //If true, the tooltip will be drawn over an object instead of a GUI rectangle
		followMouse; //Follow the mouse or just stay over the item
	//public Rect guiItemRect; //The rectangle on which the tooltip will be drawn
	public Transform objectTransform; //The object over which the tooltip will be drawn

    private Inventory playerInventory;
    private TooltipHandlerEquipment tthe;
    private bool mouseClick = false;


    public Vector2  tooltipOffset = new Vector2 (10, 20); //Tooltip is drawn at the bottom right edge of the guiItemRect + this (tooltipOffset)
	
	public bool
		useMultipleFonts = false,
		useMultipleFontStyles = false;
	
	public Font font; //Takes effect only if useMultipleFonts is true
	public FontStyle fontStyle; //Takes effect only if useMultipleFontStyles is true

    public int
        fontSize = 16,
        spacing = 5, //The spacing between lines
        SpaceBetweenLinesLeft = 5,
        YPosFirstLineLeft = 5,
        YPosSecondLineLeft = 5,
        YPosThirdLineLeft = 5,
        YPosFourthLineLeft = 5,
        YPosFifthLineLeft = 5,
        YPosSixthLineLeft = 5,
        YPosSeventhLineLeft = 5,
        YPosEightLineLeft = 5,
        XSpacingLeft = 5,
        YSpacingLeft = 5,
        XSpacingRight = 5,
        YSpacingRight = 5,
		windowWidth = 200,
        windowHeight = 200,
        YPosFirstLineRight,
        YPosSecondLineRight,
        YPosThirdLineRight,
        YPosFourthLineRight,
    windowID; //Make sure this doesn't match any of your existing window IDs

    private int SecondLineOnLeft;
    private int invSlot;
    private TooltipHandlerEquipment tooltipHandler;
    private PlayerObject _POC;
    private Item tempItemHolder;
	
	//A guiStyle used for the tooltip background (Texture under Normal and Border are the only things that matter)
	public GUIStyle backgroundGUIStyle;
	
	//Left and right side text lists
	public List<TooltipProperties> leftSideText = new List<TooltipProperties>();
	public List<TooltipRightSideProperties> rightSideText = new List<TooltipRightSideProperties>();
	
	//Private
	private bool drawTooltip = false; //Tooltip draw control
	private Rect windowRect = new Rect (); //The rect for the window
    public void SetInvSlot(int invslot)
    {
        invSlot = invslot; 
    }

    private bool CheckForEquipment()
    {
        switch (tthe.EquipmentSlot)
        {
            case EquipmentType.Engine:
                tempItemHolder = _POC.hull.equippedEngine;
                if (_POC.hull.equippedEngine != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case EquipmentType.Armor:
                tempItemHolder = _POC.hull.equippedArmor;
                if (_POC.hull.equippedArmor != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case EquipmentType.Shield:
                tempItemHolder = _POC.hull.equippedShields;
                if (_POC.hull.equippedShields != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case EquipmentType.Reactor:
                tempItemHolder = _POC.hull.equippedReactor;
                if (_POC.hull.equippedReactor != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case EquipmentType.Weapon0:
                tempItemHolder = _POC.hull.equippedWeapon0;
                if (_POC.hull.equippedWeapon0 != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case EquipmentType.Weapon1:
                tempItemHolder = _POC.hull.equippedWeapon1;
                if (_POC.hull.equippedWeapon1 != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }
        return false;
    }

    

    private void Awake()
    {
        // guiItemRect.x = itemIcon.transform.localPosition.x;
        // guiItemRect.x = itemIcon.transform.localPosition.y;
        playerInventory = FindObjectOfType<Inventory>();
        tooltipHandler = transform.GetComponent<TooltipHandlerEquipment>();
        tthe = gameObject.GetComponent<TooltipHandlerEquipment>();
        _POC = FindObjectOfType<PlayerObject>();
    }

    //Update
    void Update ()
	{
     //Define mouse position
        Vector2 mousePosition = new Vector2 (Input.mousePosition.x, Screen.height - Input.mousePosition.y);
		
		if (drawOnObject)
		{
			MouseOnObject mouseOnObjectScript = gameObject.GetComponent<MouseOnObject>();
			
			if (mouseOnObjectScript == null) //If the MouseOnObject script isn't found, display a warning and attach a temporary one
			{
				Debug.LogWarning ("The MouseOnObject script is not assigned to the object you're trying to access it from (objectTransform) so this script added one to the object. To avoid this warning in the future, assign it to the object in Scene view.");
				gameObject.AddComponent <MouseOnObject> ();
			}
			else if (!mouseOnObjectScript.enabled) //If the MouseOnObject script isn't enabled, display a warning
			{
				Debug.LogWarning ("The MouseOnObject script is not enabled on the object so it has been enabled in runtime. To avoid this warning in the future, enable the script in Scene view.");
				mouseOnObjectScript.enabled = true;
			}
			
			//If mouse is over the object
			if ((mouseOnObjectScript.mouseOnObject && playerInventory.items[invSlot] != null) || (mouseOnObjectScript.mouseOnObject && CheckForEquipment()))
			{
            


                    drawTooltip = true; //Draw the tooltip
                    if (Input.GetMouseButtonDown(0))
                    {
                        mouseClick = true;

                    }

                    if (followMouse) //if followMouse is true
                    {
                        //Draw the tooltip on the mouse + tooltipOffset
                        windowRect.x = mousePosition.x + tooltipOffset.x;
                        windowRect.y = mousePosition.y + tooltipOffset.y;
                    }
                    else //else if followMouse is false
                    {
                        Vector3 screenPosition = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().WorldToScreenPoint(objectTransform.position);

                        windowRect.x = screenPosition.x + tooltipOffset.x;
                        windowRect.y = Screen.height - screenPosition.y + tooltipOffset.y;
                    }
                
			}
			else //if mouse isn't over the object
				drawTooltip = false; //Hide the tooltip
           
		}
		//else
		//{
		//	//If mouse is over the gui item
		//	if (guiItemRect.Contains (mousePosition))
		//	{
  //              Debug.Log("Mouse in guirect");
  //              if (tooltipHandler.item != null)
  //              {

  //                  drawTooltip = true; //Draw the tooltip

  //                  if (followMouse) //if followMouse is true
  //                  {
  //                      //Draw the tooltip on the mouse + tooltipOffset
  //                      windowRect.x = mousePosition.x + tooltipOffset.x;
  //                      windowRect.y = mousePosition.y + tooltipOffset.y;
  //                  }
  //                  else //else if followMouse is false
  //                  {
  //                      //Draw the tooltip at the bottom right edge of the gui item + tooltipOffset
  //                      windowRect.x = guiItemRect.width + tooltipOffset.x;
  //                      windowRect.y = guiItemRect.height + tooltipOffset.y;
  //                  }
  //              }
		//	}
		//	else //if mouse isn't over the gui item
		//		drawTooltip = false; //Hide the tooltip
		//}
		
		//Constrain tooltip to the screen
		if (windowRect.x + windowRect.width > Screen.width)
			windowRect.x = Screen.width - windowRect.width;
		
		if (windowRect.y + windowRect.height > Screen.height)
			windowRect.y = Screen.height - windowRect.height;
	}

    //private void DrawItemIconDrag()
    //{
    //    Vector2 mousePosition = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
    //    itemIconRect.x = mousePosition.x + tooltipOffset.x;
    //    itemIconRect.y = mousePosition.y + tooltipOffset.y;
    //    GUI.DrawTexture(itemIconRect, playerInventory.items[tthe.inventorySlotNumber].sprite.texture);
    //}
	
	//On GUI
	void OnGUI ()
	{
        //if (mouseClick)
        //{
        //    DrawItemIconDrag();
        //}

        //If fontSize is 0 or less, put it to 16
        if (fontSize <= 0)
			fontSize = 16;
		
		//Set width and height
		windowRect.width = windowWidth;
        if (windowHeight == 0)
        {
            windowRect.height = leftSideText.Count * fontSize + leftSideText.Count * spacing + spacing * 2;
        }
        else
        {
            windowRect.height = windowHeight;
        }
		
		
		//if drawTooltip is true, draw the tooltip window using the TooltipWindow function
		if (drawTooltip)
			GUI.Window (windowID, windowRect, TooltipWindow, GUIContent.none, backgroundGUIStyle);
        

        GUI.Box(new Rect((Screen.width / 2) - 140, 5, 280, 25), "Mouse Position = " + Input.mousePosition);
        GUI.Box(new Rect((Screen.width / 2) - 70, Screen.height - 30, 140, 25), "Mouse X = " + Input.mousePosition.x);
        GUI.Box(new Rect(5, (Screen.height / 2) - 12, 140, 25), "Mouse Y = " + Input.mousePosition.y);
    }
	
	//A function to draw the window
	void TooltipWindow (int windowIndex)
	{
		//Loops through the left side line list
		for (int i = 0; i < leftSideText.Count; i++)
		{
				//If color alpha is 0, put it to 1 (max)
				if (leftSideText[i].color.a <= 0)
					leftSideText[i].color.a = 1;
				
				//GUI Style to be set according to the properties
				GUIStyle guiStyle = new GUIStyle(); 
				
				//Set default style properties
				guiStyle.fontStyle = FontStyle.Normal;
				guiStyle.alignment = TextAnchor.UpperLeft;
				
				/*Set line attributes according to the properties*/
				//Font
				if (useMultipleFonts)
					guiStyle.font = leftSideText[i].font;
				else
					guiStyle.font = font;
				
				//Font Style
				if (useMultipleFontStyles)
					guiStyle.fontStyle = leftSideText[i].fontStyle;
				else
					guiStyle.fontStyle = fontStyle;
					
				guiStyle.fontSize = fontSize; //Font size
				guiStyle.normal.textColor = leftSideText[i].color; //Left side color
                                                                   /**/

            guiStyle.wordWrap = true;

            //Render the left side text (if drawTooltip is true)
            if (i == 0)
            {
                GUI.Label(new Rect(XSpacingLeft, YPosFirstLineLeft, windowRect.width, fontSize), leftSideText[i].text, guiStyle);
            }
            if (i == 1)
            {
                GUI.Label(new Rect(XSpacingLeft, YPosSecondLineLeft + fontSize, windowRect.width, fontSize), leftSideText[i].text, guiStyle);
            }
            if (i == 2)
            {
                GUI.Label(new Rect(XSpacingLeft, YPosThirdLineLeft + fontSize, windowRect.width, fontSize), leftSideText[i].text, guiStyle);
            }
            if (i == 3)
            {
                GUI.Label(new Rect(XSpacingLeft, YPosFourthLineLeft + fontSize, windowRect.width, fontSize), leftSideText[i].text, guiStyle);
            }
            if (i == 4)
            {
                GUI.Label(new Rect(XSpacingLeft, YPosFifthLineLeft + fontSize, windowRect.width, fontSize), leftSideText[i].text, guiStyle);
            }
            if (i == 5)
            {
                GUI.Label(new Rect(XSpacingLeft, YPosSixthLineLeft + fontSize, windowRect.width, fontSize), leftSideText[i].text, guiStyle);
            }
            if (i == 6)
            {
                GUI.Label(new Rect(XSpacingLeft, YPosSeventhLineLeft + fontSize, windowRect.width, fontSize), leftSideText[i].text, guiStyle);
            }
            if (i == 7)
            {
                GUI.Label(new Rect(XSpacingLeft, YPosEightLineLeft + fontSize, windowRect.width, fontSize), leftSideText[i].text, guiStyle);
            }

            //if (i == 1)
            //{
            //    SecondLineOnLeft = YPosFirstLineLeft;
            //    SecondLineOnLeft = SecondLineOnLeft + SpaceBetweenLinesLeft;
            //    // GUI.Label(new Rect(XSpacingLeft, YSpacingLeft + i * fontSize + i * YSpacingLeft, windowRect.width, fontSize), leftSideText[i].text, guiStyle);
            //    GUI.Label(new Rect(XSpacingLeft, SecondLineOnLeft + i * fontSize + i, windowRect.width, fontSize), leftSideText[i].text, guiStyle);
            //}
            //else
            //{

            //    SecondLineOnLeft = YPosFirstLineLeft;
            //    SecondLineOnLeft = SecondLineOnLeft + SpaceBetweenLinesLeft;
            //    // GUI.Label(new Rect(XSpacingLeft, YSpacingLeft + i * fontSize + i * YSpacingLeft, windowRect.width, fontSize), leftSideText[i].text, guiStyle);
            //     GUI.Label(new Rect(XSpacingLeft, SecondLineOnLeft + i * fontSize + i , windowRect.width, fontSize), leftSideText[i].text, guiStyle);
            //}
        }
		//Loops through the right side line list
		for (int a = 0; a < rightSideText.Count; a++)
		{
			//Constrain right side line number so there's no out of range errors
			if (rightSideText[a].line <= 1)
				rightSideText[a].line = 1;
			else if (rightSideText[a].line >= leftSideText.Count)
				rightSideText[a].line = leftSideText.Count;
			
			//If color alpha is 0, put it to 1 (max)
			if (rightSideText[a].color.a <= 0)
					rightSideText[a].color.a = 1;
			
			//GUI Style to be set according to the properties
			GUIStyle guiStyleRight = new GUIStyle(); 
			
			//Set default style properties
			guiStyleRight.fontStyle = FontStyle.Normal;
			guiStyleRight.alignment = TextAnchor.UpperLeft;
			
			/*Set line attributes according to the properties*/
			//Font
			if (useMultipleFonts)
				guiStyleRight.font = rightSideText[a].font;
			else
				guiStyleRight.font = font;
						
			//Font Style
			if (useMultipleFontStyles)
				guiStyleRight.fontStyle = rightSideText[a].fontStyle;
			else
				guiStyleRight.fontStyle = fontStyle;
							
			guiStyleRight.fontSize = fontSize; //Font size
			guiStyleRight.normal.textColor = rightSideText[a].color; //Right side color
                                                                     /**/

            guiStyleRight.wordWrap = true;

            //If right side text list isn't empty and drawTooltip is true, render the right side text
            if (rightSideText.Count != 0)

            //GUI.Label (new Rect (windowWidth - rightSideText[a].text.Length * fontSize / 2 - XSpacingRight * 2, spacing + (rightSideText[a].line - 1) * fontSize + (rightSideText[a].line - 1) * YSpacingRight, windowRect.width, fontSize), rightSideText[a].text, guiStyleRight); 

            if (a == 0)
            {
                GUI.Label(new Rect(windowWidth - rightSideText[a].text.Length * fontSize / 2 - XSpacingRight * 2, YPosFirstLineRight + fontSize, windowRect.width, fontSize), rightSideText[a].text, guiStyleRight); 
            }
            if (a == 1)
            {
                GUI.Label(new Rect(windowWidth - rightSideText[a].text.Length * fontSize / 2 - XSpacingRight * 2, YPosSecondLineRight + fontSize, windowRect.width, fontSize), rightSideText[a].text, guiStyleRight); 
            }
            if (a == 2)
            {
                GUI.Label(new Rect(windowWidth - rightSideText[a].text.Length * fontSize / 2 - XSpacingRight * 2, YPosThirdLineRight + fontSize, windowRect.width, fontSize), rightSideText[a].text, guiStyleRight); 
            }
            if (a == 3)
            {
                GUI.Label(new Rect(windowWidth - rightSideText[a].text.Length * fontSize / 2 - XSpacingRight * 2, YPosFourthLineRight + fontSize, windowRect.width, fontSize), rightSideText[a].text, guiStyleRight); 
            }
            
}

      
    }
    
}