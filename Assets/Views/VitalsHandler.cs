using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitalsHandler : MonoBehaviour {

    public Image energyBarFill;
    public Image shieldBarFill;
    public Image hullBarFill;
    public GameObject energyBar;
    public GameObject shieldBar;
    public GameObject hullBar;

    private float lastEnergyAmt;
    private float lastShieldAmt;
    private float lastHullAmt;

    private PlayerObject _POC;

    private void Awake()
    {
        _POC = FindObjectOfType<PlayerObject>();
    }

    private void Start()
    {
        energyBarFill.fillAmount = (_POC.hull.equippedReactor.availableEnergy / _POC.hull.equippedReactor.maxPower);
        shieldBarFill.fillAmount = (_POC.hull.equippedShields.currentShields / _POC.hull.equippedShields.maxCapacity);
        hullBarFill.fillAmount = (_POC.hull.currentHullpoints / _POC.hull.maxHullPoints);

        //lastEnergyAmt = _POC.GetAvailEnergy();
        lastShieldAmt = _POC.GetCurrentShieldPoints();
        lastHullAmt = _POC.GetCurrentHullPoints();
    }

    public void EnableVitalBars()
    {
        energyBar.SetActive(true);
        shieldBar.SetActive(true);
        hullBar.SetActive(true);
    }

    public void DisableVitalBars()
    {
        energyBar.SetActive(false);
        shieldBar.SetActive(false);
        hullBar.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (lastEnergyAmt != _POC.hull.equippedReactor.availableEnergy)
        {
            energyBarFill.fillAmount = (_POC.hull.equippedReactor.availableEnergy / _POC.hull.equippedReactor.maxPower);
            lastEnergyAmt = _POC.hull.equippedReactor.availableEnergy;
        }
        if (lastShieldAmt != _POC.hull.equippedShields.currentShields)
        {
            shieldBarFill.fillAmount = (_POC.hull.equippedShields.currentShields / _POC.hull.equippedShields.maxCapacity);
            lastShieldAmt = _POC.hull.equippedShields.currentShields;
        }
        if (lastHullAmt != _POC.hull.currentHullpoints)
        {
            hullBarFill.fillAmount = (_POC.hull.currentHullpoints / _POC.hull.maxHullPoints);
            lastHullAmt = _POC.hull.currentHullpoints;
        }
    }


}
