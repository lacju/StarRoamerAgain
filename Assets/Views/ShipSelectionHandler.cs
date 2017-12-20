using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipSelectionHandler : MonoBehaviour {

    public List<Hull> hullPool;
    public bool vendorScreen;
    public Text type;
    public Text shipClass;
    public Text cargoCapacity;
    public Text maxSpeed;
    public Text turnSpeed;
    public Text turretSlots;
    public Text weaponSlots;
    public Text shipPersonalName;
    public Hull hullSelected;
    public GameObject boarModel;
    public GameObject muleModel;
    public VitalsHandler vitals;
    public GameObject menuBar;
    public PlayerObject _POC;

    

    private void Awake()
    {
        if (vendorScreen)
        {
            for (int i = 0; i < 6; i++)
            {
                hullPool.Add(GameManager.Instance.GetRandomHull(false));
            }
        }

        hullSelected = GameManager.Instance.GetHullOfType("Mule");
        muleModel.SetActive(true);

        
        _POC = FindObjectOfType<PlayerObject>();
        vitals = FindObjectOfType<VitalsHandler>();
    }

    private void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update () {

        type.text = hullSelected.GetModel();
        shipClass.text = hullSelected.GetShipClass().ToString();
        cargoCapacity.text = hullSelected.GetCargoCapacity().ToString();
        maxSpeed.text = hullSelected.GetMaxSpeed().ToString();
        turnSpeed.text = hullSelected.GetTurnSpeed().ToString();
        turretSlots.text = hullSelected.GetTurretSlots().ToString();
        weaponSlots.text = hullSelected.GetWeaponSlot().ToString();
		
	}

    public void FreighterClick()
    {
        hullSelected = GameManager.Instance.GetHullOfType("Mule");
        boarModel.SetActive(false);
        muleModel.SetActive(true);
    }
    public void FighterClick()
    {
        hullSelected = GameManager.Instance.GetHullOfType("Boar");
        muleModel.SetActive(false);
        boarModel.SetActive(true);
    }
    public void StartGame(string scene)
    {
        hullSelected.shipPersonalName = shipPersonalName.text;
        _POC.EquipHull(hullSelected);
        GameManager.Instance.playerShip = hullSelected;
        _POC.GetPlayerSkillsFromGameManager();
        GameManager.Instance.vitalsBar.SetActive(true);
        GameManager.Instance.menuBar.SetActive(true);
        GameManager.Instance.cameraZoom.SetActive(true);
        _POC.MovePlayerToLocation(GameManager.Instance.playerStartingLocationFirstScene);
        SceneManager.LoadScene(scene);
    }
}
