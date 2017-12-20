using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationMenuButtonHandler : MonoBehaviour
{

    public void ClosePlayerInventory()
    {
        gameObject.SendMessageUpwards("HidePlayerInventory");
    }

    public void CloseGoodsVendorWindow()
    {
        gameObject.SendMessageUpwards("HideGoodsVendorWindow");
    }

    public void CloseMainWindow()
    {
        gameObject.SendMessageUpwards("HideMainMenu");
    }

    public void CloseEquipmentVendorWindow()
    {
        gameObject.SendMessageUpwards("HideEquipmentVendorWindow");
    }

    public void OpenGoodsVendorWindow()
    {
        gameObject.SendMessageUpwards("ShowGoodsVendorWindow");
    }

    public void OpenMainWindow()
    {
        gameObject.SendMessageUpwards("ShowMainMenu");
    }

    public void OpenEquipmentVendorWindow()
    {
        gameObject.SendMessageUpwards("ShowEquipmentVendorWindow");
    }

    public void OpenPlayerInventory()
    {
        gameObject.SendMessageUpwards("ShowPlayerInventory");
    }
}
