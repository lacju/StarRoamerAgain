using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour {

    private Dictionary<Image, Item> Inventory = new Dictionary<Image, Item>(numItemSlots);

    public const int numItemSlots = 36;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
