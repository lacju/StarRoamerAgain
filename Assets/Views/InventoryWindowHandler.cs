using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindowHandler : MonoBehaviour {

    public Text playerCredits;
    public Text cargoWeight;

    public Image Background;
    public GameObject InventoryUIItems;

    private PlayerObject _POC;

    public void ToggleInventoryWindow()
    {
        if (Background.isActiveAndEnabled && InventoryUIItems.activeSelf)
        {
            Background.enabled = (false);
            InventoryUIItems.SetActive(false);
        }
        else
        {
            Background.enabled = (true);
            InventoryUIItems.SetActive(true);
        }
    }

    private void Awake()
    {
        _POC = FindObjectOfType<PlayerObject>();
    }

    private void Update()
    {
        playerCredits.text = _POC.GetCurrentCredits().ToString();
        cargoWeight.text = _POC.GetCurrentCargoWeight().ToString();
    }

}
