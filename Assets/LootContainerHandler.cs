using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerHandler : MonoBehaviour {

    public List<Item> lootTable;
    EquipmentGenerator eg;
    PlayerObject playerObject;
    public float numberOfLootItems;
    // Use this for initialization
    private void Awake()
    {
        lootTable = new List<Item>();
        eg = FindObjectOfType<EquipmentGenerator>();
        playerObject = FindObjectOfType<PlayerObject>();
    }
    void Start () {
        for (int i = 0; i < 20; i++)
        {
            lootTable.Add(eg.RandomlyGenerateEquipment());
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerObject")
        {
            Debug.Log("trigger detected");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerObject")
        {
            Debug.Log("collision detected");

            AddLootToplayerInventory();
        }
    }

    private void AddLootToplayerInventory()
    {
        for (int i = 0; i < numberOfLootItems; i++)
        {
            playerObject.AddItemToInventory(lootTable[Random.Range(0, lootTable.Count)]);
        }
        Destroy(gameObject);
    }
}
