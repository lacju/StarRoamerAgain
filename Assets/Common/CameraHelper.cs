using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHelper : MonoBehaviour {

    private GameObject playerObject;
    private OrthoSmoothFollow oSF;

    private void Awake()
    {
        oSF = gameObject.GetComponent<OrthoSmoothFollow>();
        playerObject = GameObject.Find("PlayerObject");
    }

    private void Start()
    {
      
      oSF.target = playerObject.transform;
    }

   
    
}
