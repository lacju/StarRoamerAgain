using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class StationHandler : MonoBehaviour {

    public Text pressKeyToDock;
    [Header("Name of the station")]
    public string stationName;
   // [Header("Not implimented")]
   // public bool randomStationName;
    [Header("Description of the station ")]
    public string stationInfo; //eventually randomize on game start
    [Header("Has an equipment vendor")]
    public bool hasEquipmentVendor;
    [Header("Vendor's name")]
    public string vendorName;
 //   [Header("Not implimented")]
  //  public bool randomVendorName;
    [Header("Vendor description")]
    public string vendorDescription;
   // [Header("Not implimented")]
    //public bool randomVendorDescription;
    [Header("Cantina name")]
    public string cantinaName;
   // [Header("Not implimented")]
   // public bool randomCantinaName;
    [Header("Cantina description")]
    public string cantinaDescription;
 //   [Header("Not implimented")]
  //  public bool randomCantinaDescription;
    [Header("Has shipyard")]
    public bool hasShipyard;
    [Header("Shipyard name")]
    public string shipyardName;
  //  [Header("Not implimented")]
  //  public bool randomShipyardName;
    [Header("Shipyard description")]
    public string shipyardDescription;
 //   [Header("Not implimented")]
 //   public bool randomShipyardDescription;
    private PlayerObject _POC;
    public GameObject goodsVendingScreen;
    public GameObject equipmentVendingScreen;
    public GameObject mainMenu;
    public GameObject payerInvScreen;

    public int rewiredPlayerId = 0;
    private Player rewiredPlayer;


    private void Awake()
    {
        rewiredPlayer = ReInput.players.GetPlayer(rewiredPlayerId);
    }

    private void Update()
    {
        if (rewiredPlayer.GetButtonDown("ExitMenu"))
        {
            StationHandler sh = this;
            Debug.Log("U ket pressed");
            Time.timeScale = 1;
            sh.enabled = false;
        }
    }

    private void OnEnable()
    {
        _POC = FindObjectOfType<PlayerObject>();
        ShowMainMenu();
        gameObject.BroadcastMessage("SetStationName", stationName);
        gameObject.BroadcastMessage("ChangeVendorTitle", vendorName);
        GameObject.Find("CantinaTitle").GetComponent<Text>().text = cantinaName;
        GameObject.Find("CantinaDescription").GetComponent<Text>().text = cantinaDescription;
        GameObject.Find("ShipyardTitle").GetComponent<Text>().text = shipyardName;
        GameObject.Find("ShipyardDescription").GetComponent<Text>().text = shipyardDescription;
        GameObject.Find("VendorName").GetComponent<Text>().text = vendorName;
        GameObject.Find("VendorDescription").GetComponent<Text>().text = vendorDescription;
        GameObject.Find("StationInfoText").GetComponent<Text>().text = stationInfo;
        rewiredPlayer = ReInput.players.GetPlayer(rewiredPlayerId);
    }

    private void OnDisable()
    {
        HideMainMenu();
    }

    public void ShowPlayerInventory()
    {

        payerInvScreen.SetActive(true);
    }

    public void HidePlayerInventory()
    {

        payerInvScreen.SetActive(false);
    }

    public void ShowGoodsVendorWindow()
    {

        goodsVendingScreen.SetActive(true);
    }

    public void HideGoodsVendorWindow()
    {

        goodsVendingScreen.SetActive(false);
    }

    public void ShowEquipmentVendorWindow()
    {

        equipmentVendingScreen.SetActive(true);
    }

    public void HideEquipmentVendorWindow()
    {

        equipmentVendingScreen.SetActive(false);
    }

    public void ShowMainMenu()
    {

        mainMenu.SetActive(true);
    }

    public void HideMainMenu()
    {

        mainMenu.SetActive(false);
    }
  
}
