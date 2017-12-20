using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBarButtonHandler : MonoBehaviour {

    public GameObject playerInvObject;
    public GameObject playerEquipmentMenuObject;
    public GameObject playerJournalWindowObject;

    public InventoryWindowHandler playerInvWindowHandler;
    public GameObject playerEquipMenuWindow;
    public GameObject playerJournalWindow;


    public void TogglePlayerInventory()
    {
        
            playerInvWindowHandler.ToggleInventoryWindow();
        
       // playerInvWindow.transform.position = new Vector3(-452, 0, 0);
    }

    public void ToggleEquipmentMenu()
    {
        if (playerEquipmentMenuObject.activeInHierarchy)
        {
            playerEquipmentMenuObject.SetActive(false);
        }
        else
        {
            playerEquipmentMenuObject.SetActive(true);
        }
       // playerEquipMenuWindow.transform.position = new Vector3(225, 0, 0);
    }

    public void TogglePlayerJournal()
    {
        if (playerJournalWindowObject.activeInHierarchy)
        {
            playerJournalWindowObject.SetActive(false);
        }
        else
        {
            playerJournalWindowObject.SetActive(true);
        }
    }

}
