/*
Changes the shield shape in the demo.
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChangeShieldShape : MonoBehaviour {

	//list of shields
	public List<GameObject> Shields = new List<GameObject>();

	//the index of the current shield
	public int index = 0;

	//the text to be displayed on the button
	public Text ShapeText;

	//on Awake
	//make sure only one sheild is showing and update the text
	void Awake()
	{
		int i = 0;
		foreach(GameObject s in Shields)
		{
			if (i == index)
			{
				Shields[i].SetActive(true);
			}
			else
			{
				Shields[i].SetActive(false);
			}

			i++;
		}

		UpdateText();
	}

	//when the button is pressed, changed the shield, and update the text
	public void Press()
	{
		Shields[index].SetActive(false);

		index ++;
		index = index % Shields.Count;

		Shields[index].SetActive(true);

		UpdateText();

	}

	//method used to update the text
	void UpdateText()
	{
		if (index == 0)
		{
			ShapeText.text = "Shape: Sphere";
		}
		else if (index == 1)
		{
			ShapeText.text = "Shape: Object";
		}
		else if (index == 2)
		{
			ShapeText.text = "Shape: Capsule";
		}
		else if (index == 3)
		{
			ShapeText.text = "Shape: Icosphere";
		}
	}

}
