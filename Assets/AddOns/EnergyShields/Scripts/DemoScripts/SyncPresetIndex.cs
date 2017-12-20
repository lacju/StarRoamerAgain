using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SyncPresetIndex : MonoBehaviour 
{

	public List<EnergyShieldManager> ESMs = new List<EnergyShieldManager>();
	public int presetIndex = 0;

	public Text presetText ;

	//allows the user to change the preset that will be used
	public void ChangePreset()
	{
		presetIndex ++;
		presetIndex = presetIndex % 3;

		foreach(EnergyShieldManager ESM in ESMs)
		{
			ESM.presetIndex = presetIndex;
		}

		presetText.text = "Effect: " + presetIndex.ToString();
	}

	// Use this for initialization
	void Awake () 
	{
		foreach(EnergyShieldManager ESM in ESMs)
		{
			ESM.presetIndex = presetIndex;
		}

		presetText.text = "Effect: " + presetIndex.ToString();
	}
	

}
