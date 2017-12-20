using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningWindowHandler : MonoBehaviour {

	public void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}
