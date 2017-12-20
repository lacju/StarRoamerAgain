using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    public Canvas inventoryCanvas;



    public void NewGameBrtn(string newGameLevel)
    {
        //inventoryCanvas = new GameObject("Player Inventory").AddComponent<Canvas>();
        //inventoryCanvas = (Canvas)Resources.Load("PlayerInventory");

        
        
       // Instantiate(Inventory.Instance);
       // Instantiate
      //  GameManager.Instance.PopulateStarterEquipment();

        SceneManager.LoadScene(newGameLevel);
    }
}
