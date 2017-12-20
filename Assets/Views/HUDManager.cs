using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;


public class HUDManager : MonoBehaviour {

    private PlayerObject _POC;

    public Image shieldBar;
    public Text shieldNumber;
    public Image hullBar;
    public Text hullNumber;
    public Image energyBar;
    public Text energyNumber;


    private void Awake()
    {
        _POC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerObject>();
    }

    private void Update()
    {
        UpdateHUDVitals();
    }

    void UpdateHUDVitals()
    {


        //shield values
        if ((_POC.GetMaxShields() < 1))
        {
            shieldBar.fillAmount = 0;
            shieldNumber.text = "0";
        }
        else
        {
            shieldBar.fillAmount = _POC.GetCurrentShieldPoints() / _POC.GetMaxShields();
            shieldNumber.text = _POC.GetCurrentShieldPoints().ToString();
        }
        //Hull values
        if ((_POC.GetMaxHullPoints() < 1))
        {
            hullBar.fillAmount = 0;
            hullNumber.text = "0";
        }
        else
        {
            hullBar.fillAmount = _POC.GetCurrentHullPoints() / _POC.GetMaxHullPoints();
            hullNumber.text = _POC.GetCurrentHullPoints().ToString();
        }

        //Energy Values
        //if ((_POC.GetMaxEnergy() < 1))
        //{
        //    energyBar.fillAmount = 0;
        //    energyNumber.text = "0";
        //}
        //else
        //{
        //    energyBar.fillAmount = _POC.GetAvailEnergy() / _POC.GetMaxEnergy();
        //    energyNumber.text = _POC.GetAvailEnergy().ToString();
        //}

    }
}
