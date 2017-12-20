//This is an example class that shows you the possibility of simply integrating the tooltip into your own script
//It should only be used as a reference because it has no relevance to the whole tooltip project
//Just create a reference to the tooltip script (tooltipScript) then modify stuff and add lines of text 
//This class mimics an rpg inventory item

using UnityEngine;
using System.Collections;

public class ExampleItemClass : MonoBehaviour
{
	//Example variables (mimicking an rpg inventory item)
	public string
		itemName,
		type,
		slot;
	
	public int
		damage,
		strengthBonus,
		staminaBonus;
	
	public Font font;
	public FontStyle fontStyle;
	
	public Color
		defaultColor,
		rarityColor,
		bonusColor;
	
	public Rect windowRect = new Rect (5, 5, 64, 64); //Sword icon rectangle
	public Texture2D itemIcon; //Sword icon
	
	//Reference to the tooltip script
	private Tooltip tooltipScript;
	
	//On Start
	void Start ()
	{
		tooltipScript = transform.GetComponent<Tooltip>() as Tooltip; //Get the tooltip script
		
	//	tooltipScript.guiItemRect = windowRect; //Set the mouse recognation rect in the tooltip script to windowRect (sword icon rectangle)
		
		//Adds 5 lines to the left side (text, font, fontStyle, color)
		//tooltipScript.leftSideText.Add (new TooltipProperties (itemName, font, fontStyle, rarityColor));
		//tooltipScript.leftSideText.Add (new TooltipProperties (type, font, fontStyle, defaultColor));
		//tooltipScript.leftSideText.Add (new TooltipProperties ("Damage: " + damage, font, fontStyle, defaultColor));
		//tooltipScript.leftSideText.Add (new TooltipProperties ("+" + strengthBonus + " Strength", font, fontStyle, bonusColor));
		//tooltipScript.leftSideText.Add (new TooltipProperties ("+" + staminaBonus + " Stamina", font, fontStyle, bonusColor));
		
		//Adds 1 line to the right side (text, font, fontStyle, color, line)
		tooltipScript.rightSideText.Add (new TooltipRightSideProperties (slot, font, fontStyle, defaultColor, 2));
	}
	
	//On GUI
	void OnGUI ()
	{
		GUI.DrawTexture (windowRect, itemIcon); //Draw the sword icon
	}
}