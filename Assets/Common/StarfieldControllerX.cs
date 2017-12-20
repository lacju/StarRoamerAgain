using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarfieldControllerX : MonoBehaviour {

    public PlayerObject _POC;
    public int distanceFromPlayer;
    private void FixedUpdate()
    {
        gameObject.transform.localPosition = new Vector3(_POC.transform.localPosition.x + distanceFromPlayer, 0,0);
    }
}
